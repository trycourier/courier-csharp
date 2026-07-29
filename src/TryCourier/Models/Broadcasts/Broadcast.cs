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
/// A broadcast — a single-channel message delivered to a known set of recipients
/// (a list or audience).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Broadcast, BroadcastFromRaw>))]
public sealed record class Broadcast : JsonModel
{
    /// <summary>
    /// The broadcast ID (bst_ prefix).
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The broadcast's delivery channel.
    /// </summary>
    public required ApiEnum<string, BroadcastChannel> Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BroadcastChannel>>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp when the broadcast was created.
    /// </summary>
    public required string CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Actor that created the broadcast.
    /// </summary>
    public required string CreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("created_by");
        }
        init { this._rawData.Set("created_by", value); }
    }

    /// <summary>
    /// Human-readable name.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Lifecycle status of the broadcast.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp of the last update.
    /// </summary>
    public required string UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Actor that last updated the broadcast.
    /// </summary>
    public required string UpdatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("updated_by");
        }
        init { this._rawData.Set("updated_by", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp when the broadcast was archived, if archived.
    /// </summary>
    public string? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("archived_at");
        }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <summary>
    /// Actor that archived the broadcast, if archived.
    /// </summary>
    public string? ArchivedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("archived_by");
        }
        init { this._rawData.Set("archived_by", value); }
    }

    /// <summary>
    /// The delivery schedule and recipient targeting for a broadcast.
    /// </summary>
    public BroadcastSchedule? Schedule
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BroadcastSchedule>("schedule");
        }
        init { this._rawData.Set("schedule", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Channel.Validate();
        _ = this.CreatedAt;
        _ = this.CreatedBy;
        _ = this.Name;
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.UpdatedBy;
        _ = this.ArchivedAt;
        _ = this.ArchivedBy;
        this.Schedule?.Validate();
    }

    public Broadcast() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Broadcast(Broadcast broadcast)
        : base(broadcast) { }
#pragma warning restore CS8618

    public Broadcast(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Broadcast(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastFromRaw.FromRawUnchecked"/>
    public static Broadcast FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BroadcastFromRaw : IFromRawJson<Broadcast>
{
    /// <inheritdoc/>
    public Broadcast FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Broadcast.FromRawUnchecked(rawData);
}

/// <summary>
/// The broadcast's delivery channel.
/// </summary>
[JsonConverter(typeof(BroadcastChannelConverter))]
public enum BroadcastChannel
{
    Email,
    Sms,
    Push,
    Inbox,
    Slack,
    Msteams,
}

sealed class BroadcastChannelConverter : JsonConverter<BroadcastChannel>
{
    public override BroadcastChannel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email" => BroadcastChannel.Email,
            "sms" => BroadcastChannel.Sms,
            "push" => BroadcastChannel.Push,
            "inbox" => BroadcastChannel.Inbox,
            "slack" => BroadcastChannel.Slack,
            "msteams" => BroadcastChannel.Msteams,
            _ => (BroadcastChannel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BroadcastChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BroadcastChannel.Email => "email",
                BroadcastChannel.Sms => "sms",
                BroadcastChannel.Push => "push",
                BroadcastChannel.Inbox => "inbox",
                BroadcastChannel.Slack => "slack",
                BroadcastChannel.Msteams => "msteams",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Lifecycle status of the broadcast.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Draft,
    Scheduled,
    Sending,
    Sent,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft" => Status.Draft,
            "scheduled" => Status.Scheduled,
            "sending" => Status.Sending,
            "sent" => Status.Sent,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Draft => "draft",
                Status.Scheduled => "scheduled",
                Status.Sending => "sending",
                Status.Sent => "sent",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
