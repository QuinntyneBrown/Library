using Library.Core.Models;
using Microsoft.Extensions.Logging;

namespace Library.Core
{
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
            _fileSystem = fileSystem ?? throw new System.ArgumentException(nameof(fileSystem));
            _templateProcessor = templateProcessor ?? throw new System.ArgumentNullException(nameof(templateProcessor));
            _templateLocator = templateLocator ?? throw new System.ArgumentNullException(nameof(templateLocator));
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public int Order => 0;

        public bool CanHandle(dynamic model) => model is XUnitFileModel;

        public void Create(dynamic model) => Create(model);

        public void Create(XUnitFileModel model)
        {

        }
    }
}
