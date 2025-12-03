using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<UserRecipient, UserRecipientFromRaw>))]
public sealed record class UserRecipient : ModelBase
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

    public ProfilePreferences? Preferences
    {
        get { return ModelBase.GetNullableClass<ProfilePreferences>(this.RawData, "preferences"); }
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

    public UserRecipient() { }

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

    public static UserRecipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserRecipientFromRaw : IFromRaw<UserRecipient>
{
    public UserRecipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserRecipient.FromRawUnchecked(rawData);
}
