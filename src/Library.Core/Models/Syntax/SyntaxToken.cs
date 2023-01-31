using CSharpFunctionalExtensions;
using Newtonsoft.Json;

namespace Library.Core.Models.Syntax;

public class SyntaxToken : ValueObject
{    
    public const int MaxLength = 250;

    [JsonProperty]
    public string Value { get; private set; }

    public SyntaxToken(string value = "")
    {
        Value = value;
    }

    public static Result<SyntaxToken> Create(string value)
    {
        value = (value ?? string.Empty).Trim();

        return Result.Success(new SyntaxToken(value));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(SyntaxToken token)
    {
        return token.Value;
    }

    public static explicit operator SyntaxToken(string token)
    {
        return Create(token).Value;
    }
}