using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Lists.Subscriptions;

[JsonConverter(typeof(ModelConverter<SubscriptionListResponse>))]
public sealed record class SubscriptionListResponse : ModelBase, IFromRaw<SubscriptionListResponse>
{
    public required List<Item> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentOutOfRangeException("items", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Item>>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentNullException("items")
                );
        }
        set
        {
            this.Properties["items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Paging Paging
    {
        get
        {
            if (!this.Properties.TryGetValue("paging", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'paging' cannot be null",
                    new ArgumentOutOfRangeException("paging", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Paging>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'paging' cannot be null",
                    new ArgumentNullException("paging")
                );
        }
        set
        {
            this.Properties["paging"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
    SubscriptionListResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionListResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<Item>))]
public sealed record class Item : ModelBase, IFromRaw<Item>
{
    public required string RecipientID
    {
        get
        {
            if (!this.Properties.TryGetValue("recipientId", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'recipientId' cannot be null",
                    new ArgumentOutOfRangeException("recipientId", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'recipientId' cannot be null",
                    new ArgumentNullException("recipientId")
                );
        }
        set
        {
            this.Properties["recipientId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Created
    {
        get
        {
            if (!this.Properties.TryGetValue("created", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public RecipientPreferences? Preferences
    {
        get
        {
            if (!this.Properties.TryGetValue("preferences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<RecipientPreferences?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["preferences"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.RecipientID;
        _ = this.Created;
        this.Preferences?.Validate();
    }

    public Item() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Item FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Item(string recipientID)
        : this()
    {
        this.RecipientID = recipientID;
    }
}
