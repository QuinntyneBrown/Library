namespace Library.Core.Models.Artifacts.Strategies.Abstractions;

public interface IArtifactGenerationStrategyFactory
{
    void CreateFor(object model, dynamic? context = null);
}
