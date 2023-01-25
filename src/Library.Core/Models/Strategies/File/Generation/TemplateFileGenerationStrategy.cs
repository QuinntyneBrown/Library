using Library.Core.Models;
using Microsoft.Extensions.Logging;

namespace Library.Core.Models.Strategies.File.Generation
{
    public class TemplateFileGenerationStrategy : IFileGenerationStrategy
    {
        private readonly IFileSystem _fileSystem;
        private readonly ITemplateLocator _templateLocator;
        private readonly ITemplateProcessor _templateProcessor;
        private readonly ILogger _logger;

        public TemplateFileGenerationStrategy(
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

        public bool CanHandle(dynamic model) => model is TemplateFileModel;

        public void Create(dynamic model, SolutionModel solutionModel = null) => Create(model);
        public void Create(TemplateFileModel model)
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
}
