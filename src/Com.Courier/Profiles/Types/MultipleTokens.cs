using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record MultipleTokens
{
    [JsonPropertyName("tokens")]
    public IEnumerable<Token> Tokens { get; init; } = new List<Token>();
}
