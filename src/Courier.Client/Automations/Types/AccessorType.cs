using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client;

public record AccessorType
{
    [JsonPropertyName("$ref")]
    public required string Ref { get; init; }
}
