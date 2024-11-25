using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ListAuditEventsRequest
{
    /// <summary>
    /// A unique identifier that allows for fetching the next set of audit events.
    /// </summary>
    public string? Cursor { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
