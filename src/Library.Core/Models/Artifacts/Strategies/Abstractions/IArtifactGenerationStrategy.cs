namespace Library.Core.Models.Artifacts.Strategies.Abstractions;

public interface IArtifactGenerationStrategy
{
    bool CanHandle(object model, dynamic? context = null);
    void Create(object model, dynamic? context = null);
    int Priority { get; }
}
