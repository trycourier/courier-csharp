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
/// The delivery schedule and recipient targeting for a broadcast.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BroadcastSchedule, BroadcastScheduleFromRaw>))]
public sealed record class BroadcastSchedule : JsonModel
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
    public required ApiEnum<string, BroadcastScheduleRecipientType> RecipientType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BroadcastScheduleRecipientType>>(
                "recipient_type"
            );
        }
        init { this._rawData.Set("recipient_type", value); }
    }

    /// <summary>
    /// Wall-clock timestamp of the scheduled send, no timezone offset (e.g. "2026-07-21T20:00:00").
    /// </summary>
    public string? ScheduledTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("scheduled_to");
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
        init { this._rawData.Set("timezone", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecipientID;
        this.RecipientType.Validate();
        _ = this.ScheduledTo;
        _ = this.Timezone;
    }

    public BroadcastSchedule() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BroadcastSchedule(BroadcastSchedule broadcastSchedule)
        : base(broadcastSchedule) { }
#pragma warning restore CS8618

    public BroadcastSchedule(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BroadcastSchedule(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastScheduleFromRaw.FromRawUnchecked"/>
    public static BroadcastSchedule FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BroadcastScheduleFromRaw : IFromRawJson<BroadcastSchedule>
{
    /// <inheritdoc/>
    public BroadcastSchedule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BroadcastSchedule.FromRawUnchecked(rawData);
}

/// <summary>
/// Whether the broadcast targets a list or an audience.
/// </summary>
[JsonConverter(typeof(BroadcastScheduleRecipientTypeConverter))]
public enum BroadcastScheduleRecipientType
{
    List,
    Audience,
}

sealed class BroadcastScheduleRecipientTypeConverter : JsonConverter<BroadcastScheduleRecipientType>
{
    public override BroadcastScheduleRecipientType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "list" => BroadcastScheduleRecipientType.List,
            "audience" => BroadcastScheduleRecipientType.Audience,
            _ => (BroadcastScheduleRecipientType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BroadcastScheduleRecipientType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BroadcastScheduleRecipientType.List => "list",
                BroadcastScheduleRecipientType.Audience => "audience",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
