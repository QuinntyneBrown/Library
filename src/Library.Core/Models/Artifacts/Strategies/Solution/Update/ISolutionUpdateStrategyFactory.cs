namespace Library.Core.Models.Artifacts.Strategies.Solution.Update
{
    public interface ISolutionUpdateStrategyFactory
    {
        void UpdateFor(SolutionModel previous, SolutionModel next);
    }
}
