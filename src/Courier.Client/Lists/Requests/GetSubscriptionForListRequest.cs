namespace Courier.Client;

public record GetSubscriptionForListRequest
{
    /// <summary>
    /// A unique identifier that allows for fetching the next set of list subscriptions
    /// </summary>
    public string? Cursor { get; init; }
}
