using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record NotificationListParams
{
    public string? Cursor { get; set; }

    /// <summary>
    /// Retrieve the notes from the Notification template settings.
    /// </summary>
    public bool? Notes { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
