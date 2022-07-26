using Library.Core.Options;
using Microsoft.Extensions.Logging;

namespace Library.Core.Strategies
{
    public class LibraryGenerationStrategyFactory : ILibraryGenerationStrategyFactory
    {
        private readonly IList<ILibraryGenerationStrategy> _strategies;
        
        public LibraryGenerationStrategyFactory(ILogger logger, IFileSystem fileSystem, ICommandService commandService, IFileGenerationStrategyFactory fileGenerationStrategyFactory, ICsProjFileManager csProjFileManager)
        {
            _strategies = new List<ILibraryGenerationStrategy>()
            {
                new LibraryGenerationStrategy(commandService,logger,fileSystem, fileGenerationStrategyFactory, csProjFileManager)
            };
        }

        public void CreateFor(CreateLibraryOptions options)
        {
            _strategies
                .OrderBy(x => x.Order)
                .First(x => x.CanHandle(options))
                .Create(options);
        }
    }
}
