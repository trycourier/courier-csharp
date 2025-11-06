using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Users.Tokens;

[JsonConverter(typeof(ModelConverter<TokenRetrieveResponse>))]
public sealed record class TokenRetrieveResponse : ModelBase, IFromRaw<TokenRetrieveResponse>
{
    public required ApiEnum<string, ProviderKeyModel> ProviderKey
    {
        get
        {
            if (!this.Properties.TryGetValue("provider_key", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'provider_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "provider_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ProviderKeyModel>>(
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
    public DeviceModel? Device
    {
        get
        {
            if (!this.Properties.TryGetValue("device", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DeviceModel?>(element, ModelBase.SerializerOptions);
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
    public ExpiryDateModel? ExpiryDate
    {
        get
        {
            if (!this.Properties.TryGetValue("expiry_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ExpiryDateModel?>(
                element,
                ModelBase.SerializerOptions
            );
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
    public TrackingModel? Tracking
    {
        get
        {
            if (!this.Properties.TryGetValue("tracking", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<TrackingModel?>(element, ModelBase.SerializerOptions);
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

    public static implicit operator UserToken(TokenRetrieveResponse tokenRetrieveResponse) =>
        new()
        {
            ProviderKey = tokenRetrieveResponse.ProviderKey,
            Token = tokenRetrieveResponse.Token,
            Device = tokenRetrieveResponse.Device,
            ExpiryDate = tokenRetrieveResponse.ExpiryDate,
            Properties1 = tokenRetrieveResponse.Properties1,
            Tracking = tokenRetrieveResponse.Tracking,
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

    public TokenRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TokenRetrieveResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TokenRetrieveResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public TokenRetrieveResponse(ApiEnum<string, ProviderKeyModel> providerKey)
        : this()
    {
        this.ProviderKey = providerKey;
    }
}

[JsonConverter(typeof(ModelConverter<global::Courier.Models.Users.Tokens.IntersectionMember1>))]
public sealed record class IntersectionMember1
    : ModelBase,
        IFromRaw<global::Courier.Models.Users.Tokens.IntersectionMember1>
{
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

    public override void Validate()
    {
        this.Status?.Validate();
        _ = this.StatusReason;
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static global::Courier.Models.Users.Tokens.IntersectionMember1 FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Active,
    Unknown,
    Failed,
    Revoked,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => Status.Active,
            "unknown" => Status.Unknown,
            "failed" => Status.Failed,
            "revoked" => Status.Revoked,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "active",
                Status.Unknown => "unknown",
                Status.Failed => "failed",
                Status.Revoked => "revoked",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
