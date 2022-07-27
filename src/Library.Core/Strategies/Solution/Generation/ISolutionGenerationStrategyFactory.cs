using Library.Core.Models;

namespace Library.Core.Strategies
{
    public interface ISolutionGenerationStrategyFactory
    {
        void CreateFor(SolutionModel model);
    }
}
