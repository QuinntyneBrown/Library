using Library.Core.Models;
using Library.Core.Models.Strategies.File.Generation;
using Library.Core.Models.Strategies.Project.Generation;
using Library.Core.Models.Strategies.Project.Update;
using Microsoft.Extensions.Logging;

namespace Library.Core.Models.Strategies.Solution.Update
{
    public class SolutionUpdateStrategy : ISolutionUpdateStrategy
    {
        private readonly ICommandService _commandService;
        private readonly IFileSystem _fileSystem;
        private readonly ILogger _logger;
        private readonly IFileGenerationStrategyFactory _fileGenerationStrategyFactory;
        private readonly ICsProjFileManager _csProjFileManager;
        private readonly IProjectGenerationStrategyFactory _projectGenerationStrategyFactory;
        private readonly IProjectUpdateStrategyFactory _projectUpdateStrategyFactory;
        public SolutionUpdateStrategy(ICommandService commandService, ILogger logger, IFileSystem fileSystem, IFileGenerationStrategyFactory fileGenerationStrategyFactory, ICsProjFileManager csProjFileManager, IProjectGenerationStrategyFactory projectGenerationStrategyFactory, IProjectUpdateStrategyFactory projectUpdateStrategyFactory)
        {
            _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            _fileGenerationStrategyFactory = fileGenerationStrategyFactory ?? throw new ArgumentNullException(nameof(fileGenerationStrategyFactory));
            _csProjFileManager = csProjFileManager ?? throw new ArgumentNullException(nameof(csProjFileManager));
            _projectGenerationStrategyFactory = projectGenerationStrategyFactory;
            _projectUpdateStrategyFactory = projectUpdateStrategyFactory;
        }

        public int Order => 0;

        public bool CanHandle(ProjectModel model) => true;

        public void Update(SolutionModel previous, SolutionModel next)
        {
            foreach (var nextFile in next.Files)
            {
                var previousFile = previous.Files.SingleOrDefault(x => x.Name == nextFile.Name);

                if (previousFile == null)
                {
                    _fileGenerationStrategyFactory.CreateFor(nextFile);
                }
                else
                {

                }

                //TODO: Update Solution Items Files
            }

            foreach (var nextProject in next.Projects)
            {
                var previousProject = previous.Projects.SingleOrDefault(x => x.Name == nextProject.Name);

                if (previousProject == null)
                {
                    _projectGenerationStrategyFactory.CreateFor(nextProject);
                }
                else
                {
                    _projectUpdateStrategyFactory.UpdateFor(previousProject, nextProject);
                }
            }

            // Serialize Solution model and save in root
        }
    }
}
