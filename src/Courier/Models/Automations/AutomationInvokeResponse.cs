using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Automations;

[JsonConverter(typeof(ModelConverter<AutomationInvokeResponse>))]
public sealed record class AutomationInvokeResponse : ModelBase, IFromRaw<AutomationInvokeResponse>
{
    public required string RunID
    {
        get
        {
            if (!this.Properties.TryGetValue("runId", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'runId' cannot be null",
                    new ArgumentOutOfRangeException("runId", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'runId' cannot be null",
                    new ArgumentNullException("runId")
                );
        }
        set
        {
            this.Properties["runId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.RunID;
    }

    public AutomationInvokeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationInvokeResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AutomationInvokeResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public AutomationInvokeResponse(string runID)
        : this()
    {
        this.RunID = runID;
    }
}
