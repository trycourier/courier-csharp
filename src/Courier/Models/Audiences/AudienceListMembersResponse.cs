using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Audiences;

[JsonConverter(
    typeof(JsonModelConverter<AudienceListMembersResponse, AudienceListMembersResponseFromRaw>)
)]
public sealed record class AudienceListMembersResponse : JsonModel
{
    public required IReadOnlyList<Item> Items
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<Item>>("items"); }
        init
        {
            this._rawData.Set<ImmutableArray<Item>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Paging Paging
    {
        get { return this._rawData.GetNotNullClass<Paging>("paging"); }
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

    public AudienceListMembersResponse() { }

    public AudienceListMembersResponse(AudienceListMembersResponse audienceListMembersResponse)
        : base(audienceListMembersResponse) { }

    public AudienceListMembersResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudienceListMembersResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudienceListMembersResponseFromRaw.FromRawUnchecked"/>
    public static AudienceListMembersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudienceListMembersResponseFromRaw : IFromRawJson<AudienceListMembersResponse>
{
    /// <inheritdoc/>
    public AudienceListMembersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AudienceListMembersResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
{
    public required string AddedAt
    {
        get { return this._rawData.GetNotNullClass<string>("added_at"); }
        init { this._rawData.Set("added_at", value); }
    }

    public required string AudienceID
    {
        get { return this._rawData.GetNotNullClass<string>("audience_id"); }
        init { this._rawData.Set("audience_id", value); }
    }

    public required long AudienceVersion
    {
        get { return this._rawData.GetNotNullStruct<long>("audience_version"); }
        init { this._rawData.Set("audience_version", value); }
    }

    public required string MemberID
    {
        get { return this._rawData.GetNotNullClass<string>("member_id"); }
        init { this._rawData.Set("member_id", value); }
    }

    public required string Reason
    {
        get { return this._rawData.GetNotNullClass<string>("reason"); }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddedAt;
        _ = this.AudienceID;
        _ = this.AudienceVersion;
        _ = this.MemberID;
        _ = this.Reason;
    }

    public Item() { }

    public Item(Item item)
        : base(item) { }

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRawJson<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}
