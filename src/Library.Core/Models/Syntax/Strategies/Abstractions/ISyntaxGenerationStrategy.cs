namespace Library.Core.Models.Syntax.Strategies.Abstractions;

public interface ISyntaxGenerationStrategy
{
    bool CanHandle(object model, dynamic? context = null);
    string Create(object model, dynamic? context = null);
    int Priority { get; }
}
