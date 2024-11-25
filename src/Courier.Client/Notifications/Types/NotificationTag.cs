using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record NotificationTag
{
    [JsonPropertyName("data")]
    public IEnumerable<NotificationTagData> Data { get; set; } = new List<NotificationTagData>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
