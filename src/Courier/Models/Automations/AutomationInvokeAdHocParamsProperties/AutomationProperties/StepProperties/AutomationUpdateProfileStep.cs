using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Automations.Invoke;
using AutomationUpdateProfileStepProperties = Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationUpdateProfileStepProperties;

namespace Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties;

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

    public required ApiEnum<string, MergeAlgorithm> Merge
    {
        get
        {
            if (!this.Properties.TryGetValue("merge", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'merge' cannot be null",
                    new ArgumentOutOfRangeException("merge", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, MergeAlgorithm>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["merge"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required JsonElement Profile
    {
        get
        {
            if (!this.Properties.TryGetValue("profile", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'profile' cannot be null",
                    new ArgumentOutOfRangeException("profile", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["profile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string RecipientID
    {
        get
        {
            if (!this.Properties.TryGetValue("recipient_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'recipient_id' cannot be null",
                    new ArgumentOutOfRangeException("recipient_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'recipient_id' cannot be null",
                    new ArgumentNullException("recipient_id")
                );
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
        this.Merge.Validate();
        _ = this.Profile;
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
