using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record MessageHistoryResponse
{
    [JsonPropertyName("results")]
    public IEnumerable<Dictionary<string, object?>> Results { get; set; } =
        new List<Dictionary<string, object?>>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
