using Library.Core.Models.Artifacts.Strategies.Abstractions;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using static System.Text.Json.JsonSerializer;

namespace Library.Core.Models.Artifacts.Strategies;

public class SolutionGenerationStrategy : ArtifactGenerationStrategyBase<SolutionModel>
{
    private readonly ICommandService _commandService;
    private readonly IFileSystem _fileSystem;
    private readonly ILogger<SolutionGenerationStrategy> _logger;
    private readonly ICsProjFileManager _csProjFileManager;
 

    public SolutionGenerationStrategy(IServiceProvider serviceProvider, ICommandService commandService, ILogger<SolutionGenerationStrategy> logger, IFileSystem fileSystem, ICsProjFileManager csProjFileManager)
        : base(serviceProvider)
    {
        _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        _csProjFileManager = csProjFileManager ?? throw new ArgumentNullException(nameof(csProjFileManager));
    }

    public override void Create(IArtifactGenerationStrategyFactory artifactGenerationStrategyFactory, SolutionModel model, dynamic? context = null)
    {
        _logger.LogInformation($"{nameof(SolutionGenerationStrategy)}: Creating new solution name {model.Name} in {model.ParentDirectory}");

        _fileSystem.CreateDirectory(model.Directory);

        _fileSystem.CreateDirectory(model.SrcDirectory);

        _fileSystem.CreateDirectory(model.TestDirectory);

        _commandService.Start("dotnet new sln", model.Directory);

        foreach (var project in model.Projects.OrderBy(x => x.Order))
        {
            artifactGenerationStrategyFactory.CreateFor(project);

            _commandService.Start($"dotnet sln add {project.Directory}{Path.DirectorySeparatorChar}{project.Name}.csproj", model.Directory);
        }

        foreach (var dependsOn in model.DependOns)
        {
            var client = model.Projects.Single(x => x.Name == dependsOn.Client);

            var supplier = model.Projects.Single(x => x.Name == dependsOn.Service);

            _commandService.Start($"dotnet add {client.Directory} reference {supplier.Directory}{Path.DirectorySeparatorChar}{supplier.Name}.csproj");
        }

        var lines = _fileSystem.ReadAllLines($"{model.Directory}{Path.DirectorySeparatorChar}{model.Name}.sln");

        var newLines = new List<string>();

        foreach (var line in lines)
        {
            if (line.Trim().ToLower() == "global")
            {
                newLines.Add("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\") = \"Solution Items\", \"Solution Items\", \"{0D44DB76-828F-4BEC-A396-0653B10EC5D2}\"");
                newLines.Add("	ProjectSection(SolutionItems) = preProject");

                foreach (var file in model.Files)
                {
                    artifactGenerationStrategyFactory.CreateFor(file);
                    newLines.Add($"		{file.Name}.{file.Extension} = {file.Name}.{file.Extension}");
                }

                newLines.Add("	EndProjectSection");
                newLines.Add("EndProject");
            }

            newLines.Add(line);
        }

        _fileSystem.WriteAllLines($"{model.Directory}{Path.DirectorySeparatorChar}{model.Name}.sln", newLines.ToArray());

        _commandService.Start($"start {model.Name}.sln", model.Directory);

        var json = Serialize(model, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        });

        _fileSystem.WriteAllLines($"{model.Directory}{Path.DirectorySeparatorChar}solution.json", new string[1] { json });
    }


}
