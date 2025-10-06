using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using AutomationCancelStepProperties = Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationCancelStepProperties;

namespace Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties;

[JsonConverter(typeof(ModelConverter<AutomationCancelStep>))]
public sealed record class AutomationCancelStep : ModelBase, IFromRaw<AutomationCancelStep>
{
    public required ApiEnum<string, AutomationCancelStepProperties::Action> Action
    {
        get
        {
            if (!this.Properties.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, AutomationCancelStepProperties::Action>
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

    public required string CancelationToken
    {
        get
        {
            if (!this.Properties.TryGetValue("cancelation_token", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'cancelation_token' cannot be null",
                    new ArgumentOutOfRangeException(
                        "cancelation_token",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'cancelation_token' cannot be null",
                    new ArgumentNullException("cancelation_token")
                );
        }
        set
        {
            this.Properties["cancelation_token"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
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
}
