using Library.Core.Models;

namespace Library.Core.Strategies
{
    public interface IProjectUpdateStrategyFactory
    {
        void UpdateFor(ProjectModel previousModel, ProjectModel newModel);
    }

    public interface IProjectUpdateStrategy
    {

    }

    public class ProjectUpdateStrategyFactory : IProjectUpdateStrategyFactory
    {
        public void UpdateFor(ProjectModel previousModel, ProjectModel newModel)
        {

        }
    }

    public class ProjectUpdateStrategy: IProjectUpdateStrategy
    {

    }
}
