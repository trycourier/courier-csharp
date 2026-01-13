using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageRetrieveResponse, MessageRetrieveResponseFromRaw>))]
public sealed record class MessageRetrieveResponse : JsonModel
{
    /// <summary>
    /// A unique identifier associated with the message you wish to retrieve (results
    /// from a send).
    /// </summary>
    public required string ID
    {
        get { return this._rawData.GetNotNullClass<string>("id"); }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// A UTC timestamp at which the recipient clicked on a tracked link for the
    /// first time. Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Clicked
    {
        get { return this._rawData.GetNotNullStruct<long>("clicked"); }
        init { this._rawData.Set("clicked", value); }
    }

    /// <summary>
    /// A UTC timestamp at which the Integration provider delivered the message. Stored
    /// as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Delivered
    {
        get { return this._rawData.GetNotNullStruct<long>("delivered"); }
        init { this._rawData.Set("delivered", value); }
    }

    /// <summary>
    /// A UTC timestamp at which Courier received the message request. Stored as
    /// a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Enqueued
    {
        get { return this._rawData.GetNotNullStruct<long>("enqueued"); }
        init { this._rawData.Set("enqueued", value); }
    }

    /// <summary>
    /// A unique identifier associated with the event of the delivered message.
    /// </summary>
    public required string Event
    {
        get { return this._rawData.GetNotNullClass<string>("event"); }
        init { this._rawData.Set("event", value); }
    }

    /// <summary>
    /// A unique identifier associated with the notification of the delivered message.
    /// </summary>
    public required string Notification
    {
        get { return this._rawData.GetNotNullClass<string>("notification"); }
        init { this._rawData.Set("notification", value); }
    }

    /// <summary>
    /// A UTC timestamp at which the recipient opened a message for the first time.
    /// Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Opened
    {
        get { return this._rawData.GetNotNullStruct<long>("opened"); }
        init { this._rawData.Set("opened", value); }
    }

    /// <summary>
    /// A unique identifier associated with the recipient of the delivered message.
    /// </summary>
    public required string Recipient
    {
        get { return this._rawData.GetNotNullClass<string>("recipient"); }
        init { this._rawData.Set("recipient", value); }
    }

    /// <summary>
    /// A UTC timestamp at which Courier passed the message to the Integration provider.
    /// Stored as a millisecond representation of the Unix epoch.
    /// </summary>
    public required long Sent
    {
        get { return this._rawData.GetNotNullStruct<long>("sent"); }
        init { this._rawData.Set("sent", value); }
    }

    /// <summary>
    /// The current status of the message.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status"); }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A message describing the error that occurred.
    /// </summary>
    public string? Error
    {
        get { return this._rawData.GetNullableClass<string>("error"); }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// The reason for the current status of the message.
    /// </summary>
    public ApiEnum<string, Reason>? Reason
    {
        get { return this._rawData.GetNullableClass<ApiEnum<string, Reason>>("reason"); }
        init { this._rawData.Set("reason", value); }
    }

    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? Providers
    {
        get
        {
            return this._rawData.GetNullableStruct<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >("providers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "providers",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(
                            value,
                            (item) => FrozenDictionary.ToFrozenDictionary(item)
                        )
                    )
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
        _ = this.Providers;
    }

    public MessageRetrieveResponse() { }

    public MessageRetrieveResponse(MessageRetrieveResponse messageRetrieveResponse)
        : base(messageRetrieveResponse) { }

    public MessageRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MessageRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageRetrieveResponseFromRaw : IFromRawJson<MessageRetrieveResponse>
{
    /// <inheritdoc/>
    public MessageRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Courier.Models.Messages.IntersectionMember1,
        global::Courier.Models.Messages.IntersectionMember1FromRaw
    >)
)]
public sealed record class IntersectionMember1 : JsonModel
{
    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? Providers
    {
        get
        {
            return this._rawData.GetNullableStruct<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >("providers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "providers",
                value == null
                    ? null
                    : ImmutableArray.ToImmutableArray(
                        Enumerable.Select(
                            value,
                            (item) => FrozenDictionary.ToFrozenDictionary(item)
                        )
                    )
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Providers;
    }

    public IntersectionMember1() { }

    public IntersectionMember1(
        global::Courier.Models.Messages.IntersectionMember1 intersectionMember1
    )
        : base(intersectionMember1) { }

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Courier.Models.Messages.IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static global::Courier.Models.Messages.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntersectionMember1FromRaw : IFromRawJson<global::Courier.Models.Messages.IntersectionMember1>
{
    /// <inheritdoc/>
    public global::Courier.Models.Messages.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Courier.Models.Messages.IntersectionMember1.FromRawUnchecked(rawData);
}
