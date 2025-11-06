using System.Net.Http;
using Courier.Core;
using System = System;

namespace Courier.Models.Users.Tenants;

/// <summary>
/// Removes a user from any tenants they may have been associated with.
/// </summary>
public sealed record class TenantRemoveAllParams : ParamsBase
{
    public required string UserID;

    public override System::Uri Url(ICourierClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/users/{0}/tenants", this.UserID)
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
