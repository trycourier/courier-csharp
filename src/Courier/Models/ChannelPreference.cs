using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<ChannelPreference>))]
public sealed record class ChannelPreference : ModelBase, IFromRaw<ChannelPreference>
{
    public required ApiEnum<string, ChannelClassification> Channel
    {
        get
        {
            if (!this._rawData.TryGetValue("channel", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channel' cannot be null",
                    new ArgumentOutOfRangeException("channel", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ChannelClassification>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["channel"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Channel.Validate();
    }

    public ChannelPreference() { }

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
