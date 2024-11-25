using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record GetSubscriptionForListRequest
{
    /// <summary>
    /// A unique identifier that allows for fetching the next set of list subscriptions
    /// </summary>
    public string? Cursor { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
