// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.DependencyInjection;

namespace Library.Core.Models.Artifacts.Strategies.Abstractions;

public abstract class ArtifactGenerationStrategyBase<T> : IArtifactGenerationStrategy
    where T : class
{
    protected readonly IServiceProvider _serviceProvider;

    public ArtifactGenerationStrategyBase(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public virtual bool CanHandle(object model, dynamic? context = null) => model is T;

    public virtual void Create(object model, dynamic? context = null)
    {
        using (IServiceScope scope = _serviceProvider.CreateScope())
        {
            var artifactGenerationStrategyFactory = scope.ServiceProvider
                .GetRequiredService<IArtifactGenerationStrategyFactory>();
            Create(artifactGenerationStrategyFactory, model as T, context);
        }
    }

    public abstract void Create(IArtifactGenerationStrategyFactory artifactGenerationStrategyFactory, T model, dynamic? context = null);
    public virtual int Priority => 0;
}

