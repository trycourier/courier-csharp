using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record MultipleTokens
{
    [JsonPropertyName("tokens")]
    public IEnumerable<Token> Tokens { get; set; } = new List<Token>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
