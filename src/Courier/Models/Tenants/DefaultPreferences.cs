using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Tenants;

[JsonConverter(typeof(ModelConverter<DefaultPreferences, DefaultPreferencesFromRaw>))]
public sealed record class DefaultPreferences : ModelBase
{
    public List<Item>? Items
    {
        get
        {
            if (!this._rawData.TryGetValue("items", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Item>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
    }

    public DefaultPreferences() { }

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

    public static DefaultPreferences FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DefaultPreferencesFromRaw : IFromRaw<DefaultPreferences>
{
    public DefaultPreferences FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DefaultPreferences.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : ModelBase
{
    public required ApiEnum<string, Status> Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The default channels to send to this tenant when has_custom_routing is enabled
    /// </summary>
    public List<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            if (!this._rawData.TryGetValue("custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, ChannelClassification>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["custom_routing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Override channel routing with custom preferences. This will override any
    /// template prefernces that are set, but a user can still customize their preferences
    /// </summary>
    public bool? HasCustomRouting
    {
        get
        {
            if (!this._rawData.TryGetValue("has_custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["has_custom_routing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Topic ID
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator SubscriptionTopicNew(Item item) =>
        new()
        {
            Status = item.Status,
            CustomRouting = item.CustomRouting,
            HasCustomRouting = item.HasCustomRouting,
        };

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

[JsonConverter(
    typeof(ModelConverter<
        global::Courier.Models.Tenants.IntersectionMember1,
        global::Courier.Models.Tenants.IntersectionMember1FromRaw
    >)
)]
public sealed record class IntersectionMember1 : ModelBase
{
    /// <summary>
    /// Topic ID
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
    }

    public IntersectionMember1() { }

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

class IntersectionMember1FromRaw : IFromRaw<global::Courier.Models.Tenants.IntersectionMember1>
{
    public global::Courier.Models.Tenants.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Courier.Models.Tenants.IntersectionMember1.FromRawUnchecked(rawData);
}
