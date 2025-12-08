using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Send;

/// <summary>
/// Send a message to one or more recipients.
/// </summary>
public sealed record class SendMessageParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The message property has the following primary top-level properties. They
    /// define the destination and content of the message.
    /// </summary>
    public required Message Message
    {
        get { return ModelBase.GetNotNullClass<Message>(this.RawBodyData, "message"); }
        init { ModelBase.Set(this._rawBodyData, "message", value); }
    }

    public SendMessageParams() { }

    public SendMessageParams(SendMessageParams sendMessageParams)
        : base(sendMessageParams)
    {
        this._rawBodyData = [.. sendMessageParams._rawBodyData];
    }

    public SendMessageParams(
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
    SendMessageParams(
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
    public static SendMessageParams FromRawUnchecked(
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/send")
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

/// <summary>
/// The message property has the following primary top-level properties. They define
/// the destination and content of the message.
/// </summary>
[JsonConverter(typeof(ModelConverter<Message, MessageFromRaw>))]
public sealed record class Message : ModelBase
{
    public string? BrandID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "brand_id"); }
        init { ModelBase.Set(this._rawData, "brand_id", value); }
    }

    /// <summary>
    /// Define run-time configuration for channels. Valid ChannelId's: email, sms,
    /// push, inbox, direct_message, banner, webhook.
    /// </summary>
    public IReadOnlyDictionary<string, ChannelsItem>? Channels
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, ChannelsItem>>(
                this.RawData,
                "channels"
            );
        }
        init { ModelBase.Set(this._rawData, "channels", value); }
    }

    /// <summary>
    /// Describes content that will work for email, inbox, push, chat, or any channel id.
    /// </summary>
    public Content? Content
    {
        get { return ModelBase.GetNullableClass<Content>(this.RawData, "content"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "content", value);
        }
    }

    public MessageContext? Context
    {
        get { return ModelBase.GetNullableClass<MessageContext>(this.RawData, "context"); }
        init { ModelBase.Set(this._rawData, "context", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "data"
            );
        }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    public Delay? Delay
    {
        get { return ModelBase.GetNullableClass<Delay>(this.RawData, "delay"); }
        init { ModelBase.Set(this._rawData, "delay", value); }
    }

    public Expiry? Expiry
    {
        get { return ModelBase.GetNullableClass<Expiry>(this.RawData, "expiry"); }
        init { ModelBase.Set(this._rawData, "expiry", value); }
    }

    public MessageMetadata? Metadata
    {
        get { return ModelBase.GetNullableClass<MessageMetadata>(this.RawData, "metadata"); }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    public global::Courier.Models.Send.Preferences? Preferences
    {
        get
        {
            return ModelBase.GetNullableClass<global::Courier.Models.Send.Preferences>(
                this.RawData,
                "preferences"
            );
        }
        init { ModelBase.Set(this._rawData, "preferences", value); }
    }

    public IReadOnlyDictionary<string, ProvidersItem>? Providers
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, ProvidersItem>>(
                this.RawData,
                "providers"
            );
        }
        init { ModelBase.Set(this._rawData, "providers", value); }
    }

    /// <summary>
    /// Customize which channels/providers Courier may deliver the message through.
    /// </summary>
    public Routing? Routing
    {
        get { return ModelBase.GetNullableClass<Routing>(this.RawData, "routing"); }
        init { ModelBase.Set(this._rawData, "routing", value); }
    }

    public string? Template
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "template"); }
        init { ModelBase.Set(this._rawData, "template", value); }
    }

    public Timeout? Timeout
    {
        get { return ModelBase.GetNullableClass<Timeout>(this.RawData, "timeout"); }
        init { ModelBase.Set(this._rawData, "timeout", value); }
    }

    /// <summary>
    /// The recipient or a list of recipients of the message
    /// </summary>
    public To? To
    {
        get { return ModelBase.GetNullableClass<To>(this.RawData, "to"); }
        init { ModelBase.Set(this._rawData, "to", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BrandID;
        if (this.Channels != null)
        {
            foreach (var item in this.Channels.Values)
            {
                item.Validate();
            }
        }
        this.Content?.Validate();
        this.Context?.Validate();
        _ = this.Data;
        this.Delay?.Validate();
        this.Expiry?.Validate();
        this.Metadata?.Validate();
        this.Preferences?.Validate();
        if (this.Providers != null)
        {
            foreach (var item in this.Providers.Values)
            {
                item.Validate();
            }
        }
        this.Routing?.Validate();
        _ = this.Template;
        this.Timeout?.Validate();
        this.To?.Validate();
    }

    public Message() { }

    public Message(Message message)
        : base(message) { }

    public Message(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Message(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageFromRaw.FromRawUnchecked"/>
    public static Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageFromRaw : IFromRaw<Message>
{
    /// <inheritdoc/>
    public Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Message.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<ChannelsItem, ChannelsItemFromRaw>))]
public sealed record class ChannelsItem : ModelBase
{
    /// <summary>
    /// Brand id used for rendering.
    /// </summary>
    public string? BrandID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "brand_id"); }
        init { ModelBase.Set(this._rawData, "brand_id", value); }
    }

    /// <summary>
    /// JS conditional with access to data/profile.
    /// </summary>
    public string? If
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "if"); }
        init { ModelBase.Set(this._rawData, "if", value); }
    }

    public Metadata? Metadata
    {
        get { return ModelBase.GetNullableClass<Metadata>(this.RawData, "metadata"); }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// Channel specific overrides.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Override
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "override"
            );
        }
        init { ModelBase.Set(this._rawData, "override", value); }
    }

    /// <summary>
    /// Providers enabled for this channel.
    /// </summary>
    public IReadOnlyList<string>? Providers
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "providers"); }
        init { ModelBase.Set(this._rawData, "providers", value); }
    }

    /// <summary>
    /// Defaults to `single`.
    /// </summary>
    public ApiEnum<string, RoutingMethod>? RoutingMethod
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, RoutingMethod>>(
                this.RawData,
                "routing_method"
            );
        }
        init { ModelBase.Set(this._rawData, "routing_method", value); }
    }

    public Timeouts? Timeouts
    {
        get { return ModelBase.GetNullableClass<Timeouts>(this.RawData, "timeouts"); }
        init { ModelBase.Set(this._rawData, "timeouts", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.If;
        this.Metadata?.Validate();
        _ = this.Override;
        _ = this.Providers;
        this.RoutingMethod?.Validate();
        this.Timeouts?.Validate();
    }

    public ChannelsItem() { }

    public ChannelsItem(ChannelsItem channelsItem)
        : base(channelsItem) { }

    public ChannelsItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelsItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelsItemFromRaw.FromRawUnchecked"/>
    public static ChannelsItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChannelsItemFromRaw : IFromRaw<ChannelsItem>
{
    /// <inheritdoc/>
    public ChannelsItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelsItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Metadata, MetadataFromRaw>))]
