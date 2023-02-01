// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
