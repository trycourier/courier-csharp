using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client;

[Serializable]
public record NotificationListParams
{
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// Retrieve the notes from the Notification template settings.
    /// </summary>
    [JsonIgnore]
    public bool? Notes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
