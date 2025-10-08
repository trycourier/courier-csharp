using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Models.UserRecipientProperties;
using Generic = System.Collections.Generic;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<UserRecipient>))]
public sealed record class UserRecipient : ModelBase, IFromRaw<UserRecipient>
{
    /// <summary>
    /// Use `tenant_id` instead.
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

    public Generic::Dictionary<string, JsonElement>? Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Generic::Dictionary<string, JsonElement>?>(
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
    /// Tenant id. Will load brand, default preferences and base context data.
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
        if (this.Data != null)
        {
            foreach (var item in this.Data.Values)
            {
                _ = item;
            }
        }
        _ = this.Email;
        _ = this.Locale;
        _ = this.PhoneNumber;
        this.Preferences?.Validate();
        _ = this.TenantID;
        _ = this.UserID;
    }

    public UserRecipient() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRecipient(Generic::Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UserRecipient FromRawUnchecked(
        Generic::Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
