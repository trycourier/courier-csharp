using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using IntersectionMember1Properties = Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToDigestStepProperties.IntersectionMember1Properties;

namespace Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToDigestStepProperties;

[JsonConverter(typeof(ModelConverter<IntersectionMember1>))]
public sealed record class IntersectionMember1 : ModelBase, IFromRaw<IntersectionMember1>
{
    public required ApiEnum<string, IntersectionMember1Properties::Action> Action
    {
        get
        {
            if (!this.Properties.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, IntersectionMember1Properties::Action>
            >(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The subscription topic that has digests enabled
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
        this.Action.Validate();
        _ = this.SubscriptionTopicID;
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static IntersectionMember1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
