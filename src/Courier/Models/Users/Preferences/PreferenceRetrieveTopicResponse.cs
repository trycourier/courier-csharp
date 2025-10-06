using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Users.Preferences;

[JsonConverter(typeof(ModelConverter<PreferenceRetrieveTopicResponse>))]
public sealed record class PreferenceRetrieveTopicResponse
    : ModelBase,
        IFromRaw<PreferenceRetrieveTopicResponse>
{
    public required TopicPreference Topic
    {
        get
        {
            if (!this.Properties.TryGetValue("topic", out JsonElement element))
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
        set
        {
            this.Properties["topic"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceRetrieveTopicResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PreferenceRetrieveTopicResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public PreferenceRetrieveTopicResponse(TopicPreference topic)
        : this()
    {
        this.Topic = topic;
    }
}
