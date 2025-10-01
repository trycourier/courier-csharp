using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using IntersectionMember1Properties = Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationDelayStepProperties.IntersectionMember1Properties;

namespace Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationDelayStepProperties;

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
    /// The [ISO 8601 duration](https://en.wikipedia.org/wiki/ISO_8601#Durations)
    /// string for how long to delay for
    /// </summary>
    public string? Duration
    {
        get
        {
            if (!this.Properties.TryGetValue("duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ISO 8601 timestamp for when the delay should end
    /// </summary>
    public string? Until
    {
        get
        {
            if (!this.Properties.TryGetValue("until", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["until"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Action.Validate();
        _ = this.Duration;
        _ = this.Until;
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

    [SetsRequiredMembers]
    public IntersectionMember1(ApiEnum<string, IntersectionMember1Properties::Action> action)
        : this()
    {
        this.Action = action;
    }
}
