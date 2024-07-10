using System.Text.Json.Serialization;
using Courier.Net;

#nullable enable

namespace Courier.Net;

public record NotificationTag
{
    [JsonPropertyName("data")]
    public IEnumerable<NotificationTagData> Data { get; init; } = new List<NotificationTagData>();
}
