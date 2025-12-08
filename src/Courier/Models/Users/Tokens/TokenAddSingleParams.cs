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
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
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
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "token"); }
        init { ModelBase.Set(this._rawBodyData, "token", value); }
    }

    public required ApiEnum<string, ProviderKey> ProviderKey
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, ProviderKey>>(
                this.RawBodyData,
                "provider_key"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "provider_key", value); }
    }

    /// <summary>
    /// Information about the device the token came from.
    /// </summary>
    public Device? Device
    {
        get { return ModelBase.GetNullableClass<Device>(this.RawBodyData, "device"); }
        init { ModelBase.Set(this._rawBodyData, "device", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date the token expires. Defaults to 2 months. Set to false
    /// to disable expiration.
    /// </summary>
    public ExpiryDate? ExpiryDate
    {
        get { return ModelBase.GetNullableClass<ExpiryDate>(this.RawBodyData, "expiry_date"); }
        init { ModelBase.Set(this._rawBodyData, "expiry_date", value); }
    }

    /// <summary>
    /// Properties about the token.
    /// </summary>
    public JsonElement? Properties
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawBodyData, "properties"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "properties", value);
        }
    }

    /// <summary>
    /// Tracking information about the device the token came from.
    /// </summary>
    public Tracking? Tracking
    {
        get { return ModelBase.GetNullableClass<Tracking>(this.RawBodyData, "tracking"); }
        init { ModelBase.Set(this._rawBodyData, "tracking", value); }
    }

    public TokenAddSingleParams() { }

    public TokenAddSingleParams(TokenAddSingleParams tokenAddSingleParams)
        : base(tokenAddSingleParams)
    {
        this._rawBodyData = [.. tokenAddSingleParams._rawBodyData];
    }

    public TokenAddSingleParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TokenAddSingleParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
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
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
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
[JsonConverter(typeof(ModelConverter<Device, DeviceFromRaw>))]
public sealed record class Device : ModelBase
{
    /// <summary>
    /// Id of the advertising identifier
    /// </summary>
    public string? AdID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "ad_id"); }
        init { ModelBase.Set(this._rawData, "ad_id", value); }
    }

    /// <summary>
    /// Id of the application the token is used for
    /// </summary>
    public string? AppID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "app_id"); }
        init { ModelBase.Set(this._rawData, "app_id", value); }
    }

    /// <summary>
    /// Id of the device the token is associated with
    /// </summary>
    public string? DeviceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "device_id"); }
        init { ModelBase.Set(this._rawData, "device_id", value); }
    }

    /// <summary>
    /// The device manufacturer
    /// </summary>
    public string? Manufacturer
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "manufacturer"); }
        init { ModelBase.Set(this._rawData, "manufacturer", value); }
    }

    /// <summary>
    /// The device model
    /// </summary>
    public string? Model
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "model"); }
        init { ModelBase.Set(this._rawData, "model", value); }
    }

    /// <summary>
    /// The device platform i.e. android, ios, web
    /// </summary>
    public string? Platform
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "platform"); }
        init { ModelBase.Set(this._rawData, "platform", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Device(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeviceFromRaw.FromRawUnchecked"/>
    public static Device FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeviceFromRaw : IFromRaw<Device>
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
public record class ExpiryDate
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ExpiryDate(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ExpiryDate(bool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ExpiryDate(JsonElement json)
    {
        this._json = json;
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
    public void Validate()
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
}

sealed class ExpiryDateConverter : JsonConverter<ExpiryDate?>
{
    public override ExpiryDate? Read(
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
[JsonConverter(typeof(ModelConverter<Tracking, TrackingFromRaw>))]
public sealed record class Tracking : ModelBase
{
    /// <summary>
    /// The IP address of the device
    /// </summary>
    public string? IP
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "ip"); }
        init { ModelBase.Set(this._rawData, "ip", value); }
    }

    /// <summary>
    /// The latitude of the device
    /// </summary>
    public string? Lat
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "lat"); }
        init { ModelBase.Set(this._rawData, "lat", value); }
    }

    /// <summary>
    /// The longitude of the device
    /// </summary>
    public string? Long
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "long"); }
        init { ModelBase.Set(this._rawData, "long", value); }
    }

    /// <summary>
    /// The operating system version
    /// </summary>
    public string? OsVersion
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "os_version"); }
        init { ModelBase.Set(this._rawData, "os_version", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Tracking(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrackingFromRaw.FromRawUnchecked"/>
    public static Tracking FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrackingFromRaw : IFromRaw<Tracking>
{
    /// <inheritdoc/>
    public Tracking FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Tracking.FromRawUnchecked(rawData);
}
