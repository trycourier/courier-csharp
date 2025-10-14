using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Bulk;

/// <summary>
/// Run a bulk job
/// </summary>
public sealed record class BulkRunJobParams : ParamsBase
{
    public required string JobID;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/bulk/{0}/run", this.JobID)
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
