// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Library.Core.Models.Artifacts.Strategies.Abstractions;

namespace Library.Core.Models.Artifacts.Services;

public class SolutionService : ISolutionService
{
    private readonly IArtifactGenerationStrategyFactory _factory;

    public SolutionService(IArtifactGenerationStrategyFactory factory)
    {
        _factory = factory;
    }

    public void Create(SolutionModel model)
    {
        _factory.CreateFor(model);
    }
}

