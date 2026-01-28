using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Users.Tokens;

[JsonConverter(typeof(JsonModelConverter<UserToken, UserTokenFromRaw>))]
public sealed record class UserToken : JsonModel
{
    /// <summary>
    /// Full body of the token. Must match token in URL path parameter.
    /// </summary>
    public required string Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    public required ApiEnum<string, UserTokenProviderKey> ProviderKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserTokenProviderKey>>(
                "provider_key"
            );
        }
        init { this._rawData.Set("provider_key", value); }
    }

    /// <summary>
    /// Information about the device the token came from.
    /// </summary>
    public UserTokenDevice? Device
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserTokenDevice>("device");
        }
        init { this._rawData.Set("device", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date the token expires. Defaults to 2 months. Set to false
    /// to disable expiration.
    /// </summary>
    public UserTokenExpiryDate? ExpiryDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserTokenExpiryDate>("expiry_date");
        }
        init { this._rawData.Set("expiry_date", value); }
    }

    /// <summary>
    /// Properties about the token.
    /// </summary>
    public JsonElement? Properties
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("properties");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("properties", value);
        }
    }

    /// <summary>
    /// Tracking information about the device the token came from.
    /// </summary>
    public UserTokenTracking? Tracking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserTokenTracking>("tracking");
        }
        init { this._rawData.Set("tracking", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Token;
        this.ProviderKey.Validate();
        this.Device?.Validate();
        this.ExpiryDate?.Validate();
        _ = this.Properties;
        this.Tracking?.Validate();
    }

    public UserToken() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserToken(UserToken userToken)
        : base(userToken) { }
#pragma warning restore CS8618

    public UserToken(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserToken(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserTokenFromRaw.FromRawUnchecked"/>
    public static UserToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserTokenFromRaw : IFromRawJson<UserToken>
{
    /// <inheritdoc/>
    public UserToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserToken.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UserTokenProviderKeyConverter))]
public enum UserTokenProviderKey
{
    FirebaseFcm,
    Apn,
    Expo,
    Onesignal,
}

sealed class UserTokenProviderKeyConverter : JsonConverter<UserTokenProviderKey>
{
    public override UserTokenProviderKey Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "firebase-fcm" => UserTokenProviderKey.FirebaseFcm,
            "apn" => UserTokenProviderKey.Apn,
            "expo" => UserTokenProviderKey.Expo,
            "onesignal" => UserTokenProviderKey.Onesignal,
            _ => (UserTokenProviderKey)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserTokenProviderKey value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserTokenProviderKey.FirebaseFcm => "firebase-fcm",
                UserTokenProviderKey.Apn => "apn",
                UserTokenProviderKey.Expo => "expo",
                UserTokenProviderKey.Onesignal => "onesignal",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Information about the device the token came from.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserTokenDevice, UserTokenDeviceFromRaw>))]
public sealed record class UserTokenDevice : JsonModel
{
    /// <summary>
    /// Id of the advertising identifier
    /// </summary>
    public string? AdID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ad_id");
        }
        init { this._rawData.Set("ad_id", value); }
    }

    /// <summary>
    /// Id of the application the token is used for
    /// </summary>
    public string? AppID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("app_id");
        }
        init { this._rawData.Set("app_id", value); }
    }

    /// <summary>
    /// Id of the device the token is associated with
    /// </summary>
    public string? DeviceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("device_id");
        }
        init { this._rawData.Set("device_id", value); }
    }

    /// <summary>
    /// The device manufacturer
    /// </summary>
    public string? Manufacturer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("manufacturer");
        }
        init { this._rawData.Set("manufacturer", value); }
    }

    /// <summary>
    /// The device model
    /// </summary>
    public string? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    /// <summary>
    /// The device platform i.e. android, ios, web
    /// </summary>
    public string? Platform
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("platform");
        }
        init { this._rawData.Set("platform", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdID;
        _ = this.AppID;
        _ = this.DeviceID;
        _ = this.Manufacturer;
        _ = this.Model;
        _ = this.Platform;
    }

    public UserTokenDevice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserTokenDevice(UserTokenDevice userTokenDevice)
        : base(userTokenDevice) { }
#pragma warning restore CS8618

    public UserTokenDevice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserTokenDevice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserTokenDeviceFromRaw.FromRawUnchecked"/>
    public static UserTokenDevice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserTokenDeviceFromRaw : IFromRawJson<UserTokenDevice>
{
    /// <inheritdoc/>
    public UserTokenDevice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserTokenDevice.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 8601 formatted date the token expires. Defaults to 2 months. Set to false
/// to disable expiration.
/// </summary>
[JsonConverter(typeof(UserTokenExpiryDateConverter))]
public record class UserTokenExpiryDate : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public UserTokenExpiryDate(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UserTokenExpiryDate(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UserTokenExpiryDate(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="CourierInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (string value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<string> @string, System::Action<bool> @bool)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of UserTokenExpiryDate"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="CourierInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (string value) => {...},
    ///     (bool value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<string, T> @string, System::Func<bool, T> @bool)
    {
        return this.Value switch
        {
            string value => @string(value),
            bool value => @bool(value),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of UserTokenExpiryDate"
            ),
        };
    }

    public static implicit operator UserTokenExpiryDate(string value) => new(value);

    public static implicit operator UserTokenExpiryDate(bool value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="CourierInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new CourierInvalidDataException(
                "Data did not match any variant of UserTokenExpiryDate"
            );
        }
    }

    public virtual bool Equals(UserTokenExpiryDate? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class UserTokenExpiryDateConverter : JsonConverter<UserTokenExpiryDate?>
{
    public override UserTokenExpiryDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserTokenExpiryDate? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Tracking information about the device the token came from.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserTokenTracking, UserTokenTrackingFromRaw>))]
public sealed record class UserTokenTracking : JsonModel
{
    /// <summary>
    /// The IP address of the device
    /// </summary>
    public string? IP
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ip");
        }
        init { this._rawData.Set("ip", value); }
    }

    /// <summary>
    /// The latitude of the device
    /// </summary>
    public string? Lat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lat");
        }
        init { this._rawData.Set("lat", value); }
    }

    /// <summary>
    /// The longitude of the device
    /// </summary>
    public string? Long
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("long");
        }
        init { this._rawData.Set("long", value); }
    }

    /// <summary>
    /// The operating system version
    /// </summary>
    public string? OsVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("os_version");
        }
        init { this._rawData.Set("os_version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IP;
        _ = this.Lat;
        _ = this.Long;
        _ = this.OsVersion;
    }

    public UserTokenTracking() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserTokenTracking(UserTokenTracking userTokenTracking)
        : base(userTokenTracking) { }
#pragma warning restore CS8618

    public UserTokenTracking(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserTokenTracking(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserTokenTrackingFromRaw.FromRawUnchecked"/>
    public static UserTokenTracking FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserTokenTrackingFromRaw : IFromRawJson<UserTokenTracking>
{
    /// <inheritdoc/>
    public UserTokenTracking FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserTokenTracking.FromRawUnchecked(rawData);
}
