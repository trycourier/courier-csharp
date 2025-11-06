using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<Recipient>))]
public sealed record class Recipient : ModelBase, IFromRaw<Recipient>
{
    /// <summary>
    /// Deprecated - Use `tenant_id` instead.
    /// </summary>
    public string? AccountID
    {
        get
        {
            if (!this.Properties.TryGetValue("account_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["account_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Context such as tenant_id to send the notification with.
    /// </summary>
    public MessageContext? Context
    {
        get
        {
            if (!this.Properties.TryGetValue("context", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<MessageContext?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["context"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The user's email address.
    /// </summary>
    public string? Email
    {
        get
        {
            if (!this.Properties.TryGetValue("email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The user's preferred ISO 639-1 language code.
    /// </summary>
    public string? Locale
    {
        get
        {
            if (!this.Properties.TryGetValue("locale", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["locale"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The user's phone number.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("phone_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["phone_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Preferences? Preferences
    {
        get
        {
            if (!this.Properties.TryGetValue("preferences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Preferences?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["preferences"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the tenant the user is associated with.
    /// </summary>
    public string? TenantID
    {
        get
        {
            if (!this.Properties.TryGetValue("tenant_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tenant_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The user's unique identifier. Typically, this will match the user id of a
    /// user in your system.
    /// </summary>
    public string? UserID
    {
        get
        {
            if (!this.Properties.TryGetValue("user_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["user_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AccountID;
        this.Context?.Validate();
        _ = this.Data;
        _ = this.Email;
        _ = this.Locale;
        _ = this.PhoneNumber;
        this.Preferences?.Validate();
        _ = this.TenantID;
        _ = this.UserID;
    }

    public Recipient() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Recipient(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Recipient FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<Preferences>))]
public sealed record class Preferences : ModelBase, IFromRaw<Preferences>
{
    public required Dictionary<string, Preference> Notifications
    {
        get
        {
            if (!this.Properties.TryGetValue("notifications", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'notifications' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "notifications",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<Dictionary<string, Preference>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'notifications' cannot be null",
                    new System::ArgumentNullException("notifications")
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

    public Dictionary<string, Preference>? Categories
    {
        get
        {
            if (!this.Properties.TryGetValue("categories", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, Preference>?>(
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
    public Preferences(Dictionary<string, Preference> notifications)
        : this()
    {
        this.Notifications = notifications;
    }
}
