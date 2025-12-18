using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Lists;

[JsonConverter(typeof(JsonModelConverter<ListListResponse, ListListResponseFromRaw>))]
public sealed record class ListListResponse : JsonModel
{
    public required IReadOnlyList<SubscriptionList> Items
    {
        get { return JsonModel.GetNotNullClass<List<SubscriptionList>>(this.RawData, "items"); }
        init { JsonModel.Set(this._rawData, "items", value); }
    }

    public required Paging Paging
    {
        get { return JsonModel.GetNotNullClass<Paging>(this.RawData, "paging"); }
        init { JsonModel.Set(this._rawData, "paging", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        this.Paging.Validate();
    }

    public ListListResponse() { }

    public ListListResponse(ListListResponse listListResponse)
        : base(listListResponse) { }

    public ListListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ListListResponseFromRaw.FromRawUnchecked"/>
    public static ListListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ListListResponseFromRaw : IFromRawJson<ListListResponse>
{
    /// <inheritdoc/>
    public ListListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ListListResponse.FromRawUnchecked(rawData);
}
