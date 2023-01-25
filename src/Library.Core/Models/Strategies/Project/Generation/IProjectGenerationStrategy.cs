using Library.Core.Models;

namespace Library.Core.Models.Strategies.Project.Generation
{
    public interface IProjectGenerationStrategy
    {
        int Order { get; }
        bool CanHandle(ProjectModel model);

        void Create(ProjectModel model);
    }
}
