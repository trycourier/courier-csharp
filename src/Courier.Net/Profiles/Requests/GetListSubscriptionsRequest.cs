namespace Courier.Net;

public record GetListSubscriptionsRequest
{
    /// <summary>
    /// A unique identifier that allows for fetching the next set of message statuses.
    /// </summary>
    public string? Cursor { get; init; }
}
