using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record AirshipProfileAudience
{
    [JsonPropertyName("named_user")]
    public required string NamedUser { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
