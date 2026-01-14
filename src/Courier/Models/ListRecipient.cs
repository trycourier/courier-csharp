using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

/// <summary>
/// Send to all users in a specific list
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ListRecipient, ListRecipientFromRaw>))]
public sealed record class ListRecipient : JsonModel
{
    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            this._rawData.Freeze();
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

    public IReadOnlyList<ListFilter>? Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ListFilter>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ListFilter>?>(
                "filters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? ListID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("list_id");
        }
        init { this._rawData.Set("list_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.ListID;
    }

    public ListRecipient() { }

    public ListRecipient(ListRecipient listRecipient)
        : base(listRecipient) { }

    public ListRecipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ListRecipientFromRaw.FromRawUnchecked"/>
    public static ListRecipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ListRecipientFromRaw : IFromRawJson<ListRecipient>
{
    /// <inheritdoc/>
    public ListRecipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ListRecipient.FromRawUnchecked(rawData);
}
