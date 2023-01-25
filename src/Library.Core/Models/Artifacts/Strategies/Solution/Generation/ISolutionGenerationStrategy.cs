namespace Library.Core.Models.Artifacts.Strategies.Solution.Generation;

public interface ISolutionGenerationStrategy
{
    int Order { get; }
    bool CanHandle(SolutionModel model);

    void Create(SolutionModel model);
}
