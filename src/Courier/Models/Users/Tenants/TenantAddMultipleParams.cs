using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Users.Tenants;

/// <summary>
/// This endpoint is used to add a user to multiple tenants in one call. A custom
/// profile can also be supplied for each tenant.  This profile will be merged with
/// the user's main  profile when sending to the user with that tenant.
/// </summary>
public sealed record class TenantAddMultipleParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string UserID;

    public required List<TenantAssociation> Tenants
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("tenants", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'tenants' cannot be null",
                    new ArgumentOutOfRangeException("tenants", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<TenantAssociation>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'tenants' cannot be null",
                    new ArgumentNullException("tenants")
                );
        }
        set
        {
            this.BodyProperties["tenants"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(ICourierClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/users/{0}/tenants", this.UserID)
        )
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
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
