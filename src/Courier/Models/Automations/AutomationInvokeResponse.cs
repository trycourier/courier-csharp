using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Automations;

[JsonConverter(typeof(ModelConverter<AutomationInvokeResponse, AutomationInvokeResponseFromRaw>))]
public sealed record class AutomationInvokeResponse : ModelBase
{
    public required string RunID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "runId"); }
        init { ModelBase.Set(this._rawData, "runId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RunID;
    }

    public AutomationInvokeResponse() { }

    public AutomationInvokeResponse(AutomationInvokeResponse automationInvokeResponse)
        : base(automationInvokeResponse) { }

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

    /// <inheritdoc cref="AutomationInvokeResponseFromRaw.FromRawUnchecked"/>
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

class AutomationInvokeResponseFromRaw : IFromRaw<AutomationInvokeResponse>
{
    /// <inheritdoc/>
    public AutomationInvokeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AutomationInvokeResponse.FromRawUnchecked(rawData);
}
