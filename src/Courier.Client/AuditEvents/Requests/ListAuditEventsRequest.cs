namespace Courier.Client;

public record ListAuditEventsRequest
{
    /// <summary>
    /// A unique identifier that allows for fetching the next set of audit events.
    /// </summary>
    public string? Cursor { get; init; }
}
