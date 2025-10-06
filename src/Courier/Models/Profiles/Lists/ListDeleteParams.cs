using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Profiles.Lists;

/// <summary>
/// Removes all list subscriptions for given user.
/// </summary>
public sealed record class ListDeleteParams : ParamsBase
{
    public required string UserID;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/profiles/{0}/lists", this.UserID)
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
