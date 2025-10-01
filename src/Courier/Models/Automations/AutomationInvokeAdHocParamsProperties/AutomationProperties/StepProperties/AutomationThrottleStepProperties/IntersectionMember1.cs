using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using IntersectionMember1Properties = Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationThrottleStepProperties.IntersectionMember1Properties;

namespace Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationThrottleStepProperties;

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
    /// Maximum number of allowed notifications in that timeframe
    /// </summary>
    public required long MaxAllowed
    {
        get
        {
            if (!this.Properties.TryGetValue("max_allowed", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'max_allowed' cannot be null",
                    new ArgumentOutOfRangeException("max_allowed", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["max_allowed"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required IntersectionMember1Properties::OnThrottle OnThrottle
    {
        get
        {
            if (!this.Properties.TryGetValue("on_throttle", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'on_throttle' cannot be null",
                    new ArgumentOutOfRangeException("on_throttle", "Missing required argument")
                );

            return JsonSerializer.Deserialize<IntersectionMember1Properties::OnThrottle>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'on_throttle' cannot be null",
                    new ArgumentNullException("on_throttle")
                );
        }
        set
        {
            this.Properties["on_throttle"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Defines the throttle period which corresponds to the max_allowed. Specified
    /// as an ISO 8601 duration, https://en.wikipedia.org/wiki/ISO_8601#Durations
    /// </summary>
    public required string Period
    {
        get
        {
            if (!this.Properties.TryGetValue("period", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'period' cannot be null",
                    new ArgumentOutOfRangeException("period", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'period' cannot be null",
                    new ArgumentNullException("period")
                );
        }
        set
        {
            this.Properties["period"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, IntersectionMember1Properties::Scope> Scope
    {
        get
        {
            if (!this.Properties.TryGetValue("scope", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'scope' cannot be null",
                    new ArgumentOutOfRangeException("scope", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, IntersectionMember1Properties::Scope>
            >(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["scope"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Value must be true
    /// </summary>
    public required bool ShouldAlert
    {
        get
        {
            if (!this.Properties.TryGetValue("should_alert", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'should_alert' cannot be null",
                    new ArgumentOutOfRangeException("should_alert", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["should_alert"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If using scope=dynamic, provide the reference (e.g., refs.data.throttle_key)
    /// to the how the throttle should be identified
    /// </summary>
    public string? ThrottleKey
    {
        get
        {
            if (!this.Properties.TryGetValue("throttle_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["throttle_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Action.Validate();
        _ = this.MaxAllowed;
        this.OnThrottle.Validate();
        _ = this.Period;
        this.Scope.Validate();
        _ = this.ShouldAlert;
        _ = this.ThrottleKey;
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
