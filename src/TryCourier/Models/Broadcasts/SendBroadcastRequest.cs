using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Broadcasts;

/// <summary>
/// Request body for sending a broadcast immediately.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SendBroadcastRequest, SendBroadcastRequestFromRaw>))]
public sealed record class SendBroadcastRequest : JsonModel
{
    /// <summary>
    /// ID of the target list or audience.
    /// </summary>
    public required string RecipientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("recipient_id");
        }
        init { this._rawData.Set("recipient_id", value); }
    }

    /// <summary>
    /// Whether the broadcast targets a list or an audience.
    /// </summary>
    public required ApiEnum<string, SendBroadcastRequestRecipientType> RecipientType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SendBroadcastRequestRecipientType>
            >("recipient_type");
        }
        init { this._rawData.Set("recipient_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecipientID;
        this.RecipientType.Validate();
    }

    public SendBroadcastRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SendBroadcastRequest(SendBroadcastRequest sendBroadcastRequest)
        : base(sendBroadcastRequest) { }
#pragma warning restore CS8618

    public SendBroadcastRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendBroadcastRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SendBroadcastRequestFromRaw.FromRawUnchecked"/>
    public static SendBroadcastRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SendBroadcastRequestFromRaw : IFromRawJson<SendBroadcastRequest>
{
    /// <inheritdoc/>
    public SendBroadcastRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SendBroadcastRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the broadcast targets a list or an audience.
/// </summary>
[JsonConverter(typeof(SendBroadcastRequestRecipientTypeConverter))]
public enum SendBroadcastRequestRecipientType
{
    List,
    Audience,
}

sealed class SendBroadcastRequestRecipientTypeConverter
    : JsonConverter<SendBroadcastRequestRecipientType>
{
    public override SendBroadcastRequestRecipientType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "list" => SendBroadcastRequestRecipientType.List,
            "audience" => SendBroadcastRequestRecipientType.Audience,
            _ => (SendBroadcastRequestRecipientType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SendBroadcastRequestRecipientType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SendBroadcastRequestRecipientType.List => "list",
                SendBroadcastRequestRecipientType.Audience => "audience",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
