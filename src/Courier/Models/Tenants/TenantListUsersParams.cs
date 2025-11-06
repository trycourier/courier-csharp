using System.Net.Http;
using System.Text.Json;
using Courier.Core;
using System = System;

namespace Courier.Models.Tenants;

/// <summary>
/// Get Users in Tenant
/// </summary>
public sealed record class TenantListUsersParams : ParamsBase
{
    public required string TenantID;

    /// <summary>
    /// Continue the pagination with the next cursor
    /// </summary>
    public string? Cursor
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["cursor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of accounts to return  (defaults to 20, maximum value of 100)
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override System::Uri Url(ICourierClient client)
    {
        return new System::UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/tenants/{0}/users", this.TenantID)
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
