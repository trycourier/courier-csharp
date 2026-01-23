using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<SendToSlackChannel, SendToSlackChannelFromRaw>))]
public sealed record class SendToSlackChannel : JsonModel
{
    public required string AccessToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("access_token");
        }
        init { this._rawData.Set("access_token", value); }
    }

    public required string Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessToken;
        _ = this.Channel;
    }

    public SendToSlackChannel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SendToSlackChannel(SendToSlackChannel sendToSlackChannel)
        : base(sendToSlackChannel) { }
#pragma warning restore CS8618

    public SendToSlackChannel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToSlackChannel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SendToSlackChannelFromRaw.FromRawUnchecked"/>
    public static SendToSlackChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SendToSlackChannelFromRaw : IFromRawJson<SendToSlackChannel>
{
    /// <inheritdoc/>
    public SendToSlackChannel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SendToSlackChannel.FromRawUnchecked(rawData);
}
