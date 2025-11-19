using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Users.Tokens;

[JsonConverter(typeof(ModelConverter<UserToken>))]
public sealed record class UserToken : ModelBase, IFromRaw<UserToken>
{
    /// <summary>
    /// Full body of the token. Must match token in URL path parameter.
    /// </summary>
    public required string Token
    {
        get
        {
            if (!this._properties.TryGetValue("token", out JsonElement element))
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
            this._properties["token"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, UserTokenProviderKey> ProviderKey
    {
        get
        {
            if (!this._properties.TryGetValue("provider_key", out JsonElement element))
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
            this._properties["provider_key"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("device", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<UserTokenDevice?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["device"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("expiry_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<UserTokenExpiryDate?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["expiry_date"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Properties about the token.
    /// </summary>
    public JsonElement? Properties1
    {
        get
        {
            if (!this._properties.TryGetValue("properties", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["properties"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("tracking", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<UserTokenTracking?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["tracking"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Token;
        this.ProviderKey.Validate();
        this.Device?.Validate();
        this.ExpiryDate?.Validate();
        _ = this.Properties1;
        this.Tracking?.Validate();
    }

    public UserToken() { }

    public UserToken(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserToken(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static UserToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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
[JsonConverter(typeof(ModelConverter<UserTokenDevice>))]
public sealed record class UserTokenDevice : ModelBase, IFromRaw<UserTokenDevice>
{
    /// <summary>
    /// Id of the advertising identifier
    /// </summary>
    public string? AdID
    {
        get
        {
            if (!this._properties.TryGetValue("ad_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["ad_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Id of the application the token is used for
    /// </summary>
    public string? AppID
    {
        get
        {
            if (!this._properties.TryGetValue("app_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["app_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Id of the device the token is associated with
    /// </summary>
    public string? DeviceID
    {
        get
        {
            if (!this._properties.TryGetValue("device_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["device_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The device manufacturer
    /// </summary>
    public string? Manufacturer
    {
        get
        {
            if (!this._properties.TryGetValue("manufacturer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["manufacturer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The device model
    /// </summary>
    public string? Model
    {
        get
        {
            if (!this._properties.TryGetValue("model", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["model"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The device platform i.e. android, ios, web
    /// </summary>
    public string? Platform
    {
        get
        {
            if (!this._properties.TryGetValue("platform", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["platform"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public UserTokenDevice(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserTokenDevice(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static UserTokenDevice FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// ISO 8601 formatted date the token expires. Defaults to 2 months. Set to false
/// to disable expiration.
/// </summary>
[JsonConverter(typeof(UserTokenExpiryDateConverter))]
public record class UserTokenExpiryDate
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public UserTokenExpiryDate(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UserTokenExpiryDate(bool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public UserTokenExpiryDate(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new CourierInvalidDataException(
                "Data did not match any variant of UserTokenExpiryDate"
            );
        }
    }
}

sealed class UserTokenExpiryDateConverter : JsonConverter<UserTokenExpiryDate?>
{
    public override UserTokenExpiryDate? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        return new(json);
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
[JsonConverter(typeof(ModelConverter<UserTokenTracking>))]
public sealed record class UserTokenTracking : ModelBase, IFromRaw<UserTokenTracking>
{
    /// <summary>
    /// The IP address of the device
    /// </summary>
    public string? IP
    {
        get
        {
            if (!this._properties.TryGetValue("ip", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["ip"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The latitude of the device
    /// </summary>
    public string? Lat
    {
        get
        {
            if (!this._properties.TryGetValue("lat", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["lat"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The longitude of the device
    /// </summary>
    public string? Long
    {
        get
        {
            if (!this._properties.TryGetValue("long", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["long"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The operating system version
    /// </summary>
    public string? OsVersion
    {
        get
        {
            if (!this._properties.TryGetValue("os_version", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["os_version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.IP;
        _ = this.Lat;
        _ = this.Long;
        _ = this.OsVersion;
    }

    public UserTokenTracking() { }

    public UserTokenTracking(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserTokenTracking(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static UserTokenTracking FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
