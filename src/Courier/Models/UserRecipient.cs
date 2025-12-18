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
        get { return JsonModel.GetNullableClass<string>(this.RawData, "account_id"); }
        init { JsonModel.Set(this._rawData, "account_id", value); }
    }

    /// <summary>
    /// Context such as tenant_id to send the notification with.
    /// </summary>
    public MessageContext? Context
    {
        get { return JsonModel.GetNullableClass<MessageContext>(this.RawData, "context"); }
        init { JsonModel.Set(this._rawData, "context", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "data"
            );
        }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    /// <summary>
    /// The user's email address.
    /// </summary>
    public string? Email
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "email"); }
        init { JsonModel.Set(this._rawData, "email", value); }
    }

    /// <summary>
    /// The id of the list to send the message to.
    /// </summary>
    public string? ListID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "list_id"); }
        init { JsonModel.Set(this._rawData, "list_id", value); }
    }

    /// <summary>
    /// The user's preferred ISO 639-1 language code.
    /// </summary>
    public string? Locale
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "locale"); }
        init { JsonModel.Set(this._rawData, "locale", value); }
    }

    /// <summary>
    /// The user's phone number.
    /// </summary>
    public string? PhoneNumber
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "phone_number"); }
        init { JsonModel.Set(this._rawData, "phone_number", value); }
    }

    public UserRecipientPreferences? Preferences
    {
        get
        {
            return JsonModel.GetNullableClass<UserRecipientPreferences>(
                this.RawData,
                "preferences"
            );
        }
        init { JsonModel.Set(this._rawData, "preferences", value); }
    }

    /// <summary>
    /// The id of the tenant the user is associated with.
    /// </summary>
    public string? TenantID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "tenant_id"); }
        init { JsonModel.Set(this._rawData, "tenant_id", value); }
    }

    /// <summary>
    /// The user's unique identifier. Typically, this will match the user id of a
    /// user in your system.
    /// </summary>
    public string? UserID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "user_id"); }
        init { JsonModel.Set(this._rawData, "user_id", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

[JsonConverter(
    typeof(JsonModelConverter<UserRecipientPreferences, UserRecipientPreferencesFromRaw>)
)]
public sealed record class UserRecipientPreferences : JsonModel
{
    public required IReadOnlyDictionary<string, Preference> Notifications
    {
        get
        {
            return JsonModel.GetNotNullClass<Dictionary<string, Preference>>(
                this.RawData,
                "notifications"
            );
        }
        init { JsonModel.Set(this._rawData, "notifications", value); }
    }

    public IReadOnlyDictionary<string, Preference>? Categories
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, Preference>>(
                this.RawData,
                "categories"
            );
        }
        init { JsonModel.Set(this._rawData, "categories", value); }
    }

    public string? TemplateID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "templateId"); }
        init { JsonModel.Set(this._rawData, "templateId", value); }
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

    public UserRecipientPreferences() { }

    public UserRecipientPreferences(UserRecipientPreferences userRecipientPreferences)
        : base(userRecipientPreferences) { }

    public UserRecipientPreferences(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRecipientPreferences(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserRecipientPreferencesFromRaw.FromRawUnchecked"/>
    public static UserRecipientPreferences FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserRecipientPreferences(Dictionary<string, Preference> notifications)
        : this()
    {
        this.Notifications = notifications;
    }
}

class UserRecipientPreferencesFromRaw : IFromRawJson<UserRecipientPreferences>
{
    /// <inheritdoc/>
    public UserRecipientPreferences FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserRecipientPreferences.FromRawUnchecked(rawData);
}