public sealed record class Metadata : ModelBase
{
    public Utm? Utm
    {
        get { return ModelBase.GetNullableClass<Utm>(this.RawData, "utm"); }
        init { ModelBase.Set(this._rawData, "utm", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Utm?.Validate();
    }

    public Metadata() { }

    public Metadata(Metadata metadata)
        : base(metadata) { }

    public Metadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetadataFromRaw.FromRawUnchecked"/>
    public static Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetadataFromRaw : IFromRaw<Metadata>
{
    /// <inheritdoc/>
    public Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Metadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Defaults to `single`.
/// </summary>
[JsonConverter(typeof(RoutingMethodConverter))]
public enum RoutingMethod
{
    All,
    Single,
}

sealed class RoutingMethodConverter : JsonConverter<RoutingMethod>
{
    public override RoutingMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => RoutingMethod.All,
            "single" => RoutingMethod.Single,
            _ => (RoutingMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RoutingMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RoutingMethod.All => "all",
                RoutingMethod.Single => "single",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Timeouts, TimeoutsFromRaw>))]
public sealed record class Timeouts : ModelBase
{
    public long? Channel
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "channel"); }
        init { ModelBase.Set(this._rawData, "channel", value); }
    }

    public long? Provider
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "provider"); }
        init { ModelBase.Set(this._rawData, "provider", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channel;
        _ = this.Provider;
    }

    public Timeouts() { }

    public Timeouts(Timeouts timeouts)
        : base(timeouts) { }

    public Timeouts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Timeouts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimeoutsFromRaw.FromRawUnchecked"/>
    public static Timeouts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimeoutsFromRaw : IFromRaw<Timeouts>
{
    /// <inheritdoc/>
    public Timeouts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Timeouts.FromRawUnchecked(rawData);
}

/// <summary>
/// Describes content that will work for email, inbox, push, chat, or any channel id.
/// </summary>
[JsonConverter(typeof(ContentConverter))]
public record class Content
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public Content(ElementalContentSugar value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Content(ElementalContent value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Content(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ElementalContentSugar"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickElementalContentSugar(out var value)) {
    ///     // `value` is of type `ElementalContentSugar`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickElementalContentSugar([NotNullWhen(true)] out ElementalContentSugar? value)
    {
        value = this.Value as ElementalContentSugar;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ElementalContent"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickElemental(out var value)) {
    ///     // `value` is of type `ElementalContent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickElemental([NotNullWhen(true)] out ElementalContent? value)
    {
        value = this.Value as ElementalContent;
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
    ///     (ElementalContentSugar value) => {...},
    ///     (ElementalContent value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ElementalContentSugar> elementalContentSugar,
        System::Action<ElementalContent> elemental
    )
    {
        switch (this.Value)
        {
            case ElementalContentSugar value:
                elementalContentSugar(value);
                break;
            case ElementalContent value:
                elemental(value);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Content");
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
    ///     (ElementalContentSugar value) => {...},
    ///     (ElementalContent value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ElementalContentSugar, T> elementalContentSugar,
        System::Func<ElementalContent, T> elemental
    )
    {
        return this.Value switch
        {
            ElementalContentSugar value => elementalContentSugar(value),
            ElementalContent value => elemental(value),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Content"),
        };
    }

    public static implicit operator Content(ElementalContentSugar value) => new(value);

    public static implicit operator Content(ElementalContent value) => new(value);

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
            throw new CourierInvalidDataException("Data did not match any variant of Content");
        }
    }

    public virtual bool Equals(Content? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ContentConverter : JsonConverter<Content>
{
    public override Content? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalContentSugar>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalContent>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<Delay, DelayFromRaw>))]
public sealed record class Delay : ModelBase
{
    /// <summary>
    /// The duration of the delay in milliseconds.
    /// </summary>
    public long? Duration
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "duration"); }
        init { ModelBase.Set(this._rawData, "duration", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp or opening_hours-like format.
    /// </summary>
    public string? Until
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "until"); }
        init { ModelBase.Set(this._rawData, "until", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Duration;
        _ = this.Until;
    }

    public Delay() { }

    public Delay(Delay delay)
        : base(delay) { }

    public Delay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Delay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DelayFromRaw.FromRawUnchecked"/>
    public static Delay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DelayFromRaw : IFromRaw<Delay>
{
    /// <inheritdoc/>
    public Delay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Delay.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Expiry, ExpiryFromRaw>))]
public sealed record class Expiry : ModelBase
{
    /// <summary>
    /// Duration in ms or ISO8601 duration (e.g. P1DT4H).
    /// </summary>
    public required ExpiresIn ExpiresIn
    {
        get { return ModelBase.GetNotNullClass<ExpiresIn>(this.RawData, "expires_in"); }
        init { ModelBase.Set(this._rawData, "expires_in", value); }
    }

    /// <summary>
    /// Epoch or ISO8601 timestamp with timezone.
    /// </summary>
    public string? ExpiresAt
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "expires_at"); }
        init { ModelBase.Set(this._rawData, "expires_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ExpiresIn.Validate();
        _ = this.ExpiresAt;
    }

    public Expiry() { }

    public Expiry(Expiry expiry)
        : base(expiry) { }

    public Expiry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Expiry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExpiryFromRaw.FromRawUnchecked"/>
    public static Expiry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Expiry(ExpiresIn expiresIn)
        : this()
    {
        this.ExpiresIn = expiresIn;
    }
}

