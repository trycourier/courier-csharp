using System.Text.Json.Serialization;
using Com.Courier;

#nullable enable

namespace Com.Courier;

public record NotificationTag
{
    [JsonPropertyName("data")]
    public IEnumerable<NotificationTagData> Data { get; init; } = new List<NotificationTagData>();
}
