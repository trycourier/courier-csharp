using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send;

[JsonConverter(typeof(ModelConverter<SendMessageResponse>))]
public sealed record class SendMessageResponse : ModelBase, IFromRaw<SendMessageResponse>
{
    /// <summary>
    /// A successful call to `POST /send` returns a `202` status code along with
    /// a `requestId` in the response body. For single-recipient requests, the `requestId`
    /// is the derived message_id. For multiple recipients, Courier assigns a unique
    /// message_id to each derived message.
    /// </summary>
    public required string RequestID
    {
        get
        {
            if (!this._properties.TryGetValue("requestId", out JsonElement element))
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
        init
        {
            this._properties["requestId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.RequestID;
    }

    public SendMessageResponse() { }

    public SendMessageResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendMessageResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static SendMessageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public SendMessageResponse(string requestID)
        : this()
    {
        this.RequestID = requestID;
    }
}
