using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Lists.Subscriptions;

/// <summary>
/// Delete a subscription to a list by list ID and user ID.
/// </summary>
public sealed record class SubscriptionUnsubscribeUserParams : ParamsBase
{
    public required string ListID;

    public required string UserID;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/lists/{0}/subscriptions/{1}", this.ListID, this.UserID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ICourierClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
