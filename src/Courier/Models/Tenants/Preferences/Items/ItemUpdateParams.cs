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
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string TenantID { get; init; }

    public string? TopicID { get; init; }

    public required ApiEnum<string, global::Courier.Models.Tenants.Preferences.Items.Status> Status
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::Courier.Models.Tenants.Preferences.Items.Status>
            >(this.RawBodyData, "status");
        }
        init { JsonModel.Set(this._rawBodyData, "status", value); }
    }

    /// <summary>
    /// The default channels to send to this tenant when has_custom_routing is enabled
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            return JsonModel.GetNullableClass<List<ApiEnum<string, ChannelClassification>>>(
                this.RawBodyData,
                "custom_routing"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "custom_routing", value); }
    }

    /// <summary>
    /// Override channel routing with custom preferences. This will override any
    /// template prefernces that are set, but a user can still customize their preferences
    /// </summary>
    public bool? HasCustomRouting
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "has_custom_routing"); }
        init { JsonModel.Set(this._rawBodyData, "has_custom_routing", value); }
    }

    public ItemUpdateParams() { }

    public ItemUpdateParams(ItemUpdateParams itemUpdateParams)
        : base(itemUpdateParams)
    {
        this._rawBodyData = [.. itemUpdateParams._rawBodyData];
    }

    public ItemUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static ItemUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
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

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
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
