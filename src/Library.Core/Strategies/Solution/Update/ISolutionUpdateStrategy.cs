using Library.Core.Models;

namespace Library.Core.Strategies.Solution.Updating
{
    public interface ISolutionUpdateStrategy
    {
        int Order { get; }
        bool CanHandle(ProjectModel model);

        void Update(SolutionModel previous, SolutionModel next);
    }
}