class ExpiryFromRaw : IFromRaw<Expiry>
{
    /// <inheritdoc/>
    public Expiry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Expiry.FromRawUnchecked(rawData);
}

/// <summary>
/// Duration in ms or ISO8601 duration (e.g. P1DT4H).
/// </summary>
[JsonConverter(typeof(ExpiresInConverter))]
public record class ExpiresIn
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public ExpiresIn(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ExpiresIn(long value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public ExpiresIn(JsonElement json)
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
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
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
    ///     (long value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<string> @string, System::Action<long> @long)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case long value:
                @long(value);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of ExpiresIn"
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
    ///     (long value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<string, T> @string, System::Func<long, T> @long)
    {
        return this.Value switch
        {
            string value => @string(value),
            long value => @long(value),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of ExpiresIn"
            ),
        };
    }

    public static implicit operator ExpiresIn(string value) => new(value);

    public static implicit operator ExpiresIn(long value) => new(value);

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
            throw new CourierInvalidDataException("Data did not match any variant of ExpiresIn");
        }
    }

    public virtual bool Equals(ExpiresIn? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ExpiresInConverter : JsonConverter<ExpiresIn>
{
    public override ExpiresIn? Read(
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
            return new(JsonSerializer.Deserialize<long>(json, options));
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExpiresIn value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<MessageMetadata, MessageMetadataFromRaw>))]
public sealed record class MessageMetadata : ModelBase
{
    public string? Event
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "event"); }
        init { ModelBase.Set(this._rawData, "event", value); }
    }

    public IReadOnlyList<string>? Tags
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "tags"); }
        init { ModelBase.Set(this._rawData, "tags", value); }
    }

    public string? TraceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "trace_id"); }
        init { ModelBase.Set(this._rawData, "trace_id", value); }
    }

    public Utm? Utm
    {
        get { return ModelBase.GetNullableClass<Utm>(this.RawData, "utm"); }
        init { ModelBase.Set(this._rawData, "utm", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Event;
        _ = this.Tags;
        _ = this.TraceID;
        this.Utm?.Validate();
    }

    public MessageMetadata() { }

    public MessageMetadata(MessageMetadata messageMetadata)
        : base(messageMetadata) { }

    public MessageMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageMetadataFromRaw.FromRawUnchecked"/>
    public static MessageMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageMetadataFromRaw : IFromRaw<MessageMetadata>
{
    /// <inheritdoc/>
    public MessageMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        global::Courier.Models.Send.Preferences,
        global::Courier.Models.Send.PreferencesFromRaw
    >)
)]
public sealed record class Preferences : ModelBase
{
    /// <summary>
    /// The subscription topic to apply to the message.
    /// </summary>
    public required string SubscriptionTopicID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "subscription_topic_id"); }
        init { ModelBase.Set(this._rawData, "subscription_topic_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SubscriptionTopicID;
    }

    public Preferences() { }

    public Preferences(global::Courier.Models.Send.Preferences preferences)
        : base(preferences) { }

    public Preferences(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Preferences(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Courier.Models.Send.PreferencesFromRaw.FromRawUnchecked"/>
    public static global::Courier.Models.Send.Preferences FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Preferences(string subscriptionTopicID)
        : this()
    {
        this.SubscriptionTopicID = subscriptionTopicID;
    }
}

class PreferencesFromRaw : IFromRaw<global::Courier.Models.Send.Preferences>
{
    /// <inheritdoc/>
    public global::Courier.Models.Send.Preferences FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Courier.Models.Send.Preferences.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<ProvidersItem, ProvidersItemFromRaw>))]
