using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record Metadata
{
    [JsonPropertyName("utm")]
    public Utm? Utm { get; init; }
}
