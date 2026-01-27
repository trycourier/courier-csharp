using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<ChannelPreference, ChannelPreferenceFromRaw>))]
public sealed record class ChannelPreference : JsonModel
{
    public required ApiEnum<string, ChannelClassification> Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ChannelClassification>>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Channel.Validate();
    }

    public ChannelPreference() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelPreference(ChannelPreference channelPreference)
        : base(channelPreference) { }
#pragma warning restore CS8618

    public ChannelPreference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelPreference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelPreferenceFromRaw.FromRawUnchecked"/>
    public static ChannelPreference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChannelPreference(ApiEnum<string, ChannelClassification> channel)
        : this()
    {
        this.Channel = channel;
    }
}

class ChannelPreferenceFromRaw : IFromRawJson<ChannelPreference>
{
    /// <inheritdoc/>
    public ChannelPreference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelPreference.FromRawUnchecked(rawData);
}
