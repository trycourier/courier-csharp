using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Automations.Invoke;
using IntersectionMember1Properties = Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationCancelStepProperties.IntersectionMember1Properties;

namespace Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties;

[JsonConverter(typeof(ModelConverter<AutomationCancelStep>))]
public sealed record class AutomationCancelStep : ModelBase, IFromRaw<AutomationCancelStep>
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

    public string? CancelationToken
    {
        get
        {
            if (!this.Properties.TryGetValue("cancelation_token", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["cancelation_token"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator AutomationStep(AutomationCancelStep automationCancelStep) =>
        new() { If = automationCancelStep.If, Ref = automationCancelStep.Ref };

    public override void Validate()
    {
        _ = this.If;
        _ = this.Ref;
        this.Action.Validate();
        _ = this.CancelationToken;
    }

    public AutomationCancelStep() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationCancelStep(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AutomationCancelStep FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public AutomationCancelStep(ApiEnum<string, IntersectionMember1Properties::Action> action)
        : this()
    {
        this.Action = action;
    }
}
