using Library.Core.Models;
using Microsoft.Extensions.Logging;

namespace Library.Core
{
    public class CSharpFileGenerationStrategy : IFileGenerationStrategy
    {
        private readonly IFileSystem _fileSystem;
        private readonly ITemplateLocator _templateLocator;
        private readonly ITemplateProcessor _templateProcessor;
        private readonly ILogger _logger;

        public CSharpFileGenerationStrategy(
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

        public bool CanHandle(dynamic model) 
            => model is CSharpFileModel 
            || model is AggregateRootCSharpFileModel;

        public void Create(dynamic model, SolutionModel solutionModel = null) => Create(model);
        public void Create(CSharpFileModel model)
        {
            _logger.LogInformation($"Creating {model.Name} file at {model.Path}");

            var content = new List<string>();

            _write(model.Directory, model.Namespace, model.Name, content);

        }

        public void Create(AggregateRootCSharpFileModel model)
        {
            _logger.LogInformation($"Creating {model.Name} file at {model.Path}");

            var content = new List<string>();

            content.Add($"public class {((Token)model.AggregateRootModel.Name).PascalCase}");

            content.Add("{");

            foreach (var property in model.AggregateRootModel.Properties)
            {
                content.Add(($"public {property.Type} {property.Name}" + " { get; set; }").Indent(1));
            }

            content.Add("}");

            _write(model.Directory, model.Namespace, model.Name, content);

        }

        private void _write(string directory, string @namespace, string filename, List<string> content)
        {
            var classContent = new List<string>()
            {
                $"namespace {@namespace};", ""
            };

            _fileSystem.WriteAllLines($"{directory}{Path.DirectorySeparatorChar}{filename}.cs", classContent.Concat(content).ToArray());
        }
    }
}
