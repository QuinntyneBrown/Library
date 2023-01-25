using Library.Core.Models;

namespace Library.Core.Models.Strategies.Solution.Update
{
    public interface ISolutionUpdateStrategy
    {
        int Order { get; }
        bool CanHandle(ProjectModel model);

        void Update(SolutionModel previous, SolutionModel next);
    }
}
