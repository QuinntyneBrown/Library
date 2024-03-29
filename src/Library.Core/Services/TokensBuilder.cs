// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Library.Core.Models.Syntax;

namespace Library.Core;

public class TokensBuilder
{
    private Dictionary<string, object> _value { get; set; } = new();

    public TokensBuilder()
    {
        _value = new();
    }
    public TokensBuilder With(string propertyName, SyntaxToken token)
    {
        var tokens = token == null ? new SyntaxToken("").ToTokens(propertyName) : token.ToTokens(propertyName);
        _value = new Dictionary<string, object>(_value.Concat(tokens));
        return this;
    }

    public Dictionary<string, object> Build()
        => this._value;
}

