using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using AutomationInvokeStepProperties = Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationInvokeStepProperties;

namespace Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties;

[JsonConverter(typeof(ModelConverter<AutomationInvokeStep>))]
public sealed record class AutomationInvokeStep : ModelBase, IFromRaw<AutomationInvokeStep>
{
    public required ApiEnum<string, AutomationInvokeStepProperties::Action> Action
    {
        get
        {
            if (!this.Properties.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, AutomationInvokeStepProperties::Action>
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

    public required string Template
    {
        get
        {
            if (!this.Properties.TryGetValue("template", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'template' cannot be null",
                    new ArgumentOutOfRangeException("template", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'template' cannot be null",
                    new ArgumentNullException("template")
                );
        }
        set
        {
            this.Properties["template"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Action.Validate();
        _ = this.Template;
    }

    public AutomationInvokeStep() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationInvokeStep(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AutomationInvokeStep FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
