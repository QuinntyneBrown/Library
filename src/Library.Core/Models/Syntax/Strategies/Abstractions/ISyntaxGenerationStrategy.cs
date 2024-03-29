// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Syntax.Strategies.Abstractions;

public interface ISyntaxGenerationStrategy
{
    bool CanHandle(object model, dynamic? context = null);
    string Create(object model, dynamic? context = null);
    int Priority { get; }
}

