using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SubscriptionList>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SubscriptionList>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Paging Paging
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Paging>("paging");
        }
        init { this._rawData.Set("paging", value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ListListResponse(ListListResponse listListResponse)
        : base(listListResponse) { }
#pragma warning restore CS8618

    public ListListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ListListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
