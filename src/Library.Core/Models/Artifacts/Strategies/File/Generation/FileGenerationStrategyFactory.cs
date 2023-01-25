using Microsoft.Extensions.Logging;

namespace Library.Core.Models.Artifacts.Strategies.File.Generation;

public class FileGenerationStrategyFactory : IFileGenerationStrategyFactory
{
    private readonly List<IFileGenerationStrategy> _strategies;

    public FileGenerationStrategyFactory(IFileSystem fileSystem, ITemplateLocator templateLocator, ITemplateProcessor templateProcessor, ILogger logger)
    {
        _strategies = new List<IFileGenerationStrategy>
        {
            new TemplateFileGenerationStrategy(fileSystem,templateLocator,templateProcessor,logger),
            new XUnitFileGenerationStrategy(fileSystem,templateLocator,templateProcessor,logger),
            new CSharpFileGenerationStrategy(fileSystem,templateLocator,templateProcessor,logger)
        };
    }

    public void CreateFor<T>(T model) where T : FileModel
    {
        _strategies
            .OrderBy(x => x.Order)
            .First(x => x.CanHandle(model))
            .Create(model);
    }
}
