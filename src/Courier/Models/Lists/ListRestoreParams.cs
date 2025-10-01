using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Lists;

/// <summary>
/// Restore a previously deleted list.
/// </summary>
public sealed record class ListRestoreParams : ParamsBase
{
    public required string ListID;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/lists/{0}/restore", this.ListID)
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
