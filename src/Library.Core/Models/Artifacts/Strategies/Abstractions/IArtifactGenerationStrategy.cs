// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Artifacts.Strategies.Abstractions;

public interface IArtifactGenerationStrategy
{
    bool CanHandle(object model, dynamic? context = null);
    void Create(object model, dynamic? context = null);
    int Priority { get; }
}

