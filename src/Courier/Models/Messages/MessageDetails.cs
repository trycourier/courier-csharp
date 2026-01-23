using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageDetails, MessageDetailsFromRaw>))]
public sealed record class MessageDetails : JsonModel
{
    /// <summary>
    /// A unique identifier associated with the message you wish to retrieve (results
    /// from a send).
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
    /// A UTC timestamp at which the recipient clicked on a tracked link for the
    /// first time. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Clicked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("clicked");
        }
        init { this._rawData.Set("clicked", value); }
    }

    /// <summary>
    /// A UTC timestamp at which the Integration provider delivered the message. Stored
    /// as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Delivered
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("delivered");
        }
        init { this._rawData.Set("delivered", value); }
    }

    /// <summary>
    /// A UTC timestamp at which Courier received the message request. Stored as
    /// a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Enqueued
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("enqueued");
        }
        init { this._rawData.Set("enqueued", value); }
    }

    /// <summary>
    /// A unique identifier associated with the event of the delivered message.
    /// </summary>
    public required string Event
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event");
        }
        init { this._rawData.Set("event", value); }
    }

    /// <summary>
    /// A unique identifier associated with the notification of the delivered message.
    /// </summary>
    public required string Notification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("notification");
        }
        init { this._rawData.Set("notification", value); }
    }

    /// <summary>
    /// A UTC timestamp at which the recipient opened a message for the first time.
    /// Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Opened
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("opened");
        }
        init { this._rawData.Set("opened", value); }
    }

    /// <summary>
    /// A unique identifier associated with the recipient of the delivered message.
    /// </summary>
    public required string Recipient
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("recipient");
        }
        init { this._rawData.Set("recipient", value); }
    }

    /// <summary>
    /// A UTC timestamp at which Courier passed the message to the Integration provider.
    /// Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Sent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("sent");
        }
        init { this._rawData.Set("sent", value); }
    }

    /// <summary>
    /// The current status of the message.
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
    /// A message describing the error that occurred.
    /// </summary>
    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// The reason for the current status of the message.
    /// </summary>
    public ApiEnum<string, Reason>? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Reason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Clicked;
        _ = this.Delivered;
        _ = this.Enqueued;
        _ = this.Event;
        _ = this.Notification;
        _ = this.Opened;
        _ = this.Recipient;
        _ = this.Sent;
        this.Status.Validate();
        _ = this.Error;
        this.Reason?.Validate();
    }

    public MessageDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageDetails(MessageDetails messageDetails)
        : base(messageDetails) { }
#pragma warning restore CS8618

    public MessageDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageDetailsFromRaw.FromRawUnchecked"/>
    public static MessageDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageDetailsFromRaw : IFromRawJson<MessageDetails>
{
    /// <inheritdoc/>
    public MessageDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// The current status of the message.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Canceled,
    Clicked,
    Delayed,
    Delivered,
    Digested,
    Enqueued,
    Filtered,
    Opened,
    Routed,
    Sent,
    Simulated,
    Throttled,
    Undeliverable,
    Unmapped,
    Unroutable,
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
            "CANCELED" => Status.Canceled,
            "CLICKED" => Status.Clicked,
            "DELAYED" => Status.Delayed,
            "DELIVERED" => Status.Delivered,
            "DIGESTED" => Status.Digested,
            "ENQUEUED" => Status.Enqueued,
            "FILTERED" => Status.Filtered,
            "OPENED" => Status.Opened,
            "ROUTED" => Status.Routed,
            "SENT" => Status.Sent,
            "SIMULATED" => Status.Simulated,
            "THROTTLED" => Status.Throttled,
            "UNDELIVERABLE" => Status.Undeliverable,
            "UNMAPPED" => Status.Unmapped,
            "UNROUTABLE" => Status.Unroutable,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Canceled => "CANCELED",
                Status.Clicked => "CLICKED",
                Status.Delayed => "DELAYED",
                Status.Delivered => "DELIVERED",
                Status.Digested => "DIGESTED",
                Status.Enqueued => "ENQUEUED",
                Status.Filtered => "FILTERED",
                Status.Opened => "OPENED",
                Status.Routed => "ROUTED",
                Status.Sent => "SENT",
                Status.Simulated => "SIMULATED",
                Status.Throttled => "THROTTLED",
                Status.Undeliverable => "UNDELIVERABLE",
                Status.Unmapped => "UNMAPPED",
                Status.Unroutable => "UNROUTABLE",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The reason for the current status of the message.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    Bounced,
    Failed,
    Filtered,
    NoChannels,
    NoProviders,
    OptInRequired,
    ProviderError,
    Unpublished,
    Unsubscribed,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BOUNCED" => Reason.Bounced,
            "FAILED" => Reason.Failed,
            "FILTERED" => Reason.Filtered,
            "NO_CHANNELS" => Reason.NoChannels,
            "NO_PROVIDERS" => Reason.NoProviders,
            "OPT_IN_REQUIRED" => Reason.OptInRequired,
            "PROVIDER_ERROR" => Reason.ProviderError,
            "UNPUBLISHED" => Reason.Unpublished,
            "UNSUBSCRIBED" => Reason.Unsubscribed,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.Bounced => "BOUNCED",
                Reason.Failed => "FAILED",
                Reason.Filtered => "FILTERED",
                Reason.NoChannels => "NO_CHANNELS",
                Reason.NoProviders => "NO_PROVIDERS",
                Reason.OptInRequired => "OPT_IN_REQUIRED",
                Reason.ProviderError => "PROVIDER_ERROR",
                Reason.Unpublished => "UNPUBLISHED",
                Reason.Unsubscribed => "UNSUBSCRIBED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
