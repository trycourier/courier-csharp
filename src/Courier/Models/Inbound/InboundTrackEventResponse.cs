using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Inbound;

[JsonConverter(typeof(ModelConverter<InboundTrackEventResponse, InboundTrackEventResponseFromRaw>))]
public sealed record class InboundTrackEventResponse : ModelBase
{
    /// <summary>
    /// A successful call returns a `202` status code along with a `requestId` in
    /// the response body.
    /// </summary>
    public required string MessageID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "messageId"); }
        init { ModelBase.Set(this._rawData, "messageId", value); }
    }

    public override void Validate()
    {
        _ = this.MessageID;
    }

    public InboundTrackEventResponse() { }

    public InboundTrackEventResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundTrackEventResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static InboundTrackEventResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InboundTrackEventResponse(string messageID)
        : this()
    {
        this.MessageID = messageID;
    }
}

class InboundTrackEventResponseFromRaw : IFromRaw<InboundTrackEventResponse>
{
    public InboundTrackEventResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundTrackEventResponse.FromRawUnchecked(rawData);
}
