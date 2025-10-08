using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Generic = System.Collections.Generic;

namespace Courier.Models.Users.Preferences.PreferenceUpdateOrCreateTopicParamsProperties;

[JsonConverter(typeof(ModelConverter<Topic>))]
public sealed record class Topic : ModelBase, IFromRaw<Topic>
{
    public required ApiEnum<string, PreferenceStatus> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, PreferenceStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The Channels a user has chosen to receive notifications through for this topic
    /// </summary>
    public Generic::List<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            if (!this.Properties.TryGetValue("custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Generic::List<
                ApiEnum<string, ChannelClassification>
            >?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["custom_routing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? HasCustomRouting
    {
        get
        {
            if (!this.Properties.TryGetValue("has_custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["has_custom_routing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Status.Validate();
        foreach (var item in this.CustomRouting ?? [])
        {
            item.Validate();
        }
        _ = this.HasCustomRouting;
    }

    public Topic() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Topic(Generic::Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Topic FromRawUnchecked(Generic::Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Topic(ApiEnum<string, PreferenceStatus> status)
        : this()
    {
        this.Status = status;
    }
}
