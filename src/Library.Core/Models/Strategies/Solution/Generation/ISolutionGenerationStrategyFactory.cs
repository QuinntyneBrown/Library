using Library.Core.Models;

namespace Library.Core.Models.Strategies.Solution.Generation
{
    public interface ISolutionGenerationStrategyFactory
    {
        void CreateFor(SolutionModel model);
    }
}
