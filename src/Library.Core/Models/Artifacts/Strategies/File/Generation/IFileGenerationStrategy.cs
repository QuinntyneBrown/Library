namespace Library.Core.Models.Artifacts.Strategies.File.Generation;

public interface IFileGenerationStrategy
{
    void Create(dynamic model, SolutionModel solutionModel = null);

    int Order { get; }
    bool CanHandle(dynamic model);

}
