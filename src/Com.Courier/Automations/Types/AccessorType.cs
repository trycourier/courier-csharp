using System.Text.Json.Serialization;

#nullable enable

namespace Com.Courier;

public record AccessorType
{
    [JsonPropertyName("$ref")]
    public required string Ref { get; init; }
}
