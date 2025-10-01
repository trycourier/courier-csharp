using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationThrottleStepProperties.IntersectionMember1Properties;

[JsonConverter(typeof(ModelConverter<OnThrottle>))]
public sealed record class OnThrottle : ModelBase, IFromRaw<OnThrottle>
{
    /// <summary>
    /// The node to go to if the request is throttled
    /// </summary>
    public required string NodeID
    {
        get
        {
            if (!this.Properties.TryGetValue("$node_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'$node_id' cannot be null",
                    new System::ArgumentOutOfRangeException("$node_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'$node_id' cannot be null",
                    new System::ArgumentNullException("$node_id")
                );
        }
        set
        {
            this.Properties["$node_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.NodeID;
    }

    public OnThrottle() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OnThrottle(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static OnThrottle FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public OnThrottle(string nodeID)
        : this()
    {
        this.NodeID = nodeID;
    }
}
