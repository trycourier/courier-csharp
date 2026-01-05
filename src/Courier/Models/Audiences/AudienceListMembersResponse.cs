using System.Collections.Frozen;
using System.Collections.Generic;
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
        get { return JsonModel.GetNotNullClass<List<Item>>(this.RawData, "items"); }
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

    public AudienceListMembersResponse() { }

    public AudienceListMembersResponse(AudienceListMembersResponse audienceListMembersResponse)
        : base(audienceListMembersResponse) { }

    public AudienceListMembersResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudienceListMembersResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "added_at"); }
        init { JsonModel.Set(this._rawData, "added_at", value); }
    }

    public required string AudienceID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "audience_id"); }
        init { JsonModel.Set(this._rawData, "audience_id", value); }
    }

    public required long AudienceVersion
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "audience_version"); }
        init { JsonModel.Set(this._rawData, "audience_version", value); }
    }

    public required string MemberID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "member_id"); }
        init { JsonModel.Set(this._rawData, "member_id", value); }
    }

    public required string Reason
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "reason"); }
        init { JsonModel.Set(this._rawData, "reason", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
