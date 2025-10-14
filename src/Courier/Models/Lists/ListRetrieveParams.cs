using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Lists;

/// <summary>
/// Returns a list based on the list ID provided.
/// </summary>
public sealed record class ListRetrieveParams : ParamsBase
{
    public required string ListID;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/lists/{0}", this.ListID)
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
