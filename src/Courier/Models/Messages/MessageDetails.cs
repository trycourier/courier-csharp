using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Messages;

[JsonConverter(typeof(ModelConverter<MessageDetails>))]
public sealed record class MessageDetails : ModelBase, IFromRaw<MessageDetails>
{
    /// <summary>
    /// A unique identifier associated with the message you wish to retrieve (results
    /// from a send).
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A UTC timestamp at which the recipient clicked on a tracked link for the first
    /// time. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Clicked
    {
        get
        {
            if (!this.Properties.TryGetValue("clicked", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'clicked' cannot be null",
                    new System::ArgumentOutOfRangeException("clicked", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["clicked"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A UTC timestamp at which the Integration provider delivered the message.
    /// Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Delivered
    {
        get
        {
            if (!this.Properties.TryGetValue("delivered", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'delivered' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "delivered",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["delivered"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A UTC timestamp at which Courier received the message request. Stored as a
    /// millisecond representation of the Unix epoch.
    /// </summary>
    public required long Enqueued
    {
        get
        {
            if (!this.Properties.TryGetValue("enqueued", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'enqueued' cannot be null",
                    new System::ArgumentOutOfRangeException("enqueued", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["enqueued"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A unique identifier associated with the event of the delivered message.
    /// </summary>
    public required string Event
    {
        get
        {
            if (!this.Properties.TryGetValue("event", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'event' cannot be null",
                    new System::ArgumentOutOfRangeException("event", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'event' cannot be null",
                    new System::ArgumentNullException("event")
                );
        }
        set
        {
            this.Properties["event"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A unique identifier associated with the notification of the delivered message.
    /// </summary>
    public required string Notification
    {
        get
        {
            if (!this.Properties.TryGetValue("notification", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'notification' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "notification",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'notification' cannot be null",
                    new System::ArgumentNullException("notification")
                );
        }
        set
        {
            this.Properties["notification"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A UTC timestamp at which the recipient opened a message for the first time.
    /// Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Opened
    {
        get
        {
            if (!this.Properties.TryGetValue("opened", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'opened' cannot be null",
                    new System::ArgumentOutOfRangeException("opened", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["opened"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A unique identifier associated with the recipient of the delivered message.
    /// </summary>
    public required string Recipient
    {
        get
        {
            if (!this.Properties.TryGetValue("recipient", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'recipient' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "recipient",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'recipient' cannot be null",
                    new System::ArgumentNullException("recipient")
                );
        }
        set
        {
            this.Properties["recipient"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A UTC timestamp at which Courier passed the message to the Integration provider.
    /// Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Sent
    {
        get
        {
            if (!this.Properties.TryGetValue("sent", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'sent' cannot be null",
                    new System::ArgumentOutOfRangeException("sent", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["sent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The current status of the message.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A message describing the error that occurred.
    /// </summary>
    public string? Error
    {
        get
        {
            if (!this.Properties.TryGetValue("error", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["error"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The reason for the current status of the message.
    /// </summary>
    public ApiEnum<string, Reason>? Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Reason>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
    MessageDetails(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageDetails FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
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
