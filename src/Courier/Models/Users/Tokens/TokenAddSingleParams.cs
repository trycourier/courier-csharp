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
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TokenAddSingleParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string UserID { get; init; }

    public string? Token { get; init; }

    /// <summary>
    /// Full body of the token. Must match token in URL path parameter.
    /// </summary>
    public required string TokenValue
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("token");
        }
        init { this._rawBodyData.Set("token", value); }
    }

    public required ApiEnum<string, ProviderKey> ProviderKey
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, ProviderKey>>("provider_key");
        }
        init { this._rawBodyData.Set("provider_key", value); }
    }

    /// <summary>
    /// Information about the device the token came from.
    /// </summary>
    public Device? Device
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Device>("device");
        }
        init { this._rawBodyData.Set("device", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date the token expires. Defaults to 2 months. Set to false
    /// to disable expiration.
    /// </summary>
    public ExpiryDate? ExpiryDate
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ExpiryDate>("expiry_date");
        }
        init { this._rawBodyData.Set("expiry_date", value); }
    }

    /// <summary>
    /// Properties about the token.
    /// </summary>
    public JsonElement? Properties
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<JsonElement>("properties");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("properties", value);
        }
    }

    /// <summary>
    /// Tracking information about the device the token came from.
    /// </summary>
    public Tracking? Tracking
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Tracking>("tracking");
        }
        init { this._rawBodyData.Set("tracking", value); }
    }

    public TokenAddSingleParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TokenAddSingleParams(TokenAddSingleParams tokenAddSingleParams)
        : base(tokenAddSingleParams)
    {
        this.UserID = tokenAddSingleParams.UserID;
        this.Token = tokenAddSingleParams.Token;

        this._rawBodyData = new(tokenAddSingleParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TokenAddSingleParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TokenAddSingleParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static TokenAddSingleParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["UserID"] = this.UserID,
                ["Token"] = this.Token,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TokenAddSingleParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.UserID.Equals(other.UserID)
            && (this.Token?.Equals(other.Token) ?? other.Token == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
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

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
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
[JsonConverter(typeof(JsonModelConverter<Device, DeviceFromRaw>))]
public sealed record class Device : JsonModel
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

    public Device() { }

    public Device(Device device)
        : base(device) { }

    public Device(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Device(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeviceFromRaw.FromRawUnchecked"/>
    public static Device FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeviceFromRaw : IFromRawJson<Device>
{
    /// <inheritdoc/>
    public Device FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Device.FromRawUnchecked(rawData);
}

/// <summary>
/// ISO 8601 formatted date the token expires. Defaults to 2 months. Set to false
/// to disable expiration.
/// </summary>
[JsonConverter(typeof(ExpiryDateConverter))]
public record class ExpiryDate : ModelBase
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

    public ExpiryDate(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExpiryDate(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExpiryDate(JsonElement element)
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
                    "Data did not match any variant of ExpiryDate"
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
                "Data did not match any variant of ExpiryDate"
            ),
        };
    }

    public static implicit operator ExpiryDate(string value) => new(value);

    public static implicit operator ExpiryDate(bool value) => new(value);

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
            throw new CourierInvalidDataException("Data did not match any variant of ExpiryDate");
        }
    }

    public virtual bool Equals(ExpiryDate? other)
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

sealed class ExpiryDateConverter : JsonConverter<ExpiryDate?>
{
    public override ExpiryDate? Read(
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
            return new(JsonSerializer.Deserialize<bool>(element, options));
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExpiryDate? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Tracking information about the device the token came from.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Tracking, TrackingFromRaw>))]
public sealed record class Tracking : JsonModel
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

    public Tracking() { }

    public Tracking(Tracking tracking)
        : base(tracking) { }

    public Tracking(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tracking(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrackingFromRaw.FromRawUnchecked"/>
    public static Tracking FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrackingFromRaw : IFromRawJson<Tracking>
{
    /// <inheritdoc/>
    public Tracking FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tracking.FromRawUnchecked(rawData);
}
