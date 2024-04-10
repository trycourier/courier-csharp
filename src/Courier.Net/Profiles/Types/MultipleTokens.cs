using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class MultipleTokens
{
    [JsonPropertyName("tokens")]
    public List<Token> Tokens { get; init; }
}
