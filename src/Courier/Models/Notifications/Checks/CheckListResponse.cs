using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Notifications.Checks;

[JsonConverter(typeof(JsonModelConverter<CheckListResponse, CheckListResponseFromRaw>))]
public sealed record class CheckListResponse : JsonModel
{
    public required IReadOnlyList<Check> Checks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Check>>("checks");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Check>>(
                "checks",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckListResponse(CheckListResponse checkListResponse)
        : base(checkListResponse) { }
#pragma warning restore CS8618

    public CheckListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
    public CheckListResponse(IReadOnlyList<Check> checks)
        : this()
    {
        this.Checks = checks;
    }
}

class CheckListResponseFromRaw : IFromRawJson<CheckListResponse>
{
    /// <inheritdoc/>
    public CheckListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CheckListResponse.FromRawUnchecked(rawData);
}
