using Library.Core.Models;

namespace Library.Core
{
    public interface IFileGenerationStrategy
    {
        void Create(dynamic model, SolutionModel solutionModel = null);

        int Order { get; }
        bool CanHandle(dynamic model);

    }
}
