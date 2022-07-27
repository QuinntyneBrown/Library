using Library.Core.Models;

namespace Library.Core.Strategies
{
    public interface IProjectGenerationStrategy
    {
        int Order { get; }
        bool CanHandle(ProjectModel model);

        void Create(ProjectModel model);
    }
}
