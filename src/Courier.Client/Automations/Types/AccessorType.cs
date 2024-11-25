using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AccessorType
{
    [JsonPropertyName("$ref")]
    public required string Ref { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
