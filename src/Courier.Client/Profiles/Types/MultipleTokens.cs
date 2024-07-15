using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record MultipleTokens
{
    [JsonPropertyName("tokens")]
    public IEnumerable<Token> Tokens { get; init; } = new List<Token>();
}
