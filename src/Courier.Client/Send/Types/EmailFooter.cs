using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record EmailFooter
{
    [JsonPropertyName("content")]
    public object? Content { get; init; }

    [JsonPropertyName("inheritDefault")]
    public bool? InheritDefault { get; init; }
}
