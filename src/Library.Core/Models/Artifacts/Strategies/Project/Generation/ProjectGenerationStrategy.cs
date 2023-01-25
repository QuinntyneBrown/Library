using Library.Core.Models.Artifacts.Strategies.File.Generation;
using Microsoft.Extensions.Logging;

namespace Library.Core.Models.Artifacts.Strategies.Project.Generation;

public class ProjectGenerationStrategy : IProjectGenerationStrategy
{
    private readonly ICommandService _commandService;
    private readonly IFileSystem _fileSystem;
    private readonly ILogger _logger;
    private readonly IFileGenerationStrategyFactory _fileGenerationStrategyFactory;
    private readonly ICsProjFileManager _csProjFileManager;

    public ProjectGenerationStrategy(ICommandService commandService, ILogger logger, IFileSystem fileSystem, IFileGenerationStrategyFactory fileGenerationStrategyFactory, ICsProjFileManager csProjFileManager)
    {
        _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        _fileGenerationStrategyFactory = fileGenerationStrategyFactory ?? throw new ArgumentNullException(nameof(fileGenerationStrategyFactory));
        _csProjFileManager = csProjFileManager ?? throw new ArgumentNullException(nameof(csProjFileManager));
    }

    public int Order => 0;

    public bool CanHandle(ProjectModel model) => true;

    public void Create(ProjectModel model)
    {
        var cmd = $"dotnet new {model.ProjectType} -n {model.Name}";

        _commandService.Start(cmd, model.ParentDirectory);

        if (model.Metadata.Contains(Constants.Metadata.NugetPackage))
        {
            _csProjFileManager.AddNugetConfiguration(model);
        }

        foreach (var package in model.Packages)
        {
            _commandService.Start($"dotnet add package {package.Name}", model.Directory);
        }

        foreach (var path in Directory.GetFiles(model.Directory, "*.cs", SearchOption.AllDirectories).Where(x => !x.EndsWith("Program.cs")))
        {
            _fileSystem.Delete(path);
        }
    }
}
