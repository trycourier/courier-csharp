using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Audiences;

[JsonConverter(
    typeof(ModelConverter<AudienceListMembersResponse, AudienceListMembersResponseFromRaw>)
)]
public sealed record class AudienceListMembersResponse : ModelBase
{
    public required IReadOnlyList<Item> Items
    {
        get { return ModelBase.GetNotNullClass<List<Item>>(this.RawData, "items"); }
        init { ModelBase.Set(this._rawData, "items", value); }
    }

    public required Paging Paging
    {
        get { return ModelBase.GetNotNullClass<Paging>(this.RawData, "paging"); }
        init { ModelBase.Set(this._rawData, "paging", value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        this.Paging.Validate();
    }

    public AudienceListMembersResponse() { }

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

    public static AudienceListMembersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudienceListMembersResponseFromRaw : IFromRaw<AudienceListMembersResponse>
{
    public AudienceListMembersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AudienceListMembersResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : ModelBase
{
    public required string AddedAt
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "added_at"); }
        init { ModelBase.Set(this._rawData, "added_at", value); }
    }

    public required string AudienceID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "audience_id"); }
        init { ModelBase.Set(this._rawData, "audience_id", value); }
    }

    public required long AudienceVersion
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "audience_version"); }
        init { ModelBase.Set(this._rawData, "audience_version", value); }
    }

    public required string MemberID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "member_id"); }
        init { ModelBase.Set(this._rawData, "member_id", value); }
    }

    public required string Reason
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "reason"); }
        init { ModelBase.Set(this._rawData, "reason", value); }
    }

    public override void Validate()
    {
        _ = this.AddedAt;
        _ = this.AudienceID;
        _ = this.AudienceVersion;
        _ = this.MemberID;
        _ = this.Reason;
    }

    public Item() { }

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

    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRaw<Item>
{
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}
