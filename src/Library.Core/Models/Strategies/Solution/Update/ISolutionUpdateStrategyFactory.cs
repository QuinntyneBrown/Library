using Library.Core.Models;

namespace Library.Core.Models.Strategies.Solution.Update
{
    public interface ISolutionUpdateStrategyFactory
    {
        void UpdateFor(SolutionModel previous, SolutionModel next);
    }
}