public sealed record class ProvidersItem : ModelBase
{
    /// <summary>
    /// JS conditional with access to data/profile.
    /// </summary>
    public string? If
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "if"); }
        init { ModelBase.Set(this._rawData, "if", value); }
    }

    public ProvidersItemMetadata? Metadata
    {
        get { return ModelBase.GetNullableClass<ProvidersItemMetadata>(this.RawData, "metadata"); }
        init { ModelBase.Set(this._rawData, "metadata", value); }
    }

    /// <summary>
    /// Provider-specific overrides.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Override
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "override"
            );
        }
        init { ModelBase.Set(this._rawData, "override", value); }
    }

    public long? Timeouts
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "timeouts"); }
        init { ModelBase.Set(this._rawData, "timeouts", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.If;
        this.Metadata?.Validate();
        _ = this.Override;
        _ = this.Timeouts;
    }

    public ProvidersItem() { }

    public ProvidersItem(ProvidersItem providersItem)
        : base(providersItem) { }

    public ProvidersItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProvidersItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProvidersItemFromRaw.FromRawUnchecked"/>
    public static ProvidersItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProvidersItemFromRaw : IFromRaw<ProvidersItem>
{
    /// <inheritdoc/>
    public ProvidersItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProvidersItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<ProvidersItemMetadata, ProvidersItemMetadataFromRaw>))]
