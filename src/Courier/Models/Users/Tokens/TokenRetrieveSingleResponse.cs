using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Users.Tokens.TokenRetrieveSingleResponseProperties.IntersectionMember1Properties;
using Courier.Models.Users.Tokens.UserTokenProperties;

namespace Courier.Models.Users.Tokens;

[JsonConverter(typeof(ModelConverter<TokenRetrieveSingleResponse>))]
public sealed record class TokenRetrieveSingleResponse
    : ModelBase,
        IFromRaw<TokenRetrieveSingleResponse>
{
    public required ApiEnum<string, ProviderKey> ProviderKey
    {
        get
        {
            if (!this.Properties.TryGetValue("provider_key", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'provider_key' cannot be null",
                    new ArgumentOutOfRangeException("provider_key", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ProviderKey>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["provider_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Full body of the token. Must match token in URL.
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
    /// Information about the device the token is associated with.
    /// </summary>
    public Device? Device
    {
        get
        {
            if (!this.Properties.TryGetValue("device", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Device?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["device"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// ISO 8601 formatted date the token expires. Defaults to 2 months. Set to false
    /// to disable expiration.
    /// </summary>
    public ExpiryDate? ExpiryDate
    {
        get
        {
            if (!this.Properties.TryGetValue("expiry_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ExpiryDate?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["expiry_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Properties sent to the provider along with the token
    /// </summary>
    public JsonElement? Properties1
    {
        get
        {
            if (!this.Properties.TryGetValue("properties", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["properties"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Information about the device the token is associated with.
    /// </summary>
    public Tracking? Tracking
    {
        get
        {
            if (!this.Properties.TryGetValue("tracking", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Tracking?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tracking"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, Status>? Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Status>?>(
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

    /// <summary>
    /// The reason for the token status.
    /// </summary>
    public string? StatusReason
    {
        get
        {
            if (!this.Properties.TryGetValue("status_reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["status_reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator UserToken(
        TokenRetrieveSingleResponse tokenRetrieveSingleResponse
    ) =>
        new()
        {
            ProviderKey = tokenRetrieveSingleResponse.ProviderKey,
            Token = tokenRetrieveSingleResponse.Token,
            Device = tokenRetrieveSingleResponse.Device,
            ExpiryDate = tokenRetrieveSingleResponse.ExpiryDate,
            Properties1 = tokenRetrieveSingleResponse.Properties1,
            Tracking = tokenRetrieveSingleResponse.Tracking,
        };

    public override void Validate()
    {
        this.ProviderKey.Validate();
        _ = this.Token;
        this.Device?.Validate();
        this.ExpiryDate?.Validate();
        _ = this.Properties1;
        this.Tracking?.Validate();
        this.Status?.Validate();
        _ = this.StatusReason;
    }

    public TokenRetrieveSingleResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TokenRetrieveSingleResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TokenRetrieveSingleResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public TokenRetrieveSingleResponse(ApiEnum<string, ProviderKey> providerKey)
        : this()
    {
        this.ProviderKey = providerKey;
    }
}
