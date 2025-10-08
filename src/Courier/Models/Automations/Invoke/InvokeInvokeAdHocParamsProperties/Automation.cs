using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties;
using Generic = System.Collections.Generic;

namespace Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties;

[JsonConverter(typeof(ModelConverter<Automation>))]
public sealed record class Automation : ModelBase, IFromRaw<Automation>
{
    public required Generic::List<Step> Steps
    {
        get
        {
            if (!this.Properties.TryGetValue("steps", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'steps' cannot be null",
                    new ArgumentOutOfRangeException("steps", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Generic::List<Step>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'steps' cannot be null",
                    new ArgumentNullException("steps")
                );
        }
        set
        {
            this.Properties["steps"] = JsonSerializer.SerializeToElement(
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

    public override void Validate()
    {
        foreach (var item in this.Steps)
        {
            item.Validate();
        }
        _ = this.CancelationToken;
    }

    public Automation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Automation(Generic::Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Automation FromRawUnchecked(Generic::Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Automation(Generic::List<Step> steps)
        : this()
    {
        this.Steps = steps;
    }
}
