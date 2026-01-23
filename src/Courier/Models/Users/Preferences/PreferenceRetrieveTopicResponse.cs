using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Users.Preferences;

[JsonConverter(
    typeof(JsonModelConverter<
        PreferenceRetrieveTopicResponse,
        PreferenceRetrieveTopicResponseFromRaw
    >)
)]
public sealed record class PreferenceRetrieveTopicResponse : JsonModel
{
    public required TopicPreference Topic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TopicPreference>("topic");
        }
        init { this._rawData.Set("topic", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Topic.Validate();
    }

    public PreferenceRetrieveTopicResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceRetrieveTopicResponse(
        PreferenceRetrieveTopicResponse preferenceRetrieveTopicResponse
    )
        : base(preferenceRetrieveTopicResponse) { }
#pragma warning restore CS8618

    public PreferenceRetrieveTopicResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceRetrieveTopicResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceRetrieveTopicResponseFromRaw.FromRawUnchecked"/>
    public static PreferenceRetrieveTopicResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PreferenceRetrieveTopicResponse(TopicPreference topic)
        : this()
    {
        this.Topic = topic;
    }
}

class PreferenceRetrieveTopicResponseFromRaw : IFromRawJson<PreferenceRetrieveTopicResponse>
{
    /// <inheritdoc/>
    public PreferenceRetrieveTopicResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceRetrieveTopicResponse.FromRawUnchecked(rawData);
}
