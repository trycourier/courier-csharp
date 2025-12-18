using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Tenants;

[JsonConverter(typeof(JsonModelConverter<DefaultPreferences, DefaultPreferencesFromRaw>))]
public sealed record class DefaultPreferences : JsonModel
{
    public IReadOnlyList<Item>? Items
    {
        get { return JsonModel.GetNullableClass<List<Item>>(this.RawData, "items"); }
        init { JsonModel.Set(this._rawData, "items", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
    }

    public DefaultPreferences() { }

    public DefaultPreferences(DefaultPreferences defaultPreferences)
        : base(defaultPreferences) { }

    public DefaultPreferences(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DefaultPreferences(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DefaultPreferencesFromRaw.FromRawUnchecked"/>
    public static DefaultPreferences FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DefaultPreferencesFromRaw : IFromRawJson<DefaultPreferences>
{
    /// <inheritdoc/>
    public DefaultPreferences FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DefaultPreferences.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
{
    public required ApiEnum<string, Status> Status
    {
        get { return JsonModel.GetNotNullClass<ApiEnum<string, Status>>(this.RawData, "status"); }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// The default channels to send to this tenant when has_custom_routing is enabled
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            return JsonModel.GetNullableClass<List<ApiEnum<string, ChannelClassification>>>(
                this.RawData,
                "custom_routing"
            );
        }
        init { JsonModel.Set(this._rawData, "custom_routing", value); }
    }

    /// <summary>
    /// Override channel routing with custom preferences. This will override any
    /// template prefernces that are set, but a user can still customize their preferences
    /// </summary>
    public bool? HasCustomRouting
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "has_custom_routing"); }
        init { JsonModel.Set(this._rawData, "has_custom_routing", value); }
    }

    /// <summary>
    /// Topic ID
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    public static implicit operator SubscriptionTopicNew(Item item) =>
        new()
        {
            Status = item.Status,
            CustomRouting = item.CustomRouting,
            HasCustomRouting = item.HasCustomRouting,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        foreach (var item in this.CustomRouting ?? [])
        {
            item.Validate();
        }
        _ = this.HasCustomRouting;
        _ = this.ID;
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

[JsonConverter(
    typeof(JsonModelConverter<
        global::Courier.Models.Tenants.IntersectionMember1,
        global::Courier.Models.Tenants.IntersectionMember1FromRaw
    >)
)]
public sealed record class IntersectionMember1 : JsonModel
{
    /// <summary>
    /// Topic ID
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public IntersectionMember1() { }

    public IntersectionMember1(
        global::Courier.Models.Tenants.IntersectionMember1 intersectionMember1
    )
        : base(intersectionMember1) { }

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Courier.Models.Tenants.IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static global::Courier.Models.Tenants.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntersectionMember1(string id)
        : this()
    {
        this.ID = id;
    }
}

class IntersectionMember1FromRaw : IFromRawJson<global::Courier.Models.Tenants.IntersectionMember1>
{
    /// <inheritdoc/>
    public global::Courier.Models.Tenants.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Courier.Models.Tenants.IntersectionMember1.FromRawUnchecked(rawData);
}
