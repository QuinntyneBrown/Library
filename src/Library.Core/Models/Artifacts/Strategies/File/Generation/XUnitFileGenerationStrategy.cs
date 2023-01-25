using Microsoft.Extensions.Logging;

namespace Library.Core.Models.Artifacts.Strategies.File.Generation;

public class XUnitFileGenerationStrategy : IFileGenerationStrategy
{
    private readonly IFileSystem _fileSystem;
    private readonly ITemplateLocator _templateLocator;
    private readonly ITemplateProcessor _templateProcessor;
    private readonly ILogger _logger;

    public XUnitFileGenerationStrategy(
        IFileSystem fileSystem,
        ITemplateLocator templateLocator,
        ITemplateProcessor templateProcessor,
        ILogger logger
        )
    {
        _fileSystem = fileSystem ?? throw new ArgumentException(nameof(fileSystem));
        _templateProcessor = templateProcessor ?? throw new ArgumentNullException(nameof(templateProcessor));
        _templateLocator = templateLocator ?? throw new ArgumentNullException(nameof(templateLocator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int Order => 0;

    public bool CanHandle(dynamic model) => model is XUnitFileModel;

    public void Create(dynamic model, SolutionModel solutionModel = null) => Create(model);

    public void Create(XUnitFileModel model)
    {

    }
}
