using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<ChannelPreference>))]
public sealed record class ChannelPreference : ModelBase, IFromRaw<ChannelPreference>
{
    public required ApiEnum<string, ChannelClassification> Channel
    {
        get
        {
            if (!this._properties.TryGetValue("channel", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channel' cannot be null",
                    new System::ArgumentOutOfRangeException("channel", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ChannelClassification>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["channel"] = JsonSerializer.SerializeToElement(
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

    public ChannelPreference(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelPreference(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ChannelPreference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public ChannelPreference(ApiEnum<string, ChannelClassification> channel)
        : this()
    {
        this.Channel = channel;
    }
}
