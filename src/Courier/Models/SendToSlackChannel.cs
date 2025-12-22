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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "access_token"); }
        init { JsonModel.Set(this._rawData, "access_token", value); }
    }

    public required string Channel
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "channel"); }
        init { JsonModel.Set(this._rawData, "channel", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessToken;
        _ = this.Channel;
    }

    public SendToSlackChannel() { }

    public SendToSlackChannel(SendToSlackChannel sendToSlackChannel)
        : base(sendToSlackChannel) { }

    public SendToSlackChannel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToSlackChannel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
