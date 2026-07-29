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
/// Request body for scheduling a broadcast for a future send.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ScheduleBroadcastRequest, ScheduleBroadcastRequestFromRaw>)
)]
public sealed record class ScheduleBroadcastRequest : JsonModel
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
    public required ApiEnum<string, ScheduleBroadcastRequestRecipientType> RecipientType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ScheduleBroadcastRequestRecipientType>
            >("recipient_type");
        }
        init { this._rawData.Set("recipient_type", value); }
    }

    /// <summary>
    /// Wall-clock timestamp of the future send, no timezone offset (e.g. "2026-07-21T20:00:00").
    /// The zone is given by `timezone`.
    /// </summary>
    public required string ScheduledTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("scheduled_to");
        }
        init { this._rawData.Set("scheduled_to", value); }
    }

    /// <summary>
    /// IANA timezone for the scheduled send (e.g. America/New_York).
    /// </summary>
    public string? Timezone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("timezone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timezone", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecipientID;
        this.RecipientType.Validate();
        _ = this.ScheduledTo;
        _ = this.Timezone;
    }

    public ScheduleBroadcastRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScheduleBroadcastRequest(ScheduleBroadcastRequest scheduleBroadcastRequest)
        : base(scheduleBroadcastRequest) { }
#pragma warning restore CS8618

    public ScheduleBroadcastRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ScheduleBroadcastRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ScheduleBroadcastRequestFromRaw.FromRawUnchecked"/>
    public static ScheduleBroadcastRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ScheduleBroadcastRequestFromRaw : IFromRawJson<ScheduleBroadcastRequest>
{
    /// <inheritdoc/>
    public ScheduleBroadcastRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ScheduleBroadcastRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the broadcast targets a list or an audience.
/// </summary>
[JsonConverter(typeof(ScheduleBroadcastRequestRecipientTypeConverter))]
public enum ScheduleBroadcastRequestRecipientType
{
    List,
    Audience,
}

sealed class ScheduleBroadcastRequestRecipientTypeConverter
    : JsonConverter<ScheduleBroadcastRequestRecipientType>
{
    public override ScheduleBroadcastRequestRecipientType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "list" => ScheduleBroadcastRequestRecipientType.List,
            "audience" => ScheduleBroadcastRequestRecipientType.Audience,
            _ => (ScheduleBroadcastRequestRecipientType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ScheduleBroadcastRequestRecipientType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ScheduleBroadcastRequestRecipientType.List => "list",
                ScheduleBroadcastRequestRecipientType.Audience => "audience",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
