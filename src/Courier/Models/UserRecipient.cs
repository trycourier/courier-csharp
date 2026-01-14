using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<UserRecipient, UserRecipientFromRaw>))]
public sealed record class UserRecipient : JsonModel
{
    /// <summary>
    /// Deprecated - Use `tenant_id` instead.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// Context such as tenant_id to send the notification with.
    /// </summary>
    public MessageContext? Context
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageContext>("context");
        }
        init { this._rawData.Set("context", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("data");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// The id of the list to send the message to.
    /// </summary>
    public string? ListID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("list_id");
        }
        init { this._rawData.Set("list_id", value); }
    }

    /// <summary>
    /// The user's preferred ISO 639-1 language code.
    /// </summary>
    public string? Locale
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("locale");
        }
        init { this._rawData.Set("locale", value); }
    }

    /// <summary>
    /// The user's phone number.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number");
        }
        init { this._rawData.Set("phone_number", value); }
    }

    public Preferences? Preferences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Preferences>("preferences");
        }
        init { this._rawData.Set("preferences", value); }
    }

    /// <summary>
    /// The id of the tenant the user is associated with.
    /// </summary>
    public string? TenantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tenant_id");
        }
        init { this._rawData.Set("tenant_id", value); }
    }

    /// <summary>
    /// The user's unique identifier. Typically, this will match the user id of a
    /// user in your system.
    /// </summary>
    public string? UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <inheritdoc/>
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

    public UserRecipient() { }

    public UserRecipient(UserRecipient userRecipient)
        : base(userRecipient) { }

    public UserRecipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserRecipientFromRaw.FromRawUnchecked"/>
    public static UserRecipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserRecipientFromRaw : IFromRawJson<UserRecipient>
{
    /// <inheritdoc/>
    public UserRecipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserRecipient.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Preferences, PreferencesFromRaw>))]
public sealed record class Preferences : JsonModel
{
    public required IReadOnlyDictionary<string, Preference> Notifications
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, Preference>>(
                "notifications"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, Preference>>(
                "notifications",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyDictionary<string, Preference>? Categories
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, Preference>>(
                "categories"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, Preference>?>(
                "categories",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? TemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("templateId");
        }
        init { this._rawData.Set("templateId", value); }
    }

    /// <inheritdoc/>
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

    public Preferences(Preferences preferences)
        : base(preferences) { }

    public Preferences(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Preferences(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferencesFromRaw.FromRawUnchecked"/>
    public static Preferences FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Preferences(IReadOnlyDictionary<string, Preference> notifications)
        : this()
    {
        this.Notifications = notifications;
    }
}

class PreferencesFromRaw : IFromRawJson<Preferences>
{
    /// <inheritdoc/>
    public Preferences FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Preferences.FromRawUnchecked(rawData);
}
