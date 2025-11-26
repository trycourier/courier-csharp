using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Messages;

[JsonConverter(typeof(ModelConverter<MessageRetrieveResponse, MessageRetrieveResponseFromRaw>))]
public sealed record class MessageRetrieveResponse : ModelBase
{
    /// <summary>
    /// A unique identifier associated with the message you wish to retrieve (results
    /// from a send).
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A UTC timestamp at which the recipient clicked on a tracked link for the
    /// first time. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Clicked
    {
        get
        {
            if (!this._rawData.TryGetValue("clicked", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'clicked' cannot be null",
                    new ArgumentOutOfRangeException("clicked", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["clicked"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A UTC timestamp at which the Integration provider delivered the message. Stored
    /// as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Delivered
    {
        get
        {
            if (!this._rawData.TryGetValue("delivered", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'delivered' cannot be null",
                    new ArgumentOutOfRangeException("delivered", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["delivered"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A UTC timestamp at which Courier received the message request. Stored as
    /// a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Enqueued
    {
        get
        {
            if (!this._rawData.TryGetValue("enqueued", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'enqueued' cannot be null",
                    new ArgumentOutOfRangeException("enqueued", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["enqueued"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("event", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'event' cannot be null",
                    new ArgumentOutOfRangeException("event", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'event' cannot be null",
                    new ArgumentNullException("event")
                );
        }
        init
        {
            this._rawData["event"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("notification", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'notification' cannot be null",
                    new ArgumentOutOfRangeException("notification", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'notification' cannot be null",
                    new ArgumentNullException("notification")
                );
        }
        init
        {
            this._rawData["notification"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("opened", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'opened' cannot be null",
                    new ArgumentOutOfRangeException("opened", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["opened"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("recipient", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'recipient' cannot be null",
                    new ArgumentOutOfRangeException("recipient", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'recipient' cannot be null",
                    new ArgumentNullException("recipient")
                );
        }
        init
        {
            this._rawData["recipient"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("sent", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'sent' cannot be null",
                    new ArgumentOutOfRangeException("sent", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["sent"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("error", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["error"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Reason>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<Dictionary<string, JsonElement>>? Providers
    {
        get
        {
            if (!this._rawData.TryGetValue("providers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["providers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator MessageDetails(
        MessageRetrieveResponse messageRetrieveResponse
    ) =>
        new()
        {
            ID = messageRetrieveResponse.ID,
            Clicked = messageRetrieveResponse.Clicked,
            Delivered = messageRetrieveResponse.Delivered,
            Enqueued = messageRetrieveResponse.Enqueued,
            Event = messageRetrieveResponse.Event,
            Notification = messageRetrieveResponse.Notification,
            Opened = messageRetrieveResponse.Opened,
            Recipient = messageRetrieveResponse.Recipient,
            Sent = messageRetrieveResponse.Sent,
            Status = messageRetrieveResponse.Status,
            Error = messageRetrieveResponse.Error,
            Reason = messageRetrieveResponse.Reason,
        };

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
        _ = this.Providers;
    }

    public MessageRetrieveResponse() { }

    public MessageRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static MessageRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageRetrieveResponseFromRaw : IFromRaw<MessageRetrieveResponse>
{
    public MessageRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        global::Courier.Models.Messages.IntersectionMember1,
        global::Courier.Models.Messages.IntersectionMember1FromRaw
    >)
)]
public sealed record class IntersectionMember1 : ModelBase
{
    public List<Dictionary<string, JsonElement>>? Providers
    {
        get
        {
            if (!this._rawData.TryGetValue("providers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["providers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Providers;
    }

    public IntersectionMember1() { }

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Courier.Models.Messages.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntersectionMember1FromRaw : IFromRaw<global::Courier.Models.Messages.IntersectionMember1>
{
    public global::Courier.Models.Messages.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Courier.Models.Messages.IntersectionMember1.FromRawUnchecked(rawData);
}
