using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Notifications.Checks;

[JsonConverter(typeof(ModelConverter<CheckListResponse, CheckListResponseFromRaw>))]
public sealed record class CheckListResponse : ModelBase
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

    public CheckListResponse() { }

    public CheckListResponse(CheckListResponse checkListResponse)
        : base(checkListResponse) { }

    public CheckListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckListResponseFromRaw.FromRawUnchecked"/>
    public static CheckListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CheckListResponse(List<Check> checks)
        : this()
    {
        this.Checks = checks;
    }
}

class CheckListResponseFromRaw : IFromRaw<CheckListResponse>
{
    /// <inheritdoc/>
    public CheckListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CheckListResponse.FromRawUnchecked(rawData);
}
