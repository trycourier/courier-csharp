using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Lists.Subscriptions;

[JsonConverter(
    typeof(JsonModelConverter<SubscriptionListResponse, SubscriptionListResponseFromRaw>)
)]
public sealed record class SubscriptionListResponse : JsonModel
{
    public required IReadOnlyList<Item> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Item>>("items");
        }
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

    public SubscriptionListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscriptionListResponse(SubscriptionListResponse subscriptionListResponse)
        : base(subscriptionListResponse) { }
#pragma warning restore CS8618

    public SubscriptionListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListResponseFromRaw.FromRawUnchecked"/>
    public static SubscriptionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListResponseFromRaw : IFromRawJson<SubscriptionListResponse>
{
    /// <inheritdoc/>
    public SubscriptionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscriptionListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
{
    public required string RecipientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("recipientId");
        }
        init { this._rawData.Set("recipientId", value); }
    }

    public string? Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    public RecipientPreferences? Preferences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RecipientPreferences>("preferences");
        }
        init { this._rawData.Set("preferences", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecipientID;
        _ = this.Created;
        this.Preferences?.Validate();
    }

    public Item() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Item(Item item)
        : base(item) { }
#pragma warning restore CS8618

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

    [SetsRequiredMembers]
    public Item(string recipientID)
        : this()
    {
        this.RecipientID = recipientID;
    }
}

class ItemFromRaw : IFromRawJson<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}
