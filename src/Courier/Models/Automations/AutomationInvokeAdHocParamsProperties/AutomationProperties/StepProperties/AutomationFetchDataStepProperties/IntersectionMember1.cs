using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Automations.Invoke;
using IntersectionMember1Properties = Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationFetchDataStepProperties.IntersectionMember1Properties;

namespace Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationFetchDataStepProperties;

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

    public required ApiEnum<string, MergeAlgorithm> MergeStrategy
    {
        get
        {
            if (!this.Properties.TryGetValue("merge_strategy", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'merge_strategy' cannot be null",
                    new ArgumentOutOfRangeException("merge_strategy", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, MergeAlgorithm>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["merge_strategy"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required IntersectionMember1Properties::Webhook Webhook
    {
        get
        {
            if (!this.Properties.TryGetValue("webhook", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'webhook' cannot be null",
                    new ArgumentOutOfRangeException("webhook", "Missing required argument")
                );

            return JsonSerializer.Deserialize<IntersectionMember1Properties::Webhook>(
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

    public string? IdempotencyExpiry
    {
        get
        {
            if (!this.Properties.TryGetValue("idempotency_expiry", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["idempotency_expiry"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? IdempotencyKey
    {
        get
        {
            if (!this.Properties.TryGetValue("idempotency_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["idempotency_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Action.Validate();
        this.MergeStrategy.Validate();
        this.Webhook.Validate();
        _ = this.IdempotencyExpiry;
        _ = this.IdempotencyKey;
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
