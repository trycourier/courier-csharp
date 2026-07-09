using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageResendResponse, MessageResendResponseFromRaw>))]
public sealed record class MessageResendResponse : JsonModel
{
    /// <summary>
    /// The new message id for the resent message. It is distinct from the id of the
    /// original message that was resent.
    /// </summary>
    public required string MessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("messageId");
        }
        init { this._rawData.Set("messageId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MessageID;
    }

    public MessageResendResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageResendResponse(MessageResendResponse messageResendResponse)
        : base(messageResendResponse) { }
#pragma warning restore CS8618

    public MessageResendResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageResendResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageResendResponseFromRaw.FromRawUnchecked"/>
    public static MessageResendResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MessageResendResponse(string messageID)
        : this()
    {
        this.MessageID = messageID;
    }
}

class MessageResendResponseFromRaw : IFromRawJson<MessageResendResponse>
{
    /// <inheritdoc/>
    public MessageResendResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageResendResponse.FromRawUnchecked(rawData);
}
