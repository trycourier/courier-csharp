using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using AutomationUpdateProfileStepProperties = Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationUpdateProfileStepProperties;

namespace Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties;

[JsonConverter(typeof(ModelConverter<AutomationUpdateProfileStep>))]
public sealed record class AutomationUpdateProfileStep
    : ModelBase,
        IFromRaw<AutomationUpdateProfileStep>
{
    public required ApiEnum<string, AutomationUpdateProfileStepProperties::Action> Action
    {
        get
        {
            if (!this.Properties.TryGetValue("action", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'action' cannot be null",
                    new ArgumentOutOfRangeException("action", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, AutomationUpdateProfileStepProperties::Action>
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

    public required Dictionary<string, JsonElement> Profile
    {
        get
        {
            if (!this.Properties.TryGetValue("profile", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'profile' cannot be null",
                    new ArgumentOutOfRangeException("profile", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'profile' cannot be null",
                    new ArgumentNullException("profile")
                );
        }
        set
        {
            this.Properties["profile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, AutomationUpdateProfileStepProperties::Merge>? Merge
    {
        get
        {
            if (!this.Properties.TryGetValue("merge", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                AutomationUpdateProfileStepProperties::Merge
            >?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["merge"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? RecipientID
    {
        get
        {
            if (!this.Properties.TryGetValue("recipient_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["recipient_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Action.Validate();
        _ = this.Profile;
        this.Merge?.Validate();
        _ = this.RecipientID;
    }

    public AutomationUpdateProfileStep() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationUpdateProfileStep(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AutomationUpdateProfileStep FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
