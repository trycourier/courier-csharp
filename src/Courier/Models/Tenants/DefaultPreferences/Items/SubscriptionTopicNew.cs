using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Tenants.DefaultPreferences.Items.SubscriptionTopicNewProperties;

namespace Courier.Models.Tenants.DefaultPreferences.Items;

[JsonConverter(typeof(ModelConverter<SubscriptionTopicNew>))]
public sealed record class SubscriptionTopicNew : ModelBase, IFromRaw<SubscriptionTopicNew>
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
    public List<ApiEnum<string, ChannelClassification>>? CustomRouting
    {
        get
        {
            if (!this.Properties.TryGetValue("custom_routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, ChannelClassification>>?>(
                element,
                ModelBase.SerializerOptions
            );
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

    public override void Validate()
    {
        this.Status.Validate();
        foreach (var item in this.CustomRouting ?? [])
        {
            item.Validate();
        }
        _ = this.HasCustomRouting;
    }

    public SubscriptionTopicNew() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionTopicNew(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscriptionTopicNew FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public SubscriptionTopicNew(ApiEnum<string, Status> status)
        : this()
    {
        this.Status = status;
    }
}
