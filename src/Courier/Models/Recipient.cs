using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<Recipient, RecipientFromRaw>))]
public sealed record class Recipient : ModelBase
{
    /// <summary>
    /// Deprecated - Use `tenant_id` instead.
    /// </summary>
    public string? AccountID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "account_id"); }
        init { ModelBase.Set(this._rawData, "account_id", value); }
    }

    /// <summary>
    /// Context such as tenant_id to send the notification with.
    /// </summary>
    public MessageContext? Context
    {
        get { return ModelBase.GetNullableClass<MessageContext>(this.RawData, "context"); }
        init { ModelBase.Set(this._rawData, "context", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "data"
            );
        }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    /// <summary>
    /// The user's email address.
    /// </summary>
    public string? Email
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "email"); }
        init { ModelBase.Set(this._rawData, "email", value); }
    }

    /// <summary>
    /// The id of the list to send the message to.
    /// </summary>
    public string? ListID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "list_id"); }
        init { ModelBase.Set(this._rawData, "list_id", value); }
    }

    /// <summary>
    /// The user's preferred ISO 639-1 language code.
    /// </summary>
    public string? Locale
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "locale"); }
        init { ModelBase.Set(this._rawData, "locale", value); }
    }

    /// <summary>
    /// The user's phone number.
    /// </summary>
    public string? PhoneNumber
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "phone_number"); }
        init { ModelBase.Set(this._rawData, "phone_number", value); }
    }

    public Preferences? Preferences
    {
        get { return ModelBase.GetNullableClass<Preferences>(this.RawData, "preferences"); }
        init { ModelBase.Set(this._rawData, "preferences", value); }
    }

    /// <summary>
    /// The id of the tenant the user is associated with.
    /// </summary>
    public string? TenantID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "tenant_id"); }
        init { ModelBase.Set(this._rawData, "tenant_id", value); }
    }

    /// <summary>
    /// The user's unique identifier. Typically, this will match the user id of a
    /// user in your system.
    /// </summary>
    public string? UserID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "user_id"); }
        init { ModelBase.Set(this._rawData, "user_id", value); }
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
    public required IReadOnlyDictionary<string, Preference> Notifications
    {
        get
        {
            return ModelBase.GetNotNullClass<Dictionary<string, Preference>>(
                this.RawData,
                "notifications"
            );
        }
        init { ModelBase.Set(this._rawData, "notifications", value); }
    }

    public IReadOnlyDictionary<string, Preference>? Categories
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, Preference>>(
                this.RawData,
                "categories"
            );
        }
        init { ModelBase.Set(this._rawData, "categories", value); }
    }

    public string? TemplateID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "templateId"); }
        init { ModelBase.Set(this._rawData, "templateId", value); }
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
