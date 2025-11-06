using System.Net.Http;
using Courier.Core;
using System = System;

namespace Courier.Models.Tenants;

/// <summary>
/// Get a Tenant
/// </summary>
public sealed record class TenantRetrieveParams : ParamsBase
{
    public required string TenantID;

    public override System::Uri Url(ICourierClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/tenants/{0}", this.TenantID)
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
