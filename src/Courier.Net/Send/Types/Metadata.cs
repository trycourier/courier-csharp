using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record Metadata
{
    [JsonPropertyName("utm")]
    public Utm? Utm { get; init; }
}
