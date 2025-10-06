using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Brands;

/// <summary>
/// Delete a brand by brand ID.
/// </summary>
public sealed record class BrandDeleteParams : ParamsBase
{
    public required string BrandID;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/brands/{0}", this.BrandID)
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
