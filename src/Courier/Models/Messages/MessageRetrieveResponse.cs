using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

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
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// A UTC timestamp at which the recipient clicked on a tracked link for the
    /// first time. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Clicked
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "clicked"); }
        init { ModelBase.Set(this._rawData, "clicked", value); }
    }

    /// <summary>
    /// A UTC timestamp at which the Integration provider delivered the message. Stored
    /// as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Delivered
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "delivered"); }
        init { ModelBase.Set(this._rawData, "delivered", value); }
    }

    /// <summary>
    /// A UTC timestamp at which Courier received the message request. Stored as
    /// a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Enqueued
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "enqueued"); }
        init { ModelBase.Set(this._rawData, "enqueued", value); }
    }

    /// <summary>
    /// A unique identifier associated with the event of the delivered message.
    /// </summary>
    public required string Event
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "event"); }
        init { ModelBase.Set(this._rawData, "event", value); }
    }

    /// <summary>
    /// A unique identifier associated with the notification of the delivered message.
    /// </summary>
    public required string Notification
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "notification"); }
        init { ModelBase.Set(this._rawData, "notification", value); }
    }

    /// <summary>
    /// A UTC timestamp at which the recipient opened a message for the first time.
    /// Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Opened
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "opened"); }
        init { ModelBase.Set(this._rawData, "opened", value); }
    }

    /// <summary>
    /// A unique identifier associated with the recipient of the delivered message.
    /// </summary>
    public required string Recipient
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "recipient"); }
        init { ModelBase.Set(this._rawData, "recipient", value); }
    }

    /// <summary>
    /// A UTC timestamp at which Courier passed the message to the Integration provider.
    /// Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Sent
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "sent"); }
        init { ModelBase.Set(this._rawData, "sent", value); }
    }

    /// <summary>
    /// The current status of the message.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<string, Status>>(this.RawData, "status"); }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// A message describing the error that occurred.
    /// </summary>
    public string? Error
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "error"); }
        init { ModelBase.Set(this._rawData, "error", value); }
    }

    /// <summary>
    /// The reason for the current status of the message.
    /// </summary>
    public ApiEnum<string, Reason>? Reason
    {
        get { return ModelBase.GetNullableClass<ApiEnum<string, Reason>>(this.RawData, "reason"); }
        init { ModelBase.Set(this._rawData, "reason", value); }
    }

    public IReadOnlyList<Dictionary<string, JsonElement>>? Providers
    {
        get
        {
            return ModelBase.GetNullableClass<List<Dictionary<string, JsonElement>>>(
                this.RawData,
                "providers"
            );
        }
        init { ModelBase.Set(this._rawData, "providers", value); }
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
    public IReadOnlyList<Dictionary<string, JsonElement>>? Providers
    {
        get
        {
            return ModelBase.GetNullableClass<List<Dictionary<string, JsonElement>>>(
                this.RawData,
                "providers"
            );
        }
        init { ModelBase.Set(this._rawData, "providers", value); }
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
