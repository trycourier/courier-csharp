using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Tenants.Preferences.Items;

/// <summary>
/// Create or Replace Default Preferences For Topic
/// </summary>
public sealed record class ItemUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public required string TenantID { get; init; }

    public required string TopicID { get; init; }

    public required ApiEnum<string, global::Courier.Models.Tenants.Preferences.Items.Status> Status
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Courier.Models.Tenants.Preferences.Items.Status>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["status"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, ChannelClassification>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["custom_routing"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("has_custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["has_custom_routing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ItemUpdateParams() { }

    public ItemUpdateParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemUpdateParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static ItemUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/tenants/{0}/default_preferences/items/{1}",
                    this.TenantID,
                    this.TopicID
                )
        )
        {
            Query = this.QueryString(options),
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

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(global::Courier.Models.Tenants.Preferences.Items.StatusConverter))]
public enum Status
{
    OptedOut,
    OptedIn,
    Required,
}

sealed class StatusConverter
    : JsonConverter<global::Courier.Models.Tenants.Preferences.Items.Status>
{
    public override global::Courier.Models.Tenants.Preferences.Items.Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPTED_OUT" => global::Courier.Models.Tenants.Preferences.Items.Status.OptedOut,
            "OPTED_IN" => global::Courier.Models.Tenants.Preferences.Items.Status.OptedIn,
            "REQUIRED" => global::Courier.Models.Tenants.Preferences.Items.Status.Required,
            _ => (global::Courier.Models.Tenants.Preferences.Items.Status)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Courier.Models.Tenants.Preferences.Items.Status value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Courier.Models.Tenants.Preferences.Items.Status.OptedOut => "OPTED_OUT",
                global::Courier.Models.Tenants.Preferences.Items.Status.OptedIn => "OPTED_IN",
                global::Courier.Models.Tenants.Preferences.Items.Status.Required => "REQUIRED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
