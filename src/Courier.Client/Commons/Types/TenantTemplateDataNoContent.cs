using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record TenantTemplateDataNoContent
{
    [JsonPropertyName("routing")]
    public required MessageRouting Routing { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
