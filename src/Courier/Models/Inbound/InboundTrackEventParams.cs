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
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
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
        get { return JsonModel.GetNotNullClass<string>(this.RawBodyData, "event"); }
        init { JsonModel.Set(this._rawBodyData, "event", value); }
    }

    /// <summary>
    /// A required unique identifier that will be used to de-duplicate requests. If
    /// not unique, will respond with 409 Conflict status
    /// </summary>
    public required string MessageID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawBodyData, "messageId"); }
        init { JsonModel.Set(this._rawBodyData, "messageId", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> Properties
    {
        get
        {
            return JsonModel.GetNotNullClass<Dictionary<string, JsonElement>>(
                this.RawBodyData,
                "properties"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "properties", value); }
    }

    public required ApiEnum<string, global::Courier.Models.Inbound.Type> Type
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, global::Courier.Models.Inbound.Type>>(
                this.RawBodyData,
                "type"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "type", value); }
    }

    /// <summary>
    /// The user id associatiated with the track
    /// </summary>
    public string? UserID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "userId"); }
        init { JsonModel.Set(this._rawBodyData, "userId", value); }
    }

    public InboundTrackEventParams() { }

    public InboundTrackEventParams(InboundTrackEventParams inboundTrackEventParams)
        : base(inboundTrackEventParams)
    {
        this._rawBodyData = [.. inboundTrackEventParams._rawBodyData];
    }

    public InboundTrackEventParams(
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
    InboundTrackEventParams(
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
