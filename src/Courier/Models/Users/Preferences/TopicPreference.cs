using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Users.Preferences;

[JsonConverter(typeof(JsonModelConverter<TopicPreference, TopicPreferenceFromRaw>))]
public sealed record class TopicPreference : JsonModel
{
    public required ApiEnum<string, PreferenceStatus> DefaultStatus
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, PreferenceStatus>>(
                "default_status"
            );
        }
        init { this._rawData.Set("default_status", value); }
    }

    public required ApiEnum<string, PreferenceStatus> Status
    {
        get { return this._rawData.GetNotNullClass<ApiEnum<string, PreferenceStatus>>("status"); }
        init { this._rawData.Set("status", value); }
    }

    public required string TopicID
    {
        get { return this._rawData.GetNotNullClass<string>("topic_id"); }
        init { this._rawData.Set("topic_id", value); }
    }

    public required string TopicName
    {
        get { return this._rawData.GetNotNullClass<string>("topic_name"); }
        init { this._rawData.Set("topic_name", value); }
    }

    /// <summary>
    /// The Channels a user has chosen to receive notifications through for this topic
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, ChannelClassification>>
            >("custom_routing");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, ChannelClassification>>?>(
                "custom_routing",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? HasCustomRouting
    {
        get { return this._rawData.GetNullableStruct<bool>("has_custom_routing"); }
        init { this._rawData.Set("has_custom_routing", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopicPreference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopicPreferenceFromRaw.FromRawUnchecked"/>
    public static TopicPreference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopicPreferenceFromRaw : IFromRawJson<TopicPreference>
{
    /// <inheritdoc/>
    public TopicPreference FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopicPreference.FromRawUnchecked(rawData);
}
