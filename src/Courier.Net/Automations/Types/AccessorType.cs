using System.Text.Json.Serialization;

namespace Courier.Net;

public class AccessorType
{
    [JsonPropertyName("$ref")]
    public string Ref { get; init; }
}
