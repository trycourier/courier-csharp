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

namespace Courier.Models.Inbound;

/// <summary>
/// Courier Track Event
/// </summary>
public sealed record class InboundTrackEventParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// A descriptive name of the event. This name will appear as a trigger in the
    /// Courier Automation Trigger node.
    /// </summary>
    public required string Event
    {
        get { return this._rawBodyData.GetNotNullClass<string>("event"); }
        init { this._rawBodyData.Set("event", value); }
    }

    /// <summary>
    /// A required unique identifier that will be used to de-duplicate requests. If
    /// not unique, will respond with 409 Conflict status
    /// </summary>
    public required string MessageID
    {
        get { return this._rawBodyData.GetNotNullClass<string>("messageId"); }
        init { this._rawBodyData.Set("messageId", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> Properties
    {
        get
        {
            return this._rawBodyData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "properties"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>>(
                "properties",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required ApiEnum<string, global::Courier.Models.Inbound.Type> Type
    {
        get
        {
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, global::Courier.Models.Inbound.Type>
            >("type");
        }
        init { this._rawBodyData.Set("type", value); }
    }

    /// <summary>
    /// The user id associated with the track
    /// </summary>
    public string? UserID
    {
        get { return this._rawBodyData.GetNullableClass<string>("userId"); }
        init { this._rawBodyData.Set("userId", value); }
    }

    public InboundTrackEventParams() { }

    public InboundTrackEventParams(InboundTrackEventParams inboundTrackEventParams)
        : base(inboundTrackEventParams)
    {
        this._rawBodyData = new(inboundTrackEventParams._rawBodyData);
    }

    public InboundTrackEventParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundTrackEventParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static InboundTrackEventParams FromRawUnchecked(
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/inbound/courier")
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

[JsonConverter(typeof(global::Courier.Models.Inbound.TypeConverter))]
public enum Type
{
    Track,
}

sealed class TypeConverter : JsonConverter<global::Courier.Models.Inbound.Type>
{
    public override global::Courier.Models.Inbound.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "track" => global::Courier.Models.Inbound.Type.Track,
            _ => (global::Courier.Models.Inbound.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Courier.Models.Inbound.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Courier.Models.Inbound.Type.Track => "track",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
