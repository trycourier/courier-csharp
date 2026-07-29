using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Users.Preferences;

[JsonConverter(typeof(JsonModelConverter<TopicPreference, TopicPreferenceFromRaw>))]
public sealed record class TopicPreference : JsonModel
{
    /// <summary>
    /// The topic's default status, returned on reads. It applies whenever the user
    /// has no override of their own (status equals this value).
    /// </summary>
    public required ApiEnum<string, PreferenceStatus> DefaultStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PreferenceStatus>>(
                "default_status"
            );
        }
        init { this._rawData.Set("default_status", value); }
    }

    /// <summary>
    /// The user's subscription status for this topic. OPTED_IN or OPTED_OUT reflect
    /// the user's own choice; REQUIRED is a topic-level default set in the preferences
    /// editor, not a user choice.
    /// </summary>
    public required ApiEnum<string, PreferenceStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PreferenceStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The unique identifier of the subscription topic this preference applies to.
    /// </summary>
    public required string TopicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("topic_id");
        }
        init { this._rawData.Set("topic_id", value); }
    }

    /// <summary>
    /// The display name of the subscription topic, returned on reads.
    /// </summary>
    public required string TopicName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("topic_name");
        }
        init { this._rawData.Set("topic_name", value); }
    }

    /// <summary>
    /// The channels the user has chosen to receive this topic on, present only when
    /// has_custom_routing is true. One or more of: direct_message, email, push,
    /// sms, webhook, inbox.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            this._rawData.Freeze();
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

    /// <summary>
    /// Whether the user has chosen specific delivery channels for this topic (listed
    /// in custom_routing) rather than the topic's default routing.
    /// </summary>
    public bool? HasCustomRouting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("has_custom_routing");
        }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopicPreference(TopicPreference topicPreference)
        : base(topicPreference) { }
#pragma warning restore CS8618

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
