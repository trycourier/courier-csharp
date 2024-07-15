using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record MessageHistoryResponse
{
    [JsonPropertyName("results")]
    public IEnumerable<Dictionary<string, object>> Results { get; init; } =
        new List<Dictionary<string, object>>();
}
