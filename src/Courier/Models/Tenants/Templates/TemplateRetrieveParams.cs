using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Tenants.Templates;

/// <summary>
/// Get a Template in Tenant
/// </summary>
public sealed record class TemplateRetrieveParams : ParamsBase
{
    public required string TenantID;

    public required string TemplateID;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/tenants/{0}/templates/{1}", this.TenantID, this.TemplateID)
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
