using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Send.RecipientProperties.PreferencesProperties.CategoriesProperties.CategoriesItemProperties.ChannelPreferenceProperties;

namespace Courier.Models.Send.RecipientProperties.PreferencesProperties.CategoriesProperties.CategoriesItemProperties;

[JsonConverter(typeof(ModelConverter<ChannelPreference>))]
public sealed record class ChannelPreference : ModelBase, IFromRaw<ChannelPreference>
{
    public required ApiEnum<string, Channel> Channel
    {
        get
        {
            if (!this.Properties.TryGetValue("channel", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channel' cannot be null",
                    new ArgumentOutOfRangeException("channel", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["channel"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelPreference(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ChannelPreference FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ChannelPreference(ApiEnum<string, Channel> channel)
        : this()
    {
        this.Channel = channel;
    }
}
