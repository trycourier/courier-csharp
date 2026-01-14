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
    readonly JsonDictionary _rawBodyData = new();
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
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Message>("message");
        }
        init { this._rawBodyData.Set("message", value); }
    }

    public SendMessageParams() { }

    public SendMessageParams(SendMessageParams sendMessageParams)
        : base(sendMessageParams)
    {
        this._rawBodyData = new(sendMessageParams._rawBodyData);
    }

    public SendMessageParams(
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
    SendMessageParams(
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
}

/// <summary>
/// The message property has the following primary top-level properties. They define
/// the destination and content of the message.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Message, MessageFromRaw>))]
public sealed record class Message : JsonModel
{
    public string? BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

    /// <summary>
    /// Define run-time configuration for channels. Valid ChannelId's: email, sms,
    /// push, inbox, direct_message, banner, webhook.
    /// </summary>
    public IReadOnlyDictionary<string, ChannelsItem>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, ChannelsItem>>(
                "channels"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, ChannelsItem>?>(
                "channels",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Describes content that will work for email, inbox, push, chat, or any channel id.
    /// </summary>
    public Content? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Content>("content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("content", value);
        }
    }

    public MessageContext? Context
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageContext>("context");
        }
        init { this._rawData.Set("context", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("data");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public Delay? Delay
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Delay>("delay");
        }
        init { this._rawData.Set("delay", value); }
    }

    public Expiry? Expiry
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Expiry>("expiry");
        }
        init { this._rawData.Set("expiry", value); }
    }

    public MessageMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageMetadata>("metadata");
        }
        init { this._rawData.Set("metadata", value); }
    }

    public global::Courier.Models.Send.Preferences? Preferences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::Courier.Models.Send.Preferences>(
                "preferences"
            );
        }
        init { this._rawData.Set("preferences", value); }
    }

    public IReadOnlyDictionary<string, ProvidersItem>? Providers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, ProvidersItem>>(
                "providers"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, ProvidersItem>?>(
                "providers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Customize which channels/providers Courier may deliver the message through.
    /// </summary>
    public Routing? Routing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Routing>("routing");
        }
        init { this._rawData.Set("routing", value); }
    }

    public string? Template
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template");
        }
        init { this._rawData.Set("template", value); }
    }

    public Timeout? Timeout
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Timeout>("timeout");
        }
        init { this._rawData.Set("timeout", value); }
    }

    /// <summary>
    /// The recipient or a list of recipients of the message
    /// </summary>
    public To? To
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<To>("to");
        }
        init { this._rawData.Set("to", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Message(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageFromRaw.FromRawUnchecked"/>
    public static Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageFromRaw : IFromRawJson<Message>
{
    /// <inheritdoc/>
    public Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Message.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ChannelsItem, ChannelsItemFromRaw>))]
public sealed record class ChannelsItem : JsonModel
{
    /// <summary>
    /// Brand id used for rendering.
    /// </summary>
    public string? BrandID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("brand_id");
        }
        init { this._rawData.Set("brand_id", value); }
    }

    /// <summary>
    /// JS conditional with access to data/profile.
    /// </summary>
    public string? If
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("if");
        }
        init { this._rawData.Set("if", value); }
    }

    public Metadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Metadata>("metadata");
        }
        init { this._rawData.Set("metadata", value); }
    }

    /// <summary>
    /// Channel specific overrides.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Override
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "override"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "override",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Providers enabled for this channel.
    /// </summary>
    public IReadOnlyList<string>? Providers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("providers");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "providers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Defaults to `single`.
    /// </summary>
    public ApiEnum<string, RoutingMethod>? RoutingMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RoutingMethod>>("routing_method");
        }
        init { this._rawData.Set("routing_method", value); }
    }

    public Timeouts? Timeouts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Timeouts>("timeouts");
        }
        init { this._rawData.Set("timeouts", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelsItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelsItemFromRaw.FromRawUnchecked"/>
    public static ChannelsItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChannelsItemFromRaw : IFromRawJson<ChannelsItem>
{
    /// <inheritdoc/>
    public ChannelsItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelsItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Metadata, MetadataFromRaw>))]
