namespace Library.Core.Models.Syntax.Strategies.Abstractions;

public interface ISyntaxGenerationStrategyFactory
{
    string CreateFor(object model, dynamic? context = null);
}
