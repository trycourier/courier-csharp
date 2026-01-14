using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Notifications.Checks;

[JsonConverter(typeof(JsonModelConverter<CheckUpdateResponse, CheckUpdateResponseFromRaw>))]
public sealed record class CheckUpdateResponse : JsonModel
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

    public CheckUpdateResponse() { }

    public CheckUpdateResponse(CheckUpdateResponse checkUpdateResponse)
        : base(checkUpdateResponse) { }

    public CheckUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
    public CheckUpdateResponse(IReadOnlyList<Check> checks)
        : this()
    {
        this.Checks = checks;
    }
}

class CheckUpdateResponseFromRaw : IFromRawJson<CheckUpdateResponse>
{
    /// <inheritdoc/>
    public CheckUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CheckUpdateResponse.FromRawUnchecked(rawData);
}
