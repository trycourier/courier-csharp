using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Send.RecipientProperties.WebhookRecipientProperties.WebhookProperties.AuthenticationProperties;

namespace Courier.Models.Send.RecipientProperties.WebhookRecipientProperties.WebhookProperties;

/// <summary>
/// Authentication configuration for the webhook request.
/// </summary>
[JsonConverter(typeof(ModelConverter<Authentication>))]
public sealed record class Authentication : ModelBase, IFromRaw<Authentication>
{
    /// <summary>
    /// The authentication mode to use. Defaults to 'none' if not specified.
    /// </summary>
    public required ApiEnum<string, Mode> Mode
    {
        get
        {
            if (!this.Properties.TryGetValue("mode", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'mode' cannot be null",
                    new ArgumentOutOfRangeException("mode", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["mode"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Token for bearer authentication.
    /// </summary>
    public string? Token
    {
        get
        {
            if (!this.Properties.TryGetValue("token", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["token"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Password for basic authentication.
    /// </summary>
    public string? Password
    {
        get
        {
            if (!this.Properties.TryGetValue("password", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["password"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Username for basic authentication.
    /// </summary>
    public string? Username
    {
        get
        {
            if (!this.Properties.TryGetValue("username", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["username"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Mode.Validate();
        _ = this.Token;
        _ = this.Password;
        _ = this.Username;
    }

    public Authentication() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Authentication(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Authentication FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Authentication(ApiEnum<string, Mode> mode)
        : this()
    {
        this.Mode = mode;
    }
}
