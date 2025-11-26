using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Users.Preferences;

[JsonConverter(
    typeof(ModelConverter<PreferenceRetrieveTopicResponse, PreferenceRetrieveTopicResponseFromRaw>)
)]
public sealed record class PreferenceRetrieveTopicResponse : ModelBase
{
    public required TopicPreference Topic
    {
        get
        {
            if (!this._rawData.TryGetValue("topic", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'topic' cannot be null",
                    new ArgumentOutOfRangeException("topic", "Missing required argument")
                );

            return JsonSerializer.Deserialize<TopicPreference>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'topic' cannot be null",
                    new ArgumentNullException("topic")
                );
        }
        init
        {
            this._rawData["topic"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Topic.Validate();
    }

    public PreferenceRetrieveTopicResponse() { }

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

class PreferenceRetrieveTopicResponseFromRaw : IFromRaw<PreferenceRetrieveTopicResponse>
{
    public PreferenceRetrieveTopicResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceRetrieveTopicResponse.FromRawUnchecked(rawData);
}
