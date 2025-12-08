using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Users.Preferences;

[JsonConverter(typeof(ModelConverter<TopicPreference, TopicPreferenceFromRaw>))]
public sealed record class TopicPreference : ModelBase
{
    public required ApiEnum<string, PreferenceStatus> DefaultStatus
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, PreferenceStatus>>(
                this.RawData,
                "default_status"
            );
        }
        init { ModelBase.Set(this._rawData, "default_status", value); }
    }

    public required ApiEnum<string, PreferenceStatus> Status
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, PreferenceStatus>>(
                this.RawData,
                "status"
            );
        }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    public required string TopicID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "topic_id"); }
        init { ModelBase.Set(this._rawData, "topic_id", value); }
    }

    public required string TopicName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "topic_name"); }
        init { ModelBase.Set(this._rawData, "topic_name", value); }
    }

    /// <summary>
    /// The Channels a user has chosen to receive notifications through for this topic
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            return ModelBase.GetNullableClass<List<ApiEnum<string, ChannelClassification>>>(
                this.RawData,
                "custom_routing"
            );
        }
        init { ModelBase.Set(this._rawData, "custom_routing", value); }
    }

    public bool? HasCustomRouting
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "has_custom_routing"); }
        init { ModelBase.Set(this._rawData, "has_custom_routing", value); }
    }

    /// <inheritdoc/>
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

    public TopicPreference(TopicPreference topicPreference)
        : base(topicPreference) { }

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

    /// <inheritdoc cref="TopicPreferenceFromRaw.FromRawUnchecked"/>
    public static TopicPreference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopicPreferenceFromRaw : IFromRaw<TopicPreference>
{
    /// <inheritdoc/>
    public TopicPreference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopicPreference.FromRawUnchecked(rawData);
}
