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
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("data");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? ListPattern
    {
        get { return this._rawData.GetNullableClass<string>("list_pattern"); }
        init { this._rawData.Set("list_pattern", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListPatternRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
