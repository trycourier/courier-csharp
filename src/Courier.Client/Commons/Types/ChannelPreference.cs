using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ChannelPreference
{
    [JsonPropertyName("channel")]
    public required ChannelClassification Channel { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
