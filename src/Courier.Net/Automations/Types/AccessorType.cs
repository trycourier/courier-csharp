using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Net;

public record AccessorType
{
    [JsonPropertyName("$ref")]
    public required string Ref { get; init; }
}
