using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Inbound;

[JsonConverter(typeof(ModelConverter<InboundTrackEventResponse>))]
public sealed record class InboundTrackEventResponse
    : ModelBase,
        IFromRaw<InboundTrackEventResponse>
{
    /// <summary>
    /// A successful call returns a `202` status code along with a `requestId` in
    /// the response body.
    /// </summary>
    public required string MessageID
    {
        get
        {
            if (!this.Properties.TryGetValue("messageId", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'messageId' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "messageId",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'messageId' cannot be null",
                    new System::ArgumentNullException("messageId")
                );
        }
        set
        {
            this.Properties["messageId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.MessageID;
    }

    public InboundTrackEventResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundTrackEventResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static InboundTrackEventResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public InboundTrackEventResponse(string messageID)
        : this()
    {
        this.MessageID = messageID;
    }
}
