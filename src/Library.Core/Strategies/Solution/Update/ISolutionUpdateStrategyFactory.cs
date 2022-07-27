using Library.Core.Models;

namespace Library.Core.Strategies
{
    public interface ISolutionUpdateStrategyFactory
    {
        void UpdateFor(SolutionModel previous, SolutionModel next);
    }
}
