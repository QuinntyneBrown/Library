// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Artifacts.Strategies.Abstractions;

public class ArtifactGenerationStrategyFactory : IArtifactGenerationStrategyFactory
{
    private readonly IEnumerable<IArtifactGenerationStrategy> _strategies;
    public ArtifactGenerationStrategyFactory(IEnumerable<IArtifactGenerationStrategy> strategies)
    {
        _strategies = strategies;
    }
    public void CreateFor(object model, dynamic? context = null)
    {
        var strategy = _strategies.Where(x => x.CanHandle(model, context))
            .OrderBy(x => x.Priority)
            .FirstOrDefault();

        if (strategy == null)
        {
            throw new NotImplementedException();
        }

        strategy.Create(model, context);
    }
}
