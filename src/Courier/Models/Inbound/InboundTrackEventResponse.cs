using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

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
            if (!this._properties.TryGetValue("messageId", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'messageId' cannot be null",
                    new ArgumentOutOfRangeException("messageId", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'messageId' cannot be null",
                    new ArgumentNullException("messageId")
                );
        }
        init
        {
            this._properties["messageId"] = JsonSerializer.SerializeToElement(
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

    public InboundTrackEventResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundTrackEventResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static InboundTrackEventResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public InboundTrackEventResponse(string messageID)
        : this()
    {
        this.MessageID = messageID;
    }
}
