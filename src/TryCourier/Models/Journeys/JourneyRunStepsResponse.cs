using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

/// <summary>
/// Every step of a Journey run. Not paginated.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyRunStepsResponse, JourneyRunStepsResponseFromRaw>))]
public sealed record class JourneyRunStepsResponse : JsonModel
{
    public required IReadOnlyList<JourneyRunStep> Steps
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JourneyRunStep>>("steps");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JourneyRunStep>>(
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

    public JourneyRunStepsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyRunStepsResponse(JourneyRunStepsResponse journeyRunStepsResponse)
        : base(journeyRunStepsResponse) { }
#pragma warning restore CS8618

    public JourneyRunStepsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyRunStepsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyRunStepsResponseFromRaw.FromRawUnchecked"/>
    public static JourneyRunStepsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JourneyRunStepsResponse(IReadOnlyList<JourneyRunStep> steps)
        : this()
    {
        this.Steps = steps;
    }
}

class JourneyRunStepsResponseFromRaw : IFromRawJson<JourneyRunStepsResponse>
{
    /// <inheritdoc/>
    public JourneyRunStepsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyRunStepsResponse.FromRawUnchecked(rawData);
}
