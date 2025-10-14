using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<TopicPreference>))]
public sealed record class TopicPreference : ModelBase, IFromRaw<TopicPreference>
{
    public required ApiEnum<string, PreferenceStatus> DefaultStatus
    {
        get
        {
            if (!this.Properties.TryGetValue("default_status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'default_status' cannot be null",
                    new ArgumentOutOfRangeException("default_status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, PreferenceStatus>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["default_status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public required string TopicID
    {
        get
        {
            if (!this.Properties.TryGetValue("topic_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'topic_id' cannot be null",
                    new ArgumentOutOfRangeException("topic_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'topic_id' cannot be null",
                    new ArgumentNullException("topic_id")
                );
        }
        set
        {
            this.Properties["topic_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string TopicName
    {
        get
        {
            if (!this.Properties.TryGetValue("topic_name", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'topic_name' cannot be null",
                    new ArgumentOutOfRangeException("topic_name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'topic_name' cannot be null",
                    new ArgumentNullException("topic_name")
                );
        }
        set
        {
            this.Properties["topic_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The Channels a user has chosen to receive notifications through for this topic
    /// </summary>
    public List<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            if (!this.Properties.TryGetValue("custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, ChannelClassification>>?>(
                element,
                ModelBase.SerializerOptions
            );
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
        this.DefaultStatus.Validate();
        this.Status.Validate();
        _ = this.TopicID;
        _ = this.TopicName;
        foreach (var item in this.CustomRouting ?? [])
        {
            item.Validate();
        }
        _ = this.HasCustomRouting;
    }

    public TopicPreference() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopicPreference(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TopicPreference FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
