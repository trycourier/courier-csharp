using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

/// <summary>
/// Send to users in lists matching a pattern
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ListPatternRecipient, ListPatternRecipientFromRaw>))]
public sealed record class ListPatternRecipient : JsonModel
{
    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "data"
            );
        }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    public string? ListPattern
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "list_pattern"); }
        init { JsonModel.Set(this._rawData, "list_pattern", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        _ = this.ListPattern;
    }

    public ListPatternRecipient() { }

    public ListPatternRecipient(ListPatternRecipient listPatternRecipient)
        : base(listPatternRecipient) { }

    public ListPatternRecipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListPatternRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ListPatternRecipientFromRaw.FromRawUnchecked"/>
    public static ListPatternRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ListPatternRecipientFromRaw : IFromRawJson<ListPatternRecipient>
{
    /// <inheritdoc/>
    public ListPatternRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ListPatternRecipient.FromRawUnchecked(rawData);
}
