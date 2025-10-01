using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Bulk.UserRecipientProperties.PreferencesProperties.NotificationsProperties.NotificationsItemProperties;
using Courier.Models.Users.Preferences;

namespace Courier.Models.Bulk.UserRecipientProperties.PreferencesProperties.NotificationsProperties;

[JsonConverter(typeof(ModelConverter<NotificationsItem>))]
public sealed record class NotificationsItem : ModelBase, IFromRaw<NotificationsItem>
{
    public required ApiEnum<string, PreferenceStatus> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, PreferenceStatus>>(
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

    public List<ChannelPreference>? ChannelPreferences
    {
        get
        {
            if (!this.Properties.TryGetValue("channel_preferences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ChannelPreference>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["channel_preferences"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<Rule>? Rules
    {
        get
        {
            if (!this.Properties.TryGetValue("rules", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Rule>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["rules"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, Source>? Source
    {
        get
        {
            if (!this.Properties.TryGetValue("source", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Source>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Status.Validate();
        foreach (var item in this.ChannelPreferences ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Rules ?? [])
        {
            item.Validate();
        }
        this.Source?.Validate();
    }

    public NotificationsItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationsItem(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NotificationsItem FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public NotificationsItem(ApiEnum<string, PreferenceStatus> status)
        : this()
    {
        this.Status = status;
    }
}
