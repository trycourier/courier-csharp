using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Tenants.DefaultPreferences.Items.ItemUpdateParamsProperties;
using Generic = System.Collections.Generic;

namespace Courier.Models.Tenants.DefaultPreferences.Items;

/// <summary>
/// Create or Replace Default Preferences For Topic
/// </summary>
public sealed record class ItemUpdateParams : ParamsBase
{
    public Generic::Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string TenantID;

    public required string TopicID;

    public required ApiEnum<string, Status> Status
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.BodyProperties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The default channels to send to this tenant when has_custom_routing is enabled
    /// </summary>
    public Generic::List<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Generic::List<
                ApiEnum<string, ChannelClassification>
            >?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["custom_routing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Override channel routing with custom preferences. This will override any template
    /// prefernces that are set, but a user can still customize their preferences
    /// </summary>
    public bool? HasCustomRouting
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("has_custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["has_custom_routing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
