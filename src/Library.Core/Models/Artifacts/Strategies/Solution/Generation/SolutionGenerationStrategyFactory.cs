using Library.Core.Models.Artifacts.Strategies.File.Generation;
using Library.Core.Models.Artifacts.Strategies.Project.Generation;
using Microsoft.Extensions.Logging;

namespace Library.Core.Models.Artifacts.Strategies.Solution.Generation
{
    public class SolutionGenerationStrategyFactory : ISolutionGenerationStrategyFactory
    {
        private readonly IList<ISolutionGenerationStrategy> _strategies;

        public SolutionGenerationStrategyFactory(ILogger logger, IFileSystem fileSystem, ICommandService commandService, IFileGenerationStrategyFactory fileGenerationStrategyFactory, ICsProjFileManager csProjFileManager, IProjectGenerationStrategyFactory projectGenerationStrategyFactory)
        {
            _strategies = new List<ISolutionGenerationStrategy>()
            {
                new SolutionGenerationStrategy(commandService,logger,fileSystem, fileGenerationStrategyFactory, csProjFileManager, projectGenerationStrategyFactory)
            };
        }

        public void CreateFor(SolutionModel model)
        {
            _strategies
                .OrderBy(x => x.Order)
                .First(x => x.CanHandle(model))
                .Create(model);
        }
    }

    public class ProjectGenerationStrategyFactory : IProjectGenerationStrategyFactory
    {
        private readonly IList<IProjectGenerationStrategy> _strategies;

        public ProjectGenerationStrategyFactory(ILogger logger, IFileSystem fileSystem, ICommandService commandService, IFileGenerationStrategyFactory fileGenerationStrategyFactory, ICsProjFileManager csProjFileManager)
        {
            _strategies = new List<IProjectGenerationStrategy>()
            {
                new ProjectGenerationStrategy(commandService,logger,fileSystem,fileGenerationStrategyFactory,csProjFileManager)
            };
        }

        public void CreateFor(ProjectModel model)
        {
            _strategies
                .OrderBy(x => x.Order)
                .First(x => x.CanHandle(model))
                .Create(model);
        }
    }
}
