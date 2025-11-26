using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<Recipient, RecipientFromRaw>))]
public sealed record class Recipient : ModelBase
{
    /// <summary>
    /// Deprecated - Use `tenant_id` instead.
    /// </summary>
    public string? AccountID
    {
        get
        {
            if (!this._rawData.TryGetValue("account_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["account_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("context", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<MessageContext?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["context"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Data
    {
        get
        {
            if (!this._rawData.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["data"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the list to send the message to.
    /// </summary>
    public string? ListID
    {
        get
        {
            if (!this._rawData.TryGetValue("list_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["list_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("locale", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["locale"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("phone_number", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["phone_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Preferences? Preferences
    {
        get
        {
            if (!this._rawData.TryGetValue("preferences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Preferences?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["preferences"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("tenant_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["tenant_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("user_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["user_id"] = JsonSerializer.SerializeToElement(
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
        _ = this.ListID;
        _ = this.Locale;
        _ = this.PhoneNumber;
        this.Preferences?.Validate();
        _ = this.TenantID;
        _ = this.UserID;
    }

    public Recipient() { }

    public Recipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Recipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Recipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecipientFromRaw : IFromRaw<Recipient>
{
    public Recipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Recipient.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Preferences, PreferencesFromRaw>))]
public sealed record class Preferences : ModelBase
{
    public required Dictionary<string, Preference> Notifications
    {
        get
        {
            if (!this._rawData.TryGetValue("notifications", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'notifications' cannot be null",
                    new ArgumentOutOfRangeException("notifications", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, Preference>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'notifications' cannot be null",
                    new ArgumentNullException("notifications")
                );
        }
        init
        {
            this._rawData["notifications"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, Preference>? Categories
    {
        get
        {
            if (!this._rawData.TryGetValue("categories", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, Preference>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["categories"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? TemplateID
    {
        get
        {
            if (!this._rawData.TryGetValue("templateId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["templateId"] = JsonSerializer.SerializeToElement(
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

    public Preferences(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Preferences(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Preferences FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Preferences(Dictionary<string, Preference> notifications)
        : this()
    {
        this.Notifications = notifications;
    }
}

class PreferencesFromRaw : IFromRaw<Preferences>
{
    public Preferences FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Preferences.FromRawUnchecked(rawData);
}
