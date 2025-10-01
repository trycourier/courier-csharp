using System;
using System.Net.Http;
using System.Text.Json;
using Courier.Core;

namespace Courier.Models.Users.Preferences;

/// <summary>
/// Fetch all user preferences.
/// </summary>
public sealed record class PreferenceRetrieveParams : ParamsBase
{
    public required string UserID;

    /// <summary>
    /// Query the preferences of a user for this specific tenant context.
    /// </summary>
    public string? TenantID
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("tenant_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["tenant_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/users/{0}/preferences", this.UserID)
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
