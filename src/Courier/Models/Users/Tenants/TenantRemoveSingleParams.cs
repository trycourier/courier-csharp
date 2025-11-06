using System.Net.Http;
using Courier.Core;
using System = System;

namespace Courier.Models.Users.Tenants;

/// <summary>
/// Removes a user from the supplied tenant.
/// </summary>
public sealed record class TenantRemoveSingleParams : ParamsBase
{
    public required string UserID;

    public required string TenantID;

    public override System::Uri Url(ICourierClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/users/{0}/tenants/{1}", this.UserID, this.TenantID)
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
