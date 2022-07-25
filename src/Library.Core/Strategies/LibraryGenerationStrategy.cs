using Library.Core.Factories;
using Library.Core.Options;
using Microsoft.Extensions.Logging;

namespace Library.Core.Strategies
{
    public class LibraryGenerationStrategy : ILibraryGenerationStrategy
    {
        private readonly ICommandService _commandService;
        private readonly IFileSystem _fileSystem;
        private readonly ILogger _logger;
        private readonly IFileGenerationStrategy _fileGenerationStrategy;

        public LibraryGenerationStrategy(ICommandService commandService, ILogger logger, IFileSystem fileSystem, IFileGenerationStrategy fileGenerationStrategy)
        {
            _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            _fileGenerationStrategy = fileGenerationStrategy ?? throw new ArgumentNullException(nameof(fileGenerationStrategy));
        }

        public int Order => 0;

        public bool CanHandle(CreateLibraryOptions options) => true;

        public void Create(CreateLibraryOptions options)
        {
            _logger.LogInformation($"{nameof(LibraryGenerationStrategy)}: Creating new library name {options.Name} in {options.Directory}");

            var model = LibraryModelFactory.Create(options.Name, options.Directory);

            _fileSystem.CreateDirectory(model.SolutionDirectory);

            var tokens = new TokensBuilder()
                .With("name",(Token)options.Name)
                .Build();

            _fileGenerationStrategy.Create(FileModelFactory.Create(Constants.Templates.ReadMe, "README", model.SolutionDirectory, "md", tokens));

            _commandService.Start("dotnet new sln", model.SolutionDirectory);

            foreach(var project in model.Projects.OrderBy(x => x.Order))
            {
                _commandService.Start($"dotnet new {project.ProjectType} -n {project.Name}", project.ParentDirectory);

                foreach(var package in project.Packages)
                {
                    _commandService.Start($"dotnet add package {package.Name}");
                }

                _commandService.Start($"dotnet sln add {project.Directory}{Path.DirectorySeparatorChar}{project.Name}.csproj", model.SolutionDirectory);
            }

            foreach(var dependsOn in model.DependOns)
            {
                _commandService.Start($"dotnet add {dependsOn.Client.Directory} reference {dependsOn.Supplier.Directory}{Path.DirectorySeparatorChar}{dependsOn.Supplier.Name}.csproj");
            }

            var lines = _fileSystem.ReadAllLines($"{model.SolutionDirectory}{Path.DirectorySeparatorChar}{options.Name}.sln");

            var newLines = new List<string>();

            foreach (var line in lines)
            {
                if (line.Trim().ToLower() == "global")
                {
                    newLines.Add("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"Solution Items\", \"Solution Items\", \"{0D44DB76-828F-4BEC-A396-0653B10EC5D2}\"");
                    newLines.Add("	ProjectSection(SolutionItems) = preProject");
                    newLines.Add("		README.md = README.md");
                    newLines.Add("	EndProjectSection");
                    newLines.Add("EndProject");
                }

                newLines.Add(line);
            }

            _fileSystem.WriteAllLines($"{model.SolutionDirectory}{Path.DirectorySeparatorChar}{options.Name}.sln", newLines.ToArray());

            _commandService.Start($"start {options.Name}.sln", model.SolutionDirectory);
        }
    }
}
