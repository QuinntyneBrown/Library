using Library.Core.Models;

namespace Library.Core.Models.Strategies.Solution.Generation
{
    public interface ISolutionGenerationStrategy
    {
        int Order { get; }
        bool CanHandle(SolutionModel model);

        void Create(SolutionModel model);
    }
}
