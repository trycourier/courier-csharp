using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send.BaseMessageProperties;

[JsonConverter(typeof(ModelConverter<Preferences>))]
public sealed record class Preferences : ModelBase, IFromRaw<Preferences>
{
    /// <summary>
    /// The ID of the subscription topic you want to apply to the message. If this
    /// is a templated message, it will override the subscription topic if already associated
    /// </summary>
    public required string SubscriptionTopicID
    {
        get
        {
            if (!this.Properties.TryGetValue("subscription_topic_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'subscription_topic_id' cannot be null",
                    new ArgumentOutOfRangeException(
                        "subscription_topic_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'subscription_topic_id' cannot be null",
                    new ArgumentNullException("subscription_topic_id")
                );
        }
        set
        {
            this.Properties["subscription_topic_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.SubscriptionTopicID;
    }

    public Preferences() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Preferences(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Preferences FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Preferences(string subscriptionTopicID)
        : this()
    {
        this.SubscriptionTopicID = subscriptionTopicID;
    }
}
