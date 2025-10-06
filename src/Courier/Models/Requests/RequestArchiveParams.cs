using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Requests;

/// <summary>
/// Archive message
/// </summary>
public sealed record class RequestArchiveParams : ParamsBase
{
    public required string RequestID;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/requests/{0}/archive", this.RequestID)
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
