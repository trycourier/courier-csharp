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
    public required ApiEnum<string, ProviderKeyModel> ProviderKey
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

            return JsonSerializer.Deserialize<ApiEnum<string, ProviderKeyModel>>(
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
    /// Full body of the token. Must match token in URL.
    /// </summary>
    public string? Token
    {
        get
        {
            if (!this._properties.TryGetValue("token", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["token"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("device", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DeviceModel?>(element, ModelBase.SerializerOptions);
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
    public ExpiryDateModel? ExpiryDate
    {
        get
        {
            if (!this._properties.TryGetValue("expiry_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ExpiryDateModel?>(
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
    /// Properties sent to the provider along with the token
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
            this._properties["properties"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("tracking", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<TrackingModel?>(element, ModelBase.SerializerOptions);
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
        this.ProviderKey.Validate();
        _ = this.Token;
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

    [SetsRequiredMembers]
    public UserToken(ApiEnum<string, ProviderKeyModel> providerKey)
        : this()
    {
        this.ProviderKey = providerKey;
    }
}

[JsonConverter(typeof(ProviderKeyModelConverter))]
public enum ProviderKeyModel
{
    FirebaseFcm,
    Apn,
    Expo,
    Onesignal,
}

sealed class ProviderKeyModelConverter : JsonConverter<ProviderKeyModel>
{
    public override ProviderKeyModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "firebase-fcm" => ProviderKeyModel.FirebaseFcm,
            "apn" => ProviderKeyModel.Apn,
            "expo" => ProviderKeyModel.Expo,
            "onesignal" => ProviderKeyModel.Onesignal,
            _ => (ProviderKeyModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProviderKeyModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProviderKeyModel.FirebaseFcm => "firebase-fcm",
                ProviderKeyModel.Apn => "apn",
                ProviderKeyModel.Expo => "expo",
                ProviderKeyModel.Onesignal => "onesignal",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Information about the device the token is associated with.
/// </summary>
[JsonConverter(typeof(ModelConverter<DeviceModel>))]
public sealed record class DeviceModel : ModelBase, IFromRaw<DeviceModel>
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

    public DeviceModel() { }

    public DeviceModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeviceModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static DeviceModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// ISO 8601 formatted date the token expires. Defaults to 2 months. Set to false
/// to disable expiration.
/// </summary>
[JsonConverter(typeof(ExpiryDateModelConverter))]
public record class ExpiryDateModel
{
    public object Value { get; private init; }

    public ExpiryDateModel(string value)
    {
        Value = value;
    }

    public ExpiryDateModel(bool value)
    {
        Value = value;
    }

    ExpiryDateModel(UnknownVariant value)
    {
        Value = value;
    }

    public static ExpiryDateModel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
                    "Data did not match any variant of ExpiryDateModel"
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
                "Data did not match any variant of ExpiryDateModel"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new CourierInvalidDataException(
                "Data did not match any variant of ExpiryDateModel"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ExpiryDateModelConverter : JsonConverter<ExpiryDateModel?>
{
    public override ExpiryDateModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new ExpiryDateModel(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException("Data does not match union variant 'string'", e)
            );
        }

        try
        {
            return new ExpiryDateModel(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException("Data does not match union variant 'bool'", e)
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExpiryDateModel? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// Information about the device the token is associated with.
/// </summary>
[JsonConverter(typeof(ModelConverter<TrackingModel>))]
public sealed record class TrackingModel : ModelBase, IFromRaw<TrackingModel>
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

    public TrackingModel() { }

    public TrackingModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrackingModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static TrackingModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
