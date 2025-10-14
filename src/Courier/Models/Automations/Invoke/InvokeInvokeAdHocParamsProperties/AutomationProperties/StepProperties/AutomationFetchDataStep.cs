using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using AutomationFetchDataStepProperties = Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationFetchDataStepProperties;

namespace Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties;

[JsonConverter(typeof(ModelConverter<AutomationFetchDataStep>))]
public sealed record class AutomationFetchDataStep : ModelBase, IFromRaw<AutomationFetchDataStep>
{
    public required ApiEnum<string, AutomationFetchDataStepProperties::Action> Action
    {
        get
        {
            if (!this.Properties.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, AutomationFetchDataStepProperties::Action>
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

    public required AutomationFetchDataStepProperties::Webhook Webhook
    {
        get
        {
            if (!this.Properties.TryGetValue("webhook", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'webhook' cannot be null",
                    new ArgumentOutOfRangeException("webhook", "Missing required argument")
                );

            return JsonSerializer.Deserialize<AutomationFetchDataStepProperties::Webhook>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'webhook' cannot be null",
                    new ArgumentNullException("webhook")
                );
        }
        set
        {
            this.Properties["webhook"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, AutomationFetchDataStepProperties::MergeStrategy>? MergeStrategy
    {
        get
        {
            if (!this.Properties.TryGetValue("merge_strategy", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                AutomationFetchDataStepProperties::MergeStrategy
            >?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["merge_strategy"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Action.Validate();
        this.Webhook.Validate();
        this.MergeStrategy?.Validate();
    }

    public AutomationFetchDataStep() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationFetchDataStep(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AutomationFetchDataStep FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
