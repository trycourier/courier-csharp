using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Journeys;

[JsonConverter(typeof(JsonModelConverter<JourneysInvokeResponse, JourneysInvokeResponseFromRaw>))]
public sealed record class JourneysInvokeResponse : JsonModel
{
    /// <summary>
    /// A unique identifier for the journey run that was created.
    /// </summary>
    public required string RunID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("runId");
        }
        init { this._rawData.Set("runId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RunID;
    }

    public JourneysInvokeResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneysInvokeResponse(JourneysInvokeResponse journeysInvokeResponse)
        : base(journeysInvokeResponse) { }
#pragma warning restore CS8618

    public JourneysInvokeResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneysInvokeResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneysInvokeResponseFromRaw.FromRawUnchecked"/>
    public static JourneysInvokeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JourneysInvokeResponse(string runID)
        : this()
    {
        this.RunID = runID;
    }
}

class JourneysInvokeResponseFromRaw : IFromRawJson<JourneysInvokeResponse>
{
    /// <inheritdoc/>
    public JourneysInvokeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneysInvokeResponse.FromRawUnchecked(rawData);
}
