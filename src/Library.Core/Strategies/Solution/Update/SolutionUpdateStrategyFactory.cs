using Library.Core.Models;
using Library.Core.Strategies.Solution.Updating;

namespace Library.Core.Strategies
{
    public class SolutionUpdateStrategyFactory : ISolutionUpdateStrategyFactory
    {
        private readonly List<ISolutionUpdateStrategy> _strategies;

        public SolutionUpdateStrategyFactory()
        {
            _strategies = new List<ISolutionUpdateStrategy>()
            {

            };
        }

        public void UpdateFor(SolutionModel previousModel, SolutionModel next)
        {

        }
    }
}