public sealed record class Metadata : JsonModel
{
    public Utm? Utm
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Utm>("utm");
        }
        init { this._rawData.Set("utm", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetadataFromRaw.FromRawUnchecked"/>
    public static Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetadataFromRaw : IFromRawJson<Metadata>
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

[JsonConverter(typeof(JsonModelConverter<Timeouts, TimeoutsFromRaw>))]
public sealed record class Timeouts : JsonModel
{
    public long? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    public long? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("provider");
        }
        init { this._rawData.Set("provider", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Timeouts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimeoutsFromRaw.FromRawUnchecked"/>
    public static Timeouts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimeoutsFromRaw : IFromRawJson<Timeouts>
{
    /// <inheritdoc/>
    public Timeouts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Timeouts.FromRawUnchecked(rawData);
}

/// <summary>
/// Describes content that will work for email, inbox, push, chat, or any channel id.
/// </summary>
[JsonConverter(typeof(ContentConverter))]
public record class Content : ModelBase
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

    public Content(ElementalContentSugar value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(ElementalContent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(JsonElement element)
    {
        this._element = element;
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new CourierInvalidDataException("Data did not match any variant of Content");
        }
        this.Switch(
            (elementalContentSugar) => elementalContentSugar.Validate(),
            (elemental) => elemental.Validate()
        );
    }

    public virtual bool Equals(Content? other)
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

sealed class ContentConverter : JsonConverter<Content>
{
    public override Content? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalContentSugar>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalContent>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Delay, DelayFromRaw>))]
public sealed record class Delay : JsonModel
{
    /// <summary>
    /// The duration of the delay in milliseconds.
    /// </summary>
    public long? Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("duration");
        }
        init { this._rawData.Set("duration", value); }
    }

    /// <summary>
    /// IANA timezone identifier (e.g., "America/Los_Angeles", "UTC"). Used when
    /// resolving opening hours expressions. Takes precedence over user profile timezone settings.
    /// </summary>
    public string? Timezone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("timezone");
        }
        init { this._rawData.Set("timezone", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp or opening_hours-like format.
    /// </summary>
    public string? Until
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("until");
        }
        init { this._rawData.Set("until", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Duration;
        _ = this.Timezone;
        _ = this.Until;
    }

    public Delay() { }

    public Delay(Delay delay)
        : base(delay) { }

    public Delay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Delay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DelayFromRaw.FromRawUnchecked"/>
    public static Delay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DelayFromRaw : IFromRawJson<Delay>
{
    /// <inheritdoc/>
    public Delay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Delay.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Expiry, ExpiryFromRaw>))]
public sealed record class Expiry : JsonModel
{
    /// <summary>
    /// Duration in ms or ISO8601 duration (e.g. P1DT4H).
    /// </summary>
    public required ExpiresIn ExpiresIn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ExpiresIn>("expires_in");
        }
        init { this._rawData.Set("expires_in", value); }
    }

    /// <summary>
    /// Epoch or ISO8601 timestamp with timezone.
    /// </summary>
    public string? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Expiry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class ExpiryFromRaw : IFromRawJson<Expiry>
{
    /// <inheritdoc/>
    public Expiry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Expiry.FromRawUnchecked(rawData);
}

/// <summary>
/// Duration in ms or ISO8601 duration (e.g. P1DT4H).
/// </summary>
[JsonConverter(typeof(ExpiresInConverter))]
public record class ExpiresIn : ModelBase
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

    public ExpiresIn(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExpiresIn(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ExpiresIn(JsonElement element)
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
    public override void Validate()
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

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class ExpiresInConverter : JsonConverter<ExpiresIn>
{
    public override ExpiresIn? Read(
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
            return new(JsonSerializer.Deserialize<long>(element, options));
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        return new(element);
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

[JsonConverter(typeof(JsonModelConverter<MessageMetadata, MessageMetadataFromRaw>))]
public sealed record class MessageMetadata : JsonModel
{
    public string? Event
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("event");
        }
        init { this._rawData.Set("event", value); }
    }

    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? TraceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("trace_id");
        }
        init { this._rawData.Set("trace_id", value); }
    }

    public Utm? Utm
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Utm>("utm");
        }
        init { this._rawData.Set("utm", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageMetadataFromRaw.FromRawUnchecked"/>
    public static MessageMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageMetadataFromRaw : IFromRawJson<MessageMetadata>
{
    /// <inheritdoc/>
    public MessageMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Courier.Models.Send.Preferences,
        global::Courier.Models.Send.PreferencesFromRaw
    >)
)]
public sealed record class Preferences : JsonModel
{
    /// <summary>
    /// The subscription topic to apply to the message.
    /// </summary>
    public required string SubscriptionTopicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subscription_topic_id");
        }
        init { this._rawData.Set("subscription_topic_id", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Preferences(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class PreferencesFromRaw : IFromRawJson<global::Courier.Models.Send.Preferences>
{
    /// <inheritdoc/>
    public global::Courier.Models.Send.Preferences FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Courier.Models.Send.Preferences.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ProvidersItem, ProvidersItemFromRaw>))]
public sealed record class ProvidersItem : JsonModel
{
    /// <summary>
    /// JS conditional with access to data/profile.
    /// </summary>
    public string? If
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("if");
        }
        init { this._rawData.Set("if", value); }
    }

    public ProvidersItemMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ProvidersItemMetadata>("metadata");
        }
        init { this._rawData.Set("metadata", value); }
    }

    /// <summary>
    /// Provider-specific overrides.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Override
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "override"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "override",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public long? Timeouts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("timeouts");
        }
        init { this._rawData.Set("timeouts", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProvidersItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProvidersItemFromRaw.FromRawUnchecked"/>
    public static ProvidersItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProvidersItemFromRaw : IFromRawJson<ProvidersItem>
{
    /// <inheritdoc/>
    public ProvidersItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ProvidersItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ProvidersItemMetadata, ProvidersItemMetadataFromRaw>))]
