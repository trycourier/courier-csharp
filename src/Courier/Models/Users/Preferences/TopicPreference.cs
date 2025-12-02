using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Users.Preferences;

[JsonConverter(typeof(ModelConverter<TopicPreference, TopicPreferenceFromRaw>))]
public sealed record class TopicPreference : ModelBase
{
    public required ApiEnum<string, PreferenceStatus> DefaultStatus
    {
        get
        {
            if (!this._rawData.TryGetValue("default_status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'default_status' cannot be null",
                    new ArgumentOutOfRangeException("default_status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, PreferenceStatus>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'default_status' cannot be null",
                    new ArgumentNullException("default_status")
                );
        }
        init
        {
            this._rawData["default_status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, PreferenceStatus> Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, PreferenceStatus>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentNullException("status")
                );
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string TopicID
    {
        get
        {
            if (!this._rawData.TryGetValue("topic_id", out JsonElement element))
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
        init
        {
            this._rawData["topic_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string TopicName
    {
        get
        {
            if (!this._rawData.TryGetValue("topic_name", out JsonElement element))
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
        init
        {
            this._rawData["topic_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The Channels a user has chosen to receive notifications through for this topic
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            if (!this._rawData.TryGetValue("custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, ChannelClassification>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["custom_routing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? HasCustomRouting
    {
        get
        {
            if (!this._rawData.TryGetValue("has_custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["has_custom_routing"] = JsonSerializer.SerializeToElement(
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

    public TopicPreference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopicPreference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static TopicPreference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopicPreferenceFromRaw : IFromRaw<TopicPreference>
{
    public TopicPreference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopicPreference.FromRawUnchecked(rawData);
}
