using System.Collections.Frozen;
using System.Collections.Generic;
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
            return JsonModel.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "data"
            );
        }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    public IReadOnlyList<ListFilter>? Filters
    {
        get { return JsonModel.GetNullableClass<List<ListFilter>>(this.RawData, "filters"); }
        init { JsonModel.Set(this._rawData, "filters", value); }
    }

    public string? ListID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "list_id"); }
        init { JsonModel.Set(this._rawData, "list_id", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
