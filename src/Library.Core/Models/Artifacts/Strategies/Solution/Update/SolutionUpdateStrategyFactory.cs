namespace Library.Core.Models.Artifacts.Strategies.Solution.Update
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
