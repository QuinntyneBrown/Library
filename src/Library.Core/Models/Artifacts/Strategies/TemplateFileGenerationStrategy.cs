using Library.Core.Models.Artifacts.Strategies.Abstractions;
using Microsoft.Extensions.Logging;

namespace Library.Core.Models.Artifacts.Strategies;

public class TemplateFileGenerationStrategy : ArtifactGenerationStrategyBase<TemplateFileModel>
{
    private readonly IFileSystem _fileSystem;
    private readonly ITemplateLocator _templateLocator;
    private readonly ITemplateProcessor _templateProcessor;
    private readonly ILogger<TemplateFileGenerationStrategy> _logger;

    public TemplateFileGenerationStrategy(
        IServiceProvider serviceProvider,
        IFileSystem fileSystem,
        ITemplateLocator templateLocator,
        ITemplateProcessor templateProcessor,
        ILogger<TemplateFileGenerationStrategy> logger
        ) : base(serviceProvider)
    {
        _fileSystem = fileSystem ?? throw new ArgumentException(nameof(fileSystem));
        _templateProcessor = templateProcessor ?? throw new ArgumentNullException(nameof(templateProcessor));
        _templateLocator = templateLocator ?? throw new ArgumentNullException(nameof(templateLocator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public override void Create(IArtifactGenerationStrategyFactory artifactGenerationStrategyFactory, TemplateFileModel model, dynamic? context = null)
    {
        _logger.LogInformation($"Creating {model.Name} file at {model.Path}");

        var template = _templateLocator.Get(model.Template);

        var result = model.Tokens == null ? template : _templateProcessor.Process(template, model.Tokens);

        var parts = Path.GetDirectoryName(model.Path).Split(Path.DirectorySeparatorChar);

        for (var i = 1; i <= parts.Length; i++)
        {
            var path = string.Join(Path.DirectorySeparatorChar, parts.Take(i));

            if (!_fileSystem.Exists(path))
            {
                _fileSystem.CreateDirectory(path);
            }
        }

        _fileSystem.WriteAllLines(model.Path, result);
    }
}
