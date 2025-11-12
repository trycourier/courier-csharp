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
/// API to send a message to one or more recipients.
/// </summary>
public sealed record class SendMessageParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    /// <summary>
    /// The message property has the following primary top-level properties. They
    /// define the destination and content of the message.
    /// </summary>
    public required Message Message
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("message", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'message' cannot be null",
                    new System::ArgumentOutOfRangeException("message", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Message>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'message' cannot be null",
                    new System::ArgumentNullException("message")
                );
        }
        init
        {
            this._bodyProperties["message"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public SendMessageParams() { }

    public SendMessageParams(
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
    SendMessageParams(
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

    public static SendMessageParams FromRawUnchecked(
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/send")
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

/// <summary>
/// The message property has the following primary top-level properties. They define
/// the destination and content of the message.
/// </summary>
[JsonConverter(typeof(ModelConverter<Message>))]
public sealed record class Message : ModelBase, IFromRaw<Message>
{
    public string? BrandID
    {
        get
        {
            if (!this._properties.TryGetValue("brand_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["brand_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Define run-time configuration for channels. Valid ChannelId's: email, sms,
    /// push, inbox, direct_message, banner, webhook.
    /// </summary>
    public Dictionary<string, ChannelsItem>? Channels
    {
        get
        {
            if (!this._properties.TryGetValue("channels", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, ChannelsItem>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["channels"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Content?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public MessageContext? Context
    {
        get
        {
            if (!this._properties.TryGetValue("context", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<MessageContext?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["context"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Data
    {
        get
        {
            if (!this._properties.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Delay? Delay
    {
        get
        {
            if (!this._properties.TryGetValue("delay", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Delay?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["delay"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Expiry? Expiry
    {
        get
        {
            if (!this._properties.TryGetValue("expiry", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Expiry?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["expiry"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public MetadataModel? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<MetadataModel?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public global::Courier.Models.Send.Preferences? Preferences
    {
        get
        {
            if (!this._properties.TryGetValue("preferences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<global::Courier.Models.Send.Preferences?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["preferences"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, ProvidersItem>? Providers
    {
        get
        {
            if (!this._properties.TryGetValue("providers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, ProvidersItem>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["providers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Routing?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["routing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Template
    {
        get
        {
            if (!this._properties.TryGetValue("template", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["template"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Timeout? Timeout
    {
        get
        {
            if (!this._properties.TryGetValue("timeout", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Timeout?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["timeout"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The recipient or a list of recipients of the message
    /// </summary>
    public To? To
    {
        get
        {
            if (!this._properties.TryGetValue("to", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<To?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["to"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public Message(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Message(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<ChannelsItem>))]
public sealed record class ChannelsItem : ModelBase, IFromRaw<ChannelsItem>
{
    /// <summary>
    /// Brand id used for rendering.
    /// </summary>
    public string? BrandID
    {
        get
        {
            if (!this._properties.TryGetValue("brand_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["brand_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// JS conditional with access to data/profile.
    /// </summary>
    public string? If
    {
        get
        {
            if (!this._properties.TryGetValue("if", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["if"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Metadata? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Metadata?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Channel specific overrides.
    /// </summary>
    public Dictionary<string, JsonElement>? Override
    {
        get
        {
            if (!this._properties.TryGetValue("override", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["override"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Providers enabled for this channel.
    /// </summary>
    public List<string>? Providers
    {
        get
        {
            if (!this._properties.TryGetValue("providers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["providers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this._properties.TryGetValue("routing_method", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, RoutingMethod>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["routing_method"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Timeouts? Timeouts
    {
        get
        {
            if (!this._properties.TryGetValue("timeouts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Timeouts?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["timeouts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public ChannelsItem(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelsItem(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ChannelsItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<Metadata>))]
public sealed record class Metadata : ModelBase, IFromRaw<Metadata>
{
    public Utm? Utm
    {
        get
        {
            if (!this._properties.TryGetValue("utm", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Utm?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["utm"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Utm?.Validate();
    }

    public Metadata() { }

    public Metadata(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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

[JsonConverter(typeof(ModelConverter<Timeouts>))]
public sealed record class Timeouts : ModelBase, IFromRaw<Timeouts>
{
    public long? Channel
    {
        get
        {
            if (!this._properties.TryGetValue("channel", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["channel"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? Provider
    {
        get
        {
            if (!this._properties.TryGetValue("provider", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["provider"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Channel;
        _ = this.Provider;
    }

    public Timeouts() { }

    public Timeouts(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Timeouts(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Timeouts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Describes content that will work for email, inbox, push, chat, or any channel id.
/// </summary>
[JsonConverter(typeof(ContentConverter))]
public record class Content
{
    public object Value { get; private init; }

    public Content(ElementalContentSugar value)
    {
        Value = value;
    }

    public Content(ElementalContent value)
    {
        Value = value;
    }

    Content(UnknownVariant value)
    {
        Value = value;
    }

    public static Content CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickElementalContentSugar([NotNullWhen(true)] out ElementalContentSugar? value)
    {
        value = this.Value as ElementalContentSugar;
        return value != null;
    }

    public bool TryPickElemental([NotNullWhen(true)] out ElementalContent? value)
    {
        value = this.Value as ElementalContent;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new CourierInvalidDataException("Data did not match any variant of Content");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ContentConverter : JsonConverter<Content>
{
    public override Content? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalContentSugar>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'ElementalContentSugar'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementalContent>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'ElementalContent'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<Delay>))]
public sealed record class Delay : ModelBase, IFromRaw<Delay>
{
    /// <summary>
    /// The duration of the delay in milliseconds.
    /// </summary>
    public long? Duration
    {
        get
        {
            if (!this._properties.TryGetValue("duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// ISO 8601 timestamp or opening_hours-like format.
    /// </summary>
    public string? Until
    {
        get
        {
            if (!this._properties.TryGetValue("until", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["until"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Duration;
        _ = this.Until;
    }

    public Delay() { }

    public Delay(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Delay(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Delay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<Expiry>))]
public sealed record class Expiry : ModelBase, IFromRaw<Expiry>
{
    /// <summary>
    /// Duration in ms or ISO8601 duration (e.g. P1DT4H).
    /// </summary>
    public required ExpiresIn ExpiresIn
    {
        get
        {
            if (!this._properties.TryGetValue("expires_in", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'expires_in' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "expires_in",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ExpiresIn>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'expires_in' cannot be null",
                    new System::ArgumentNullException("expires_in")
                );
        }
        init
        {
            this._properties["expires_in"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Epoch or ISO8601 timestamp with timezone.
    /// </summary>
    public string? ExpiresAt
    {
        get
        {
            if (!this._properties.TryGetValue("expires_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["expires_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.ExpiresIn.Validate();
        _ = this.ExpiresAt;
    }

    public Expiry() { }

    public Expiry(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Expiry(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Expiry FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Expiry(ExpiresIn expiresIn)
        : this()
    {
        this.ExpiresIn = expiresIn;
    }
}

/// <summary>
/// Duration in ms or ISO8601 duration (e.g. P1DT4H).
/// </summary>
[JsonConverter(typeof(ExpiresInConverter))]
public record class ExpiresIn
{
    public object Value { get; private init; }

    public ExpiresIn(string value)
    {
        Value = value;
    }

    public ExpiresIn(long value)
    {
        Value = value;
    }

    ExpiresIn(UnknownVariant value)
    {
        Value = value;
    }

    public static ExpiresIn CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new CourierInvalidDataException("Data did not match any variant of ExpiresIn");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ExpiresInConverter : JsonConverter<ExpiresIn>
{
    public override ExpiresIn? Read(
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
                return new ExpiresIn(deserialized);
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
            return new ExpiresIn(JsonSerializer.Deserialize<long>(ref reader, options));
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException("Data does not match union variant 'long'", e)
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExpiresIn value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<MetadataModel>))]
public sealed record class MetadataModel : ModelBase, IFromRaw<MetadataModel>
{
    public string? Event
    {
        get
        {
            if (!this._properties.TryGetValue("event", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["event"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<string>? Tags
    {
        get
        {
            if (!this._properties.TryGetValue("tags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["tags"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? TraceID
    {
        get
        {
            if (!this._properties.TryGetValue("trace_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["trace_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Utm? Utm
    {
        get
        {
            if (!this._properties.TryGetValue("utm", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Utm?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["utm"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Event;
        _ = this.Tags;
        _ = this.TraceID;
        this.Utm?.Validate();
    }

    public MetadataModel() { }

    public MetadataModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MetadataModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MetadataModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<global::Courier.Models.Send.Preferences>))]
public sealed record class Preferences
    : ModelBase,
        IFromRaw<global::Courier.Models.Send.Preferences>
{
    /// <summary>
    /// The subscription topic to apply to the message.
    /// </summary>
    public required string SubscriptionTopicID
    {
        get
        {
            if (!this._properties.TryGetValue("subscription_topic_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'subscription_topic_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "subscription_topic_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'subscription_topic_id' cannot be null",
                    new System::ArgumentNullException("subscription_topic_id")
                );
        }
        init
        {
            this._properties["subscription_topic_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.SubscriptionTopicID;
    }

    public Preferences() { }

    public Preferences(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Preferences(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static global::Courier.Models.Send.Preferences FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Preferences(string subscriptionTopicID)
        : this()
    {
        this.SubscriptionTopicID = subscriptionTopicID;
    }
}

[JsonConverter(typeof(ModelConverter<ProvidersItem>))]
public sealed record class ProvidersItem : ModelBase, IFromRaw<ProvidersItem>
{
    /// <summary>
    /// JS conditional with access to data/profile.
    /// </summary>
    public string? If
    {
        get
        {
            if (!this._properties.TryGetValue("if", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["if"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Metadata1? Metadata
    {
        get
        {
            if (!this._properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Metadata1?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Provider-specific overrides.
    /// </summary>
    public Dictionary<string, JsonElement>? Override
    {
        get
        {
            if (!this._properties.TryGetValue("override", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["override"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? Timeouts
    {
        get
        {
            if (!this._properties.TryGetValue("timeouts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["timeouts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.If;
        this.Metadata?.Validate();
        _ = this.Override;
        _ = this.Timeouts;
    }

    public ProvidersItem() { }

    public ProvidersItem(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProvidersItem(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ProvidersItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<Metadata1>))]
public sealed record class Metadata1 : ModelBase, IFromRaw<Metadata1>
{
    public Utm? Utm
    {
        get
        {
            if (!this._properties.TryGetValue("utm", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Utm?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["utm"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Utm?.Validate();
    }

    public Metadata1() { }

    public Metadata1(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata1(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Metadata1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Customize which channels/providers Courier may deliver the message through.
/// </summary>
[JsonConverter(typeof(ModelConverter<Routing>))]
public sealed record class Routing : ModelBase, IFromRaw<Routing>
{
    /// <summary>
    /// A list of channels or providers (or nested routing rules).
    /// </summary>
    public required List<MessageRoutingChannel> Channels
    {
        get
        {
            if (!this._properties.TryGetValue("channels", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channels' cannot be null",
                    new System::ArgumentOutOfRangeException("channels", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<MessageRoutingChannel>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'channels' cannot be null",
                    new System::ArgumentNullException("channels")
                );
        }
        init
        {
            this._properties["channels"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Courier.Models.Send.Method> Method
    {
        get
        {
            if (!this._properties.TryGetValue("method", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'method' cannot be null",
                    new System::ArgumentOutOfRangeException("method", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, global::Courier.Models.Send.Method>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["method"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Channels)
        {
            item.Validate();
        }
        this.Method.Validate();
    }

    public Routing() { }

    public Routing(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Routing(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Routing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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

[JsonConverter(typeof(ModelConverter<Timeout>))]
public sealed record class Timeout : ModelBase, IFromRaw<Timeout>
{
    public Dictionary<string, long>? Channel
    {
        get
        {
            if (!this._properties.TryGetValue("channel", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, long>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["channel"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, Criteria>? Criteria
    {
        get
        {
            if (!this._properties.TryGetValue("criteria", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Criteria>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["criteria"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? Escalation
    {
        get
        {
            if (!this._properties.TryGetValue("escalation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["escalation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? Message
    {
        get
        {
            if (!this._properties.TryGetValue("message", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["message"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, long>? Provider
    {
        get
        {
            if (!this._properties.TryGetValue("provider", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, long>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["provider"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Channel;
        this.Criteria?.Validate();
        _ = this.Escalation;
        _ = this.Message;
        _ = this.Provider;
    }

    public Timeout() { }

    public Timeout(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Timeout(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Timeout FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
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
    public object Value { get; private init; }

    public To(UserRecipient value)
    {
        Value = value;
    }

    public To(IReadOnlyList<Recipient> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    To(UnknownVariant value)
    {
        Value = value;
    }

    public static To CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickUserRecipient([NotNullWhen(true)] out UserRecipient? value)
    {
        value = this.Value as UserRecipient;
        return value != null;
    }

    public bool TryPickRecipients([NotNullWhen(true)] out IReadOnlyList<Recipient>? value)
    {
        value = this.Value as IReadOnlyList<Recipient>;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new CourierInvalidDataException("Data did not match any variant of To");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ToConverter : JsonConverter<To?>
{
    public override To? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<UserRecipient>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new To(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'UserRecipient'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<Recipient>>(ref reader, options);
            if (deserialized != null)
            {
                return new To(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'List<Recipient>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, To? value, JsonSerializerOptions options)
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