public sealed record class ProvidersItemMetadata : ModelBase
{
    public Utm? Utm
    {
        get { return ModelBase.GetNullableClass<Utm>(this.RawData, "utm"); }
        init { ModelBase.Set(this._rawData, "utm", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Utm?.Validate();
    }

    public ProvidersItemMetadata() { }

    public ProvidersItemMetadata(ProvidersItemMetadata providersItemMetadata)
        : base(providersItemMetadata) { }

    public ProvidersItemMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProvidersItemMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProvidersItemMetadataFromRaw.FromRawUnchecked"/>
    public static ProvidersItemMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProvidersItemMetadataFromRaw : IFromRaw<ProvidersItemMetadata>
{
    /// <inheritdoc/>
    public ProvidersItemMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProvidersItemMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Customize which channels/providers Courier may deliver the message through.
/// </summary>
[JsonConverter(typeof(ModelConverter<Routing, RoutingFromRaw>))]
public sealed record class Routing : ModelBase
{
    /// <summary>
    /// A list of channels or providers (or nested routing rules).
    /// </summary>
    public required IReadOnlyList<MessageRoutingChannel> Channels
    {
        get
        {
            return ModelBase.GetNotNullClass<List<MessageRoutingChannel>>(this.RawData, "channels");
        }
        init { ModelBase.Set(this._rawData, "channels", value); }
    }

    public required ApiEnum<string, global::Courier.Models.Send.Method> Method
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, global::Courier.Models.Send.Method>>(
                this.RawData,
                "method"
            );
        }
        init { ModelBase.Set(this._rawData, "method", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Channels)
        {
            item.Validate();
        }
        this.Method.Validate();
    }

    public Routing() { }

    public Routing(Routing routing)
        : base(routing) { }

    public Routing(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Routing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RoutingFromRaw.FromRawUnchecked"/>
    public static Routing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RoutingFromRaw : IFromRaw<Routing>
{
    /// <inheritdoc/>
    public Routing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Routing.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::Courier.Models.Send.MethodConverter))]
public enum Method
{
    All,
    Single,
}

sealed class MethodConverter : JsonConverter<global::Courier.Models.Send.Method>
{
    public override global::Courier.Models.Send.Method Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => global::Courier.Models.Send.Method.All,
            "single" => global::Courier.Models.Send.Method.Single,
            _ => (global::Courier.Models.Send.Method)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Courier.Models.Send.Method value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Courier.Models.Send.Method.All => "all",
                global::Courier.Models.Send.Method.Single => "single",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(ModelConverter<Timeout, TimeoutFromRaw>))]
public sealed record class Timeout : ModelBase
{
    public IReadOnlyDictionary<string, long>? Channel
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, long>>(this.RawData, "channel");
        }
        init { ModelBase.Set(this._rawData, "channel", value); }
    }

