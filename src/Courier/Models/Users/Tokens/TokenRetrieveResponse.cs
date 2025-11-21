using System.Collections.Frozen;
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
    /// <summary>
    /// Full body of the token. Must match token in URL path parameter.
    /// </summary>
    public required string Token
    {
        get
        {
            if (!this._rawData.TryGetValue("token", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'token' cannot be null",
                    new System::ArgumentOutOfRangeException("token", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'token' cannot be null",
                    new System::ArgumentNullException("token")
                );
        }
        init
        {
            this._rawData["token"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, UserTokenProviderKey> ProviderKey
    {
        get
        {
            if (!this._rawData.TryGetValue("provider_key", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'provider_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "provider_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, UserTokenProviderKey>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["provider_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Information about the device the token came from.
    /// </summary>
    public UserTokenDevice? Device
    {
        get
        {
            if (!this._rawData.TryGetValue("device", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<UserTokenDevice?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["device"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// ISO 8601 formatted date the token expires. Defaults to 2 months. Set to false
    /// to disable expiration.
    /// </summary>
    public UserTokenExpiryDate? ExpiryDate
    {
        get
        {
            if (!this._rawData.TryGetValue("expiry_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<UserTokenExpiryDate?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["expiry_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Properties about the token.
    /// </summary>
    public JsonElement? Properties
    {
        get
        {
            if (!this._rawData.TryGetValue("properties", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["properties"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tracking information about the device the token came from.
    /// </summary>
    public UserTokenTracking? Tracking
    {
        get
        {
            if (!this._rawData.TryGetValue("tracking", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<UserTokenTracking?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["tracking"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, Status>? Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Status>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("status_reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["status_reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator UserToken(TokenRetrieveResponse tokenRetrieveResponse) =>
        new()
        {
            Token = tokenRetrieveResponse.Token,
            ProviderKey = tokenRetrieveResponse.ProviderKey,
            Device = tokenRetrieveResponse.Device,
            ExpiryDate = tokenRetrieveResponse.ExpiryDate,
            Properties = tokenRetrieveResponse.Properties,
            Tracking = tokenRetrieveResponse.Tracking,
        };

    public override void Validate()
    {
        _ = this.Token;
        this.ProviderKey.Validate();
        this.Device?.Validate();
        this.ExpiryDate?.Validate();
        _ = this.Properties;
        this.Tracking?.Validate();
        this.Status?.Validate();
        _ = this.StatusReason;
    }

    public TokenRetrieveResponse() { }

    public TokenRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TokenRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static TokenRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
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
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Status>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("status_reason", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["status_reason"] = JsonSerializer.SerializeToElement(
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

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static global::Courier.Models.Users.Tokens.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
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
