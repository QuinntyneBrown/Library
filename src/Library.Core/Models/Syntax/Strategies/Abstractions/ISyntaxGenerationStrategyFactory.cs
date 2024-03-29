// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Syntax.Strategies.Abstractions;

public interface ISyntaxGenerationStrategyFactory
{
    string CreateFor(object model, dynamic? context = null);
}

