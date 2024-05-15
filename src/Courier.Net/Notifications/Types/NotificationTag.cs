using System.Text.Json.Serialization;
using Courier.Net;

namespace Courier.Net;

public class NotificationTag
{
    [JsonPropertyName("data")]
    public List<NotificationTagData> Data { get; init; }
}
