using Library.Core.Models;

namespace Library.Core.Strategies
{
    public interface IProjectGenerationStrategyFactory
    {
        void CreateFor(ProjectModel model);
    }
}