public sealed record class ProvidersItemMetadata : JsonModel
{
    public Utm? Utm
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Utm>("utm");
        }
        init { this._rawData.Set("utm", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProvidersItemMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class ProvidersItemMetadataFromRaw : IFromRawJson<ProvidersItemMetadata>
{
    /// <inheritdoc/>
    public ProvidersItemMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProvidersItemMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Customize which channels/providers Courier may deliver the message through.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Routing, RoutingFromRaw>))]
public sealed record class Routing : JsonModel
{
    /// <summary>
    /// A list of channels or providers (or nested routing rules).
    /// </summary>
    public required IReadOnlyList<MessageRoutingChannel> Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MessageRoutingChannel>>(
                "channels"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<MessageRoutingChannel>>(
                "channels",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, global::Courier.Models.Send.Method> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Courier.Models.Send.Method>
            >("method");
        }
        init { this._rawData.Set("method", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Routing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RoutingFromRaw.FromRawUnchecked"/>
    public static Routing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RoutingFromRaw : IFromRawJson<Routing>
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

[JsonConverter(typeof(JsonModelConverter<Timeout, TimeoutFromRaw>))]
public sealed record class Timeout : JsonModel
{
    public IReadOnlyDictionary<string, long>? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, long>>("channel");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, long>?>(
                "channel",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public ApiEnum<string, Criteria>? Criteria
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Criteria>>("criteria");
        }
        init { this._rawData.Set("criteria", value); }
    }

    public long? Escalation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("escalation");
        }
        init { this._rawData.Set("escalation", value); }
    }

    public long? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    public IReadOnlyDictionary<string, long>? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, long>>("provider");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, long>?>(
                "provider",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Timeout(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimeoutFromRaw.FromRawUnchecked"/>
    public static Timeout FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimeoutFromRaw : IFromRawJson<Timeout>
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
public record class To : ModelBase
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

    public string? ListID
    {
        get
        {
            return Match<string?>(
                userRecipient: (x) => x.ListID,
                audienceRecipient: (_) => null,
                listRecipient: (x) => x.ListID,
                listPatternRecipient: (_) => null,
                slackRecipient: (_) => null,
                msTeamsRecipient: (_) => null,
                pagerdutyRecipient: (_) => null,
                webhookRecipient: (_) => null
            );
        }
    }

    public To(UserRecipient value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To(AudienceRecipient value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To(ListRecipient value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To(ListPatternRecipient value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To(SlackRecipient value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To(MsTeamsRecipient value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To(PagerdutyRecipient value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To(WebhookRecipient value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To(JsonElement element)
    {
        this._element = element;
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
    /// type <see cref="AudienceRecipient"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAudienceRecipient(out var value)) {
    ///     // `value` is of type `AudienceRecipient`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAudienceRecipient([NotNullWhen(true)] out AudienceRecipient? value)
    {
        value = this.Value as AudienceRecipient;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ListRecipient"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickListRecipient(out var value)) {
    ///     // `value` is of type `ListRecipient`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickListRecipient([NotNullWhen(true)] out ListRecipient? value)
    {
        value = this.Value as ListRecipient;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ListPatternRecipient"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickListPatternRecipient(out var value)) {
    ///     // `value` is of type `ListPatternRecipient`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickListPatternRecipient([NotNullWhen(true)] out ListPatternRecipient? value)
    {
        value = this.Value as ListPatternRecipient;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SlackRecipient"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSlackRecipient(out var value)) {
    ///     // `value` is of type `SlackRecipient`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSlackRecipient([NotNullWhen(true)] out SlackRecipient? value)
    {
        value = this.Value as SlackRecipient;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MsTeamsRecipient"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMsTeamsRecipient(out var value)) {
    ///     // `value` is of type `MsTeamsRecipient`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMsTeamsRecipient([NotNullWhen(true)] out MsTeamsRecipient? value)
    {
        value = this.Value as MsTeamsRecipient;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PagerdutyRecipient"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPagerdutyRecipient(out var value)) {
    ///     // `value` is of type `PagerdutyRecipient`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPagerdutyRecipient([NotNullWhen(true)] out PagerdutyRecipient? value)
    {
        value = this.Value as PagerdutyRecipient;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebhookRecipient"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebhookRecipient(out var value)) {
    ///     // `value` is of type `WebhookRecipient`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebhookRecipient([NotNullWhen(true)] out WebhookRecipient? value)
    {
        value = this.Value as WebhookRecipient;
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
    ///     (AudienceRecipient value) => {...},
    ///     (ListRecipient value) => {...},
    ///     (ListPatternRecipient value) => {...},
    ///     (SlackRecipient value) => {...},
    ///     (MsTeamsRecipient value) => {...},
    ///     (PagerdutyRecipient value) => {...},
    ///     (WebhookRecipient value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<UserRecipient> userRecipient,
        System::Action<AudienceRecipient> audienceRecipient,
        System::Action<ListRecipient> listRecipient,
        System::Action<ListPatternRecipient> listPatternRecipient,
        System::Action<SlackRecipient> slackRecipient,
        System::Action<MsTeamsRecipient> msTeamsRecipient,
        System::Action<PagerdutyRecipient> pagerdutyRecipient,
        System::Action<WebhookRecipient> webhookRecipient
    )
    {
        switch (this.Value)
        {
            case UserRecipient value:
                userRecipient(value);
                break;
            case AudienceRecipient value:
                audienceRecipient(value);
                break;
            case ListRecipient value:
                listRecipient(value);
                break;
            case ListPatternRecipient value:
                listPatternRecipient(value);
                break;
            case SlackRecipient value:
                slackRecipient(value);
                break;
            case MsTeamsRecipient value:
                msTeamsRecipient(value);
                break;
            case PagerdutyRecipient value:
                pagerdutyRecipient(value);
                break;
            case WebhookRecipient value:
                webhookRecipient(value);
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
    ///     (AudienceRecipient value) => {...},
    ///     (ListRecipient value) => {...},
    ///     (ListPatternRecipient value) => {...},
    ///     (SlackRecipient value) => {...},
    ///     (MsTeamsRecipient value) => {...},
    ///     (PagerdutyRecipient value) => {...},
    ///     (WebhookRecipient value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<UserRecipient, T> userRecipient,
        System::Func<AudienceRecipient, T> audienceRecipient,
        System::Func<ListRecipient, T> listRecipient,
        System::Func<ListPatternRecipient, T> listPatternRecipient,
        System::Func<SlackRecipient, T> slackRecipient,
        System::Func<MsTeamsRecipient, T> msTeamsRecipient,
        System::Func<PagerdutyRecipient, T> pagerdutyRecipient,
        System::Func<WebhookRecipient, T> webhookRecipient
    )
    {
        return this.Value switch
        {
            UserRecipient value => userRecipient(value),
            AudienceRecipient value => audienceRecipient(value),
            ListRecipient value => listRecipient(value),
            ListPatternRecipient value => listPatternRecipient(value),
            SlackRecipient value => slackRecipient(value),
            MsTeamsRecipient value => msTeamsRecipient(value),
            PagerdutyRecipient value => pagerdutyRecipient(value),
            WebhookRecipient value => webhookRecipient(value),
            _ => throw new CourierInvalidDataException("Data did not match any variant of To"),
        };
    }

    public static implicit operator To(UserRecipient value) => new(value);

    public static implicit operator To(AudienceRecipient value) => new(value);

    public static implicit operator To(ListRecipient value) => new(value);

    public static implicit operator To(ListPatternRecipient value) => new(value);

    public static implicit operator To(SlackRecipient value) => new(value);

    public static implicit operator To(MsTeamsRecipient value) => new(value);

    public static implicit operator To(PagerdutyRecipient value) => new(value);

    public static implicit operator To(WebhookRecipient value) => new(value);

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
            throw new CourierInvalidDataException("Data did not match any variant of To");
        }
        this.Switch(
            (userRecipient) => userRecipient.Validate(),
            (audienceRecipient) => audienceRecipient.Validate(),
            (listRecipient) => listRecipient.Validate(),
            (listPatternRecipient) => listPatternRecipient.Validate(),
            (slackRecipient) => slackRecipient.Validate(),
            (msTeamsRecipient) => msTeamsRecipient.Validate(),
            (pagerdutyRecipient) => pagerdutyRecipient.Validate(),
            (webhookRecipient) => webhookRecipient.Validate()
        );
    }

    public virtual bool Equals(To? other)
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

sealed class ToConverter : JsonConverter<To?>
{
    public override To? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<UserRecipient>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<AudienceRecipient>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ListRecipient>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ListPatternRecipient>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SlackRecipient>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<MsTeamsRecipient>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PagerdutyRecipient>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<WebhookRecipient>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, To? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
