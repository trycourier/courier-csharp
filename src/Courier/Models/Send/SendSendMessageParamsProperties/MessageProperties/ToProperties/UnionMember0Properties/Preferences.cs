using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties.PreferencesProperties.CategoriesProperties;
using Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties.PreferencesProperties.NotificationsProperties;

namespace Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties;

[JsonConverter(typeof(ModelConverter<Preferences>))]
public sealed record class Preferences : ModelBase, IFromRaw<Preferences>
{
    public required Dictionary<string, NotificationsItem> Notifications
    {
        get
        {
            if (!this.Properties.TryGetValue("notifications", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'notifications' cannot be null",
                    new ArgumentOutOfRangeException("notifications", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, NotificationsItem>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'notifications' cannot be null",
                    new ArgumentNullException("notifications")
                );
        }
        set
        {
            this.Properties["notifications"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, CategoriesItem>? Categories
    {
        get
        {
            if (!this.Properties.TryGetValue("categories", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, CategoriesItem>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["categories"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? TemplateID
    {
        get
        {
            if (!this.Properties.TryGetValue("templateId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["templateId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Notifications.Values)
        {
            item.Validate();
        }
        if (this.Categories != null)
        {
            foreach (var item in this.Categories.Values)
            {
                item.Validate();
            }
        }
        _ = this.TemplateID;
    }

    public Preferences() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Preferences(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Preferences FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Preferences(Dictionary<string, NotificationsItem> notifications)
        : this()
    {
        this.Notifications = notifications;
    }
}
