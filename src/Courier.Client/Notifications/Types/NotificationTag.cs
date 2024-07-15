using System.Text.Json.Serialization;
using Courier.Client;

#nullable enable

namespace Courier.Client;

public record NotificationTag
{
    [JsonPropertyName("data")]
    public IEnumerable<NotificationTagData> Data { get; init; } = new List<NotificationTagData>();
}
