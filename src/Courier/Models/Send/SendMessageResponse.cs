using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Send;

[JsonConverter(typeof(ModelConverter<SendMessageResponse, SendMessageResponseFromRaw>))]
public sealed record class SendMessageResponse : ModelBase
{
    /// <summary>
    /// A successful call to `POST /send` returns a `202` status code along with a
    /// `requestId` in the response body. For single-recipient requests, the `requestId`
    /// is the derived message_id. For multiple recipients, Courier assigns a unique
    /// message_id to each derived message.
    /// </summary>
    public required string RequestID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "requestId"); }
        init { ModelBase.Set(this._rawData, "requestId", value); }
    }

    public override void Validate()
    {
        _ = this.RequestID;
    }

    public SendMessageResponse() { }

    public SendMessageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendMessageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

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

class SendMessageResponseFromRaw : IFromRaw<SendMessageResponse>
{
    public SendMessageResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SendMessageResponse.FromRawUnchecked(rawData);
}
