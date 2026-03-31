using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<ChannelMetadata, ChannelMetadataFromRaw>))]
public sealed record class ChannelMetadata : JsonModel
{
    public Utm? Utm
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Utm>("utm");
        }
        init { this._rawData.Set("utm", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Utm?.Validate();
    }

    public ChannelMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelMetadata(ChannelMetadata channelMetadata)
        : base(channelMetadata) { }
#pragma warning restore CS8618

    public ChannelMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelMetadataFromRaw.FromRawUnchecked"/>
    public static ChannelMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChannelMetadataFromRaw : IFromRawJson<ChannelMetadata>
{
    /// <inheritdoc/>
    public ChannelMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelMetadata.FromRawUnchecked(rawData);
}
