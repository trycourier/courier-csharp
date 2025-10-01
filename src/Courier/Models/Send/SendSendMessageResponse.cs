using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send;

[JsonConverter(typeof(ModelConverter<SendSendMessageResponse>))]
public sealed record class SendSendMessageResponse : ModelBase, IFromRaw<SendSendMessageResponse>
{
    /// <summary>
    /// A successful call to `POST /send` returns a `202` status code along with
    /// a `requestId` in the response body.
    ///
    /// For send requests that have a single recipient, the `requestId` is assigned
    /// to the derived message as its message_id. Therefore the `requestId` can be
    /// supplied to the Message's API for single recipient messages.
    ///
    /// For send requests that have multiple recipients (accounts, audiences, lists,
    /// etc.), Courier assigns a unique id to each derived message as its `message_id`.
    /// Therefore the `requestId` cannot be supplied to the Message's API for single-recipient messages.
    /// </summary>
    public required string RequestID
    {
        get
        {
            if (!this.Properties.TryGetValue("requestId", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'requestId' cannot be null",
                    new ArgumentOutOfRangeException("requestId", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'requestId' cannot be null",
                    new ArgumentNullException("requestId")
                );
        }
        set
        {
            this.Properties["requestId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.RequestID;
    }

    public SendSendMessageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendSendMessageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SendSendMessageResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public SendSendMessageResponse(string requestID)
        : this()
    {
        this.RequestID = requestID;
    }
}
