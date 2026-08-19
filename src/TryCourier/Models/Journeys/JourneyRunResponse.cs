using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

/// <summary>
/// A single Journey run.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyRunResponse, JourneyRunResponseFromRaw>))]
public sealed record class JourneyRunResponse : JsonModel
{
    /// <summary>
    /// One run of a Journey. `status` and `created_at` are absent on a small number
    /// of legacy runs stored without them.
    /// </summary>
    public required JourneyRun Run
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<JourneyRun>("run");
        }
        init { this._rawData.Set("run", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Run.Validate();
    }

    public JourneyRunResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyRunResponse(JourneyRunResponse journeyRunResponse)
        : base(journeyRunResponse) { }
#pragma warning restore CS8618

    public JourneyRunResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyRunResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyRunResponseFromRaw.FromRawUnchecked"/>
    public static JourneyRunResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JourneyRunResponse(JourneyRun run)
        : this()
    {
        this.Run = run;
    }
}

class JourneyRunResponseFromRaw : IFromRawJson<JourneyRunResponse>
{
    /// <inheritdoc/>
    public JourneyRunResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JourneyRunResponse.FromRawUnchecked(rawData);
}
