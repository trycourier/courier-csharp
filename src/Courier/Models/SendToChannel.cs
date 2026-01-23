using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<SendToChannel, SendToChannelFromRaw>))]
public sealed record class SendToChannel : JsonModel
{
    public required string ChannelID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("channel_id");
        }
        init { this._rawData.Set("channel_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChannelID;
    }

    public SendToChannel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SendToChannel(SendToChannel sendToChannel)
        : base(sendToChannel) { }
#pragma warning restore CS8618

    public SendToChannel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToChannel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SendToChannelFromRaw.FromRawUnchecked"/>
    public static SendToChannel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SendToChannel(string channelID)
        : this()
    {
        this.ChannelID = channelID;
    }
}

class SendToChannelFromRaw : IFromRawJson<SendToChannel>
{
    /// <inheritdoc/>
    public SendToChannel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SendToChannel.FromRawUnchecked(rawData);
}
