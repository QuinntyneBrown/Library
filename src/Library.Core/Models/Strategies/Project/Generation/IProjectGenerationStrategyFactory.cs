using Library.Core.Models;

namespace Library.Core.Models.Strategies.Project.Generation
{
    public interface IProjectGenerationStrategyFactory
    {
        void CreateFor(ProjectModel model);
    }
}
