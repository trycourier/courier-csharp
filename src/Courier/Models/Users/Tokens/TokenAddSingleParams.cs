using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Users.Tokens;

/// <summary>
/// Adds a single token to a user and overwrites a matching existing token.
/// </summary>
public sealed record class TokenAddSingleParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public required string UserID { get; init; }

    public required string Token { get; init; }

    /// <summary>
    /// Full body of the token. Must match token in URL path parameter.
    /// </summary>
    public required string Token1
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("token", out JsonElement element))
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
            this._bodyProperties["token"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, ProviderKey> ProviderKey
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("provider_key", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'provider_key' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "provider_key",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ProviderKey>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._bodyProperties["provider_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Information about the device the token came from.
    /// </summary>
    public Device? Device
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("device", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Device?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["device"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("expiry_date", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ExpiryDate?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["expiry_date"] = JsonSerializer.SerializeToElement(
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
            if (!this._bodyProperties.TryGetValue("properties", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._bodyProperties["properties"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tracking information about the device the token came from.
    /// </summary>
    public Tracking? Tracking
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("tracking", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Tracking?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["tracking"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TokenAddSingleParams() { }

    public TokenAddSingleParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TokenAddSingleParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static TokenAddSingleParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/users/{0}/tokens/{1}", this.UserID, this.Token)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(ProviderKeyConverter))]
public enum ProviderKey
{
    FirebaseFcm,
    Apn,
    Expo,
    Onesignal,
}

sealed class ProviderKeyConverter : JsonConverter<ProviderKey>
{
    public override ProviderKey Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "firebase-fcm" => ProviderKey.FirebaseFcm,
            "apn" => ProviderKey.Apn,
            "expo" => ProviderKey.Expo,
            "onesignal" => ProviderKey.Onesignal,
            _ => (ProviderKey)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProviderKey value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProviderKey.FirebaseFcm => "firebase-fcm",
                ProviderKey.Apn => "apn",
                ProviderKey.Expo => "expo",
                ProviderKey.Onesignal => "onesignal",
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
[JsonConverter(typeof(ModelConverter<Device>))]
public sealed record class Device : ModelBase, IFromRaw<Device>
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

    public Device() { }

    public Device(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Device(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Device FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// ISO 8601 formatted date the token expires. Defaults to 2 months. Set to false
/// to disable expiration.
/// </summary>
[JsonConverter(typeof(ExpiryDateConverter))]
public record class ExpiryDate
{
    public object Value { get; private init; }

    public ExpiryDate(string value)
    {
        Value = value;
    }

    public ExpiryDate(bool value)
    {
        Value = value;
    }

    ExpiryDate(UnknownVariant value)
    {
        Value = value;
    }

    public static ExpiryDate CreateUnknownVariant(JsonElement value)
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
                    "Data did not match any variant of ExpiryDate"
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
                "Data did not match any variant of ExpiryDate"
            ),
        };
    }

    public static implicit operator ExpiryDate(string value) => new(value);

    public static implicit operator ExpiryDate(bool value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new CourierInvalidDataException("Data did not match any variant of ExpiryDate");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ExpiryDateConverter : JsonConverter<ExpiryDate?>
{
    public override ExpiryDate? Read(
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
                return new ExpiryDate(deserialized);
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
            return new ExpiryDate(JsonSerializer.Deserialize<bool>(ref reader, options));
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
        ExpiryDate? value,
        JsonSerializerOptions options
    )
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

/// <summary>
/// Tracking information about the device the token came from.
/// </summary>
[JsonConverter(typeof(ModelConverter<Tracking>))]
public sealed record class Tracking : ModelBase, IFromRaw<Tracking>
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

    public Tracking() { }

    public Tracking(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tracking(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Tracking FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
