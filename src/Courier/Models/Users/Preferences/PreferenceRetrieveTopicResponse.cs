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
        get { return JsonModel.GetNotNullClass<TopicPreference>(this.RawData, "topic"); }
        init { JsonModel.Set(this._rawData, "topic", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Topic.Validate();
    }

    public PreferenceRetrieveTopicResponse() { }

    public PreferenceRetrieveTopicResponse(
        PreferenceRetrieveTopicResponse preferenceRetrieveTopicResponse
    )
        : base(preferenceRetrieveTopicResponse) { }

    public PreferenceRetrieveTopicResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceRetrieveTopicResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
