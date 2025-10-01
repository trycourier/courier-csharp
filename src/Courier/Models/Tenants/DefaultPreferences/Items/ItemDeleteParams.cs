using System;
using System.Net.Http;
using Courier.Core;

namespace Courier.Models.Tenants.DefaultPreferences.Items;

/// <summary>
/// Remove Default Preferences For Topic
/// </summary>
public sealed record class ItemDeleteParams : ParamsBase
{
    public required string TenantID;

    public required string TopicID;

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/tenants/{0}/default_preferences/items/{1}",
                    this.TenantID,
                    this.TopicID
                )
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
