using Library.Core.Models;

namespace Library.Core.Strategies
{
    public interface ISolutionGenerationStrategy
    {
        int Order { get; }
        bool CanHandle(SolutionModel model);

        void Create(SolutionModel model);
    }
}
