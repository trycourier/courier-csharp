using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record MultipleTokens
{
    [JsonPropertyName("tokens")]
    public IEnumerable<Token> Tokens { get; init; } = new List<Token>();
}
