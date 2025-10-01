using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Automations.Invoke;
using IntersectionMember1Properties = Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToDigestStepProperties.IntersectionMember1Properties;

namespace Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties;

[JsonConverter(typeof(ModelConverter<AutomationAddToDigestStep>))]
public sealed record class AutomationAddToDigestStep
    : ModelBase,
        IFromRaw<AutomationAddToDigestStep>
{
    public string? If
    {
        get
        {
            if (!this.Properties.TryGetValue("if", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["if"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Ref
    {
        get
        {
            if (!this.Properties.TryGetValue("ref", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ref"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static implicit operator AutomationStep(
        AutomationAddToDigestStep automationAddToDigestStep
    ) => new() { If = automationAddToDigestStep.If, Ref = automationAddToDigestStep.Ref };

    public override void Validate()
    {
        _ = this.If;
        _ = this.Ref;
        this.Action.Validate();
        _ = this.SubscriptionTopicID;
    }

    public AutomationAddToDigestStep() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationAddToDigestStep(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AutomationAddToDigestStep FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
