using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Users.Tokens;

[JsonConverter(typeof(ModelConverter<TokenRetrieveResponse, TokenRetrieveResponseFromRaw>))]
public sealed record class TokenRetrieveResponse : ModelBase
{
    /// <summary>
    /// Full body of the token. Must match token in URL path parameter.
    /// </summary>
    public required string Token
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "token"); }
        init { ModelBase.Set(this._rawData, "token", value); }
    }

    public required ApiEnum<string, UserTokenProviderKey> ProviderKey
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, UserTokenProviderKey>>(
                this.RawData,
                "provider_key"
            );
        }
        init { ModelBase.Set(this._rawData, "provider_key", value); }
    }

    /// <summary>
    /// Information about the device the token came from.
    /// </summary>
    public UserTokenDevice? Device
    {
        get { return ModelBase.GetNullableClass<UserTokenDevice>(this.RawData, "device"); }
        init { ModelBase.Set(this._rawData, "device", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date the token expires. Defaults to 2 months. Set to false
    /// to disable expiration.
    /// </summary>
    public UserTokenExpiryDate? ExpiryDate
    {
        get { return ModelBase.GetNullableClass<UserTokenExpiryDate>(this.RawData, "expiry_date"); }
        init { ModelBase.Set(this._rawData, "expiry_date", value); }
    }

    /// <summary>
    /// Properties about the token.
    /// </summary>
    public JsonElement? Properties
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "properties"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "properties", value);
        }
    }

    /// <summary>
    /// Tracking information about the device the token came from.
    /// </summary>
    public UserTokenTracking? Tracking
    {
        get { return ModelBase.GetNullableClass<UserTokenTracking>(this.RawData, "tracking"); }
        init { ModelBase.Set(this._rawData, "tracking", value); }
    }

    public ApiEnum<string, Status>? Status
    {
        get { return ModelBase.GetNullableClass<ApiEnum<string, Status>>(this.RawData, "status"); }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// The reason for the token status.
    /// </summary>
    public string? StatusReason
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "status_reason"); }
        init { ModelBase.Set(this._rawData, "status_reason", value); }
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

    /// <inheritdoc/>
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

    public TokenRetrieveResponse(TokenRetrieveResponse tokenRetrieveResponse)
        : base(tokenRetrieveResponse) { }

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

    /// <inheritdoc cref="TokenRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static TokenRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TokenRetrieveResponseFromRaw : IFromRaw<TokenRetrieveResponse>
{
    /// <inheritdoc/>
    public TokenRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TokenRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        global::Courier.Models.Users.Tokens.IntersectionMember1,
        global::Courier.Models.Users.Tokens.IntersectionMember1FromRaw
    >)
)]
public sealed record class IntersectionMember1 : ModelBase
{
    public ApiEnum<string, Status>? Status
    {
        get { return ModelBase.GetNullableClass<ApiEnum<string, Status>>(this.RawData, "status"); }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    /// <summary>
    /// The reason for the token status.
    /// </summary>
    public string? StatusReason
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "status_reason"); }
        init { ModelBase.Set(this._rawData, "status_reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status?.Validate();
        _ = this.StatusReason;
    }

    public IntersectionMember1() { }

    public IntersectionMember1(
        global::Courier.Models.Users.Tokens.IntersectionMember1 intersectionMember1
    )
        : base(intersectionMember1) { }

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

    /// <inheritdoc cref="global::Courier.Models.Users.Tokens.IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static global::Courier.Models.Users.Tokens.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntersectionMember1FromRaw : IFromRaw<global::Courier.Models.Users.Tokens.IntersectionMember1>
{
    /// <inheritdoc/>
    public global::Courier.Models.Users.Tokens.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Courier.Models.Users.Tokens.IntersectionMember1.FromRawUnchecked(rawData);
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
