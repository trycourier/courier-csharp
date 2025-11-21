using System;
using System.Collections.Frozen;
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
            if (!this._rawData.TryGetValue("runId", out JsonElement element))
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
        init
        {
            this._rawData["runId"] = JsonSerializer.SerializeToElement(
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

    public AutomationInvokeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationInvokeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AutomationInvokeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AutomationInvokeResponse(string runID)
        : this()
    {
        this.RunID = runID;
    }
}
