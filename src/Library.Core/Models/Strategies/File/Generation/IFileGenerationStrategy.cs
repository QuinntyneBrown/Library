using Library.Core.Models;

namespace Library.Core.Models.Strategies.File.Generation
{
    public interface IFileGenerationStrategy
    {
        void Create(dynamic model, SolutionModel solutionModel = null);

        int Order { get; }
        bool CanHandle(dynamic model);

    }
}
