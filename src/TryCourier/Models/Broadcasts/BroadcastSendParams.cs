using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Broadcasts;

/// <summary>
/// Send a broadcast immediately to a list or audience. Publishes the broadcast template
/// first. Not allowed once the broadcast is sending or sent.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BroadcastSendParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? BroadcastID { get; init; }

    /// <summary>
    /// ID of the target list or audience.
    /// </summary>
    public required string RecipientID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("recipient_id");
        }
        init { this._rawBodyData.Set("recipient_id", value); }
    }

    /// <summary>
    /// Whether the broadcast targets a list or an audience.
    /// </summary>
    public required ApiEnum<string, BroadcastSendParamsRecipientType> RecipientType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, BroadcastSendParamsRecipientType>
            >("recipient_type");
        }
        init { this._rawBodyData.Set("recipient_type", value); }
    }

    public BroadcastSendParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BroadcastSendParams(BroadcastSendParams broadcastSendParams)
        : base(broadcastSendParams)
    {
        this.BroadcastID = broadcastSendParams.BroadcastID;

        this._rawBodyData = new(broadcastSendParams._rawBodyData);
    }
#pragma warning restore CS8618

    public BroadcastSendParams(
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
    BroadcastSendParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string broadcastID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.BroadcastID = broadcastID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BroadcastSendParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string broadcastID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            broadcastID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["BroadcastID"] = JsonSerializer.SerializeToElement(this.BroadcastID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(BroadcastSendParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.BroadcastID?.Equals(other.BroadcastID) ?? other.BroadcastID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/broadcasts/{0}/send", this.BroadcastID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
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

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Whether the broadcast targets a list or an audience.
/// </summary>
[JsonConverter(typeof(BroadcastSendParamsRecipientTypeConverter))]
public enum BroadcastSendParamsRecipientType
{
    List,
    Audience,
}

sealed class BroadcastSendParamsRecipientTypeConverter
    : JsonConverter<BroadcastSendParamsRecipientType>
{
    public override BroadcastSendParamsRecipientType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "list" => BroadcastSendParamsRecipientType.List,
            "audience" => BroadcastSendParamsRecipientType.Audience,
            _ => (BroadcastSendParamsRecipientType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BroadcastSendParamsRecipientType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BroadcastSendParamsRecipientType.List => "list",
                BroadcastSendParamsRecipientType.Audience => "audience",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
