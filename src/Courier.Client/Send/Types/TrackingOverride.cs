using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record TrackingOverride
{
    [JsonPropertyName("open")]
    public required bool Open { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
