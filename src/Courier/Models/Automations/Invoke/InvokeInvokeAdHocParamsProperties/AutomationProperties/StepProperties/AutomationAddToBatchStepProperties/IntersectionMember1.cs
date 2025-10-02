using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using IntersectionMember1Properties = Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToBatchStepProperties.IntersectionMember1Properties;

namespace Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToBatchStepProperties;

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
    /// Defines the maximum wait time before the batch should be released. Must be
    /// less than wait period. Maximum of 60 days. Specified as an [ISO 8601 duration](https://en.wikipedia.org/wiki/ISO_8601#Durations)
    /// </summary>
    public required string MaxWaitPeriod
    {
        get
        {
            if (!this.Properties.TryGetValue("max_wait_period", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'max_wait_period' cannot be null",
                    new ArgumentOutOfRangeException("max_wait_period", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'max_wait_period' cannot be null",
                    new ArgumentNullException("max_wait_period")
                );
        }
        set
        {
            this.Properties["max_wait_period"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Defines what items should be retained and passed along to the next steps
    /// when the batch is released
    /// </summary>
    public required IntersectionMember1Properties::Retain Retain
    {
        get
        {
            if (!this.Properties.TryGetValue("retain", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'retain' cannot be null",
                    new ArgumentOutOfRangeException("retain", "Missing required argument")
                );

            return JsonSerializer.Deserialize<IntersectionMember1Properties::Retain>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'retain' cannot be null",
                    new ArgumentNullException("retain")
                );
        }
        set
        {
            this.Properties["retain"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Defines the period of inactivity before the batch is released. Specified
    /// as an [ISO 8601 duration](https://en.wikipedia.org/wiki/ISO_8601#Durations)
    /// </summary>
    public required string WaitPeriod
    {
        get
        {
            if (!this.Properties.TryGetValue("wait_period", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'wait_period' cannot be null",
                    new ArgumentOutOfRangeException("wait_period", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'wait_period' cannot be null",
                    new ArgumentNullException("wait_period")
                );
        }
        set
        {
            this.Properties["wait_period"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? BatchID
    {
        get
        {
            if (!this.Properties.TryGetValue("batch_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["batch_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If using scope=dynamic, provide the key or a reference (e.g., refs.data.batch_key)
    /// </summary>
    public string? BatchKey
    {
        get
        {
            if (!this.Properties.TryGetValue("batch_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["batch_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Defines the field of the data object the batch is set to when complete. Defaults
    /// to `batch`
    /// </summary>
    public string? CategoryKey
    {
        get
        {
            if (!this.Properties.TryGetValue("category_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["category_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// If specified, the batch will release as soon as this number is reached
    /// </summary>
    public IntersectionMember1Properties::MaxItems? MaxItems
    {
        get
        {
            if (!this.Properties.TryGetValue("max_items", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<IntersectionMember1Properties::MaxItems?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["max_items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Determine the scope of the batching. If user, chosen in this order: recipient,
    /// profile.user_id, data.user_id, data.userId. If dynamic, then specify where
    /// the batch_key or a reference to the batch_key
    /// </summary>
    public ApiEnum<string, IntersectionMember1Properties::Scope>? Scope
    {
        get
        {
            if (!this.Properties.TryGetValue("scope", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                IntersectionMember1Properties::Scope
            >?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["scope"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Action.Validate();
        _ = this.MaxWaitPeriod;
        this.Retain.Validate();
        _ = this.WaitPeriod;
        _ = this.BatchID;
        _ = this.BatchKey;
        _ = this.CategoryKey;
        this.MaxItems?.Validate();
        this.Scope?.Validate();
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
