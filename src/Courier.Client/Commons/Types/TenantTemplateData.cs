using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record TenantTemplateData
{
    [JsonPropertyName("routing")]
    public required MessageRouting Routing { get; set; }

    [JsonPropertyName("content")]
    public required ElementalContent Content { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
