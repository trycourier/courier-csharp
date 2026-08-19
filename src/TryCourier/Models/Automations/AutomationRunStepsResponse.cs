using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Automations;

/// <summary>
/// Every step of an Automation run. Not paginated.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<AutomationRunStepsResponse, AutomationRunStepsResponseFromRaw>)
)]
public sealed record class AutomationRunStepsResponse : JsonModel
{
    public required IReadOnlyList<AutomationRunStep> Steps
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AutomationRunStep>>("steps");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AutomationRunStep>>(
                "steps",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Steps)
        {
            item.Validate();
        }
    }

    public AutomationRunStepsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutomationRunStepsResponse(AutomationRunStepsResponse automationRunStepsResponse)
        : base(automationRunStepsResponse) { }
#pragma warning restore CS8618

    public AutomationRunStepsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationRunStepsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutomationRunStepsResponseFromRaw.FromRawUnchecked"/>
    public static AutomationRunStepsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AutomationRunStepsResponse(IReadOnlyList<AutomationRunStep> steps)
        : this()
    {
        this.Steps = steps;
    }
}

class AutomationRunStepsResponseFromRaw : IFromRawJson<AutomationRunStepsResponse>
{
    /// <inheritdoc/>
    public AutomationRunStepsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutomationRunStepsResponse.FromRawUnchecked(rawData);
}
