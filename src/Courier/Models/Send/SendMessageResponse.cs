using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Send;

[JsonConverter(typeof(JsonModelConverter<SendMessageResponse, SendMessageResponseFromRaw>))]
public sealed record class SendMessageResponse : JsonModel
{
    /// <summary>
    /// A successful call to `POST /send` returns a `202` status code along with a
    /// `requestId` in the response body. For single-recipient requests, the `requestId`
    /// is the derived message_id. For multiple recipients, Courier assigns a unique
    /// message_id to each derived message.
    /// </summary>
    public required string RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("requestId");
        }
        init { this._rawData.Set("requestId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RequestID;
    }

    public SendMessageResponse() { }

    public SendMessageResponse(SendMessageResponse sendMessageResponse)
        : base(sendMessageResponse) { }

    public SendMessageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendMessageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SendMessageResponseFromRaw.FromRawUnchecked"/>
    public static SendMessageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SendMessageResponse(string requestID)
        : this()
    {
        this.RequestID = requestID;
    }
}

class SendMessageResponseFromRaw : IFromRawJson<SendMessageResponse>
{
    /// <inheritdoc/>
    public SendMessageResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SendMessageResponse.FromRawUnchecked(rawData);
}
