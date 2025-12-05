using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<ChannelPreference, ChannelPreferenceFromRaw>))]
public sealed record class ChannelPreference : ModelBase
{
    public required ApiEnum<string, ChannelClassification> Channel
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, ChannelClassification>>(
                this.RawData,
                "channel"
            );
        }
        init { ModelBase.Set(this._rawData, "channel", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Channel.Validate();
    }

    public ChannelPreference() { }

    public ChannelPreference(ChannelPreference channelPreference)
        : base(channelPreference) { }

    public ChannelPreference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelPreference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class ChannelPreferenceFromRaw : IFromRaw<ChannelPreference>
{
    /// <inheritdoc/>
    public ChannelPreference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelPreference.FromRawUnchecked(rawData);
}
