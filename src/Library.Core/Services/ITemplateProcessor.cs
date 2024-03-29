// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Library.Core
{
    public interface ITemplateProcessor
    {
        string[] Process(string[] template, IDictionary<string, object> tokens, string[] ignoreTokens = null);
        string Process(string template, IDictionary<string, object> tokens);
    }
}

