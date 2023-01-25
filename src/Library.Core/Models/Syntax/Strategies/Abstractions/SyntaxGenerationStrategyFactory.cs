namespace Library.Core.Models.Syntax.Strategies.Abstractions;

public class SyntaxGenerationStrategyFactory : ISyntaxGenerationStrategyFactory
{
    private readonly IEnumerable<ISyntaxGenerationStrategy> _strategies;
    public SyntaxGenerationStrategyFactory(IEnumerable<ISyntaxGenerationStrategy> strategies)
    {
        _strategies = strategies;
    }
    public string CreateFor(object model, dynamic? context = null)
    {
        var strategy = _strategies.Where(x => x.CanHandle(model, context))
            .OrderBy(x => x.Priority)
            .FirstOrDefault();

        if (strategy == null)
        {
            throw new NotImplementedException();
        }

        return strategy.Create(model, context);
    }
}