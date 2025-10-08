using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.SubscriptionTopicNewProperties;
using Generic = System.Collections.Generic;

namespace Courier.Models.DefaultPreferencesProperties;

[JsonConverter(typeof(ModelConverter<Item>))]
public sealed record class Item : ModelBase, IFromRaw<Item>
{
    public required ApiEnum<string, Status> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The default channels to send to this tenant when has_custom_routing is enabled
    /// </summary>
    public Generic::List<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            if (!this.Properties.TryGetValue("custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Generic::List<
                ApiEnum<string, ChannelClassification>
            >?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["custom_routing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Override channel routing with custom preferences. This will override any template
    /// prefernces that are set, but a user can still customize their preferences
    /// </summary>
    public bool? HasCustomRouting
    {
        get
        {
            if (!this.Properties.TryGetValue("has_custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["has_custom_routing"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("id", out JsonElement element))
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
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(Generic::Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Item FromRawUnchecked(Generic::Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
