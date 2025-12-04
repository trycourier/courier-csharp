using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Notifications.Checks;

[JsonConverter(typeof(ModelConverter<CheckUpdateResponse, CheckUpdateResponseFromRaw>))]
public sealed record class CheckUpdateResponse : ModelBase
{
    public required IReadOnlyList<Check> Checks
    {
        get { return ModelBase.GetNotNullClass<List<Check>>(this.RawData, "checks"); }
        init { ModelBase.Set(this._rawData, "checks", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Checks)
        {
            item.Validate();
        }
    }

    public CheckUpdateResponse() { }

    public CheckUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckUpdateResponseFromRaw.FromRawUnchecked"/>
    public static CheckUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CheckUpdateResponse(List<Check> checks)
        : this()
    {
        this.Checks = checks;
    }
}

class CheckUpdateResponseFromRaw : IFromRaw<CheckUpdateResponse>
{
    /// <inheritdoc/>
    public CheckUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CheckUpdateResponse.FromRawUnchecked(rawData);
}