    public ApiEnum<string, Criteria>? Criteria
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, Criteria>>(this.RawData, "criteria");
        }
        init { ModelBase.Set(this._rawData, "criteria", value); }
    }

    public long? Escalation
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "escalation"); }
        init { ModelBase.Set(this._rawData, "escalation", value); }
    }

    public long? Message
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "message"); }
        init { ModelBase.Set(this._rawData, "message", value); }
    }

    public IReadOnlyDictionary<string, long>? Provider
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, long>>(this.RawData, "provider");
        }
        init { ModelBase.Set(this._rawData, "provider", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channel;
        this.Criteria?.Validate();
        _ = this.Escalation;
        _ = this.Message;
        _ = this.Provider;
    }

    public Timeout() { }

    public Timeout(Timeout timeout)
        : base(timeout) { }

    public Timeout(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Timeout(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimeoutFromRaw.FromRawUnchecked"/>
    public static Timeout FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimeoutFromRaw : IFromRaw<Timeout>
{
    /// <inheritdoc/>
    public Timeout FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Timeout.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CriteriaConverter))]
public enum Criteria
{
    NoEscalation,
    Delivered,
    Viewed,
    Engaged,
}

sealed class CriteriaConverter : JsonConverter<Criteria>
{
    public override Criteria Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no-escalation" => Criteria.NoEscalation,
            "delivered" => Criteria.Delivered,
            "viewed" => Criteria.Viewed,
            "engaged" => Criteria.Engaged,
            _ => (Criteria)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Criteria value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Criteria.NoEscalation => "no-escalation",
                Criteria.Delivered => "delivered",
                Criteria.Viewed => "viewed",
                Criteria.Engaged => "engaged",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The recipient or a list of recipients of the message
/// </summary>
[JsonConverter(typeof(ToConverter))]
public record class To
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public To(UserRecipient value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public To(IReadOnlyList<Recipient> value, JsonElement? json = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public To(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UserRecipient"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserRecipient(out var value)) {
    ///     // `value` is of type `UserRecipient`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserRecipient([NotNullWhen(true)] out UserRecipient? value)
    {
        value = this.Value as UserRecipient;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="IReadOnlyList<Recipient>"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRecipients(out var value)) {
    ///     // `value` is of type `IReadOnlyList<Recipient>`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRecipients([NotNullWhen(true)] out IReadOnlyList<Recipient>? value)
    {
        value = this.Value as IReadOnlyList<Recipient>;
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
    ///     (UserRecipient value) => {...},
    ///     (IReadOnlyList<Recipient> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<UserRecipient> userRecipient,
        System::Action<IReadOnlyList<Recipient>> recipients
    )
    {
        switch (this.Value)
        {
            case UserRecipient value:
                userRecipient(value);
                break;
            case List<Recipient> value:
                recipients(value);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of To");
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
    ///     (UserRecipient value) => {...},
    ///     (IReadOnlyList<Recipient> value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<UserRecipient, T> userRecipient,
        System::Func<IReadOnlyList<Recipient>, T> recipients
    )
    {
        return this.Value switch
        {
            UserRecipient value => userRecipient(value),
            IReadOnlyList<Recipient> value => recipients(value),
            _ => throw new CourierInvalidDataException("Data did not match any variant of To"),
        };
    }

    public static implicit operator To(UserRecipient value) => new(value);

    public static implicit operator To(List<Recipient> value) =>
        new((IReadOnlyList<Recipient>)value);

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
            throw new CourierInvalidDataException("Data did not match any variant of To");
        }
    }

    public virtual bool Equals(To? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class ToConverter : JsonConverter<To?>
{
    public override To? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<UserRecipient>(json, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Recipient>>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(Utf8JsonWriter writer, To? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
