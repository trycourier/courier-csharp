using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Tenants.TenantDefaultPreferences.Items;

/// <summary>
/// Create or Replace Default Preferences For Topic
/// </summary>
public sealed record class ItemUpdateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string TenantID;

    public required string TopicID;

    public required ApiEnum<
        string,
        global::Courier.Models.Tenants.TenantDefaultPreferences.Items.Status
    > Status
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<
                    string,
                    global::Courier.Models.Tenants.TenantDefaultPreferences.Items.Status
                >
            >(element, ModelBase.SerializerOptions);
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
    public List<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, ChannelClassification>>?>(
                element,
                ModelBase.SerializerOptions
            );
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

    public override System::Uri Url(ICourierClient client)
    {
        return new System::UriBuilder(
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

[JsonConverter(
    typeof(global::Courier.Models.Tenants.TenantDefaultPreferences.Items.StatusConverter)
)]
public enum Status
{
    OptedOut,
    OptedIn,
    Required,
}

sealed class StatusConverter
    : JsonConverter<global::Courier.Models.Tenants.TenantDefaultPreferences.Items.Status>
{
    public override global::Courier.Models.Tenants.TenantDefaultPreferences.Items.Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPTED_OUT" => global::Courier
                .Models
                .Tenants
                .TenantDefaultPreferences
                .Items
                .Status
                .OptedOut,
            "OPTED_IN" => global::Courier
                .Models
                .Tenants
                .TenantDefaultPreferences
                .Items
                .Status
                .OptedIn,
            "REQUIRED" => global::Courier
                .Models
                .Tenants
                .TenantDefaultPreferences
                .Items
                .Status
                .Required,
            _ => (global::Courier.Models.Tenants.TenantDefaultPreferences.Items.Status)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Courier.Models.Tenants.TenantDefaultPreferences.Items.Status value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Courier.Models.Tenants.TenantDefaultPreferences.Items.Status.OptedOut =>
                    "OPTED_OUT",
                global::Courier.Models.Tenants.TenantDefaultPreferences.Items.Status.OptedIn =>
                    "OPTED_IN",
                global::Courier.Models.Tenants.TenantDefaultPreferences.Items.Status.Required =>
                    "REQUIRED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
