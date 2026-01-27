using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Notifications;

[JsonConverter(typeof(JsonModelConverter<NotificationGetContent, NotificationGetContentFromRaw>))]
public sealed record class NotificationGetContent : JsonModel
{
    public IReadOnlyList<Block>? Blocks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Block>>("blocks");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Block>?>(
                "blocks",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<Channel>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Channel>>("channels");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Channel>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Checksum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("checksum");
        }
        init { this._rawData.Set("checksum", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Blocks ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Channels ?? [])
        {
            item.Validate();
        }
        _ = this.Checksum;
    }

    public NotificationGetContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationGetContent(NotificationGetContent notificationGetContent)
        : base(notificationGetContent) { }
#pragma warning restore CS8618

    public NotificationGetContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationGetContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationGetContentFromRaw.FromRawUnchecked"/>
    public static NotificationGetContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationGetContentFromRaw : IFromRawJson<NotificationGetContent>
{
    /// <inheritdoc/>
    public NotificationGetContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationGetContent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Block, BlockFromRaw>))]
public sealed record class Block : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, BlockType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BlockType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public string? Alias
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("alias");
        }
        init { this._rawData.Set("alias", value); }
    }

    public string? Checksum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("checksum");
        }
        init { this._rawData.Set("checksum", value); }
    }

    public Content? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Content>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public string? Context
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("context");
        }
        init { this._rawData.Set("context", value); }
    }

    public IReadOnlyDictionary<string, Locale>? Locales
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, Locale>>("locales");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, Locale>?>(
                "locales",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
        _ = this.Alias;
        _ = this.Checksum;
        this.Content?.Validate();
        _ = this.Context;
        if (this.Locales != null)
        {
            foreach (var item in this.Locales.Values)
            {
                item.Validate();
            }
        }
    }

    public Block() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Block(Block block)
        : base(block) { }
#pragma warning restore CS8618

    public Block(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Block(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlockFromRaw.FromRawUnchecked"/>
    public static Block FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BlockFromRaw : IFromRawJson<Block>
{
    /// <inheritdoc/>
    public Block FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Block.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BlockTypeConverter))]
public enum BlockType
{
    Action,
    Divider,
    Image,
    Jsonnet,
    List,
    Markdown,
    Quote,
    Template,
    Text,
}

sealed class BlockTypeConverter : JsonConverter<BlockType>
{
    public override BlockType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "action" => BlockType.Action,
            "divider" => BlockType.Divider,
            "image" => BlockType.Image,
            "jsonnet" => BlockType.Jsonnet,
            "list" => BlockType.List,
            "markdown" => BlockType.Markdown,
            "quote" => BlockType.Quote,
            "template" => BlockType.Template,
            "text" => BlockType.Text,
            _ => (BlockType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BlockType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BlockType.Action => "action",
                BlockType.Divider => "divider",
                BlockType.Image => "image",
                BlockType.Jsonnet => "jsonnet",
                BlockType.List => "list",
                BlockType.Markdown => "markdown",
                BlockType.Quote => "quote",
                BlockType.Template => "template",
                BlockType.Text => "text",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

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

    public Content(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Content(NotificationContentHierarchy value, JsonElement? element = null)
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
    /// type <see cref="NotificationContentHierarchy"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotificationContentHierarchy(out var value)) {
    ///     // `value` is of type `NotificationContentHierarchy`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotificationContentHierarchy(
        [NotNullWhen(true)] out NotificationContentHierarchy? value
    )
    {
        value = this.Value as NotificationContentHierarchy;
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
    ///     (NotificationContentHierarchy value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<NotificationContentHierarchy> notificationContentHierarchy
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case NotificationContentHierarchy value:
                notificationContentHierarchy(value);
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
    ///     (string value) => {...},
    ///     (NotificationContentHierarchy value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<NotificationContentHierarchy, T> notificationContentHierarchy
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            NotificationContentHierarchy value => notificationContentHierarchy(value),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Content"),
        };
    }

    public static implicit operator Content(string value) => new(value);

    public static implicit operator Content(NotificationContentHierarchy value) => new(value);

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
            (_) => { },
            (notificationContentHierarchy) => notificationContentHierarchy.Validate()
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

sealed class ContentConverter : JsonConverter<Content?>
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
            var deserialized = JsonSerializer.Deserialize<NotificationContentHierarchy>(
                element,
                options
            );
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

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Content? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<NotificationContentHierarchy, NotificationContentHierarchyFromRaw>)
)]
public sealed record class NotificationContentHierarchy : JsonModel
{
    public string? Children
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("children");
        }
        init { this._rawData.Set("children", value); }
    }

    public string? Parent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parent");
        }
        init { this._rawData.Set("parent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Children;
        _ = this.Parent;
    }

    public NotificationContentHierarchy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationContentHierarchy(NotificationContentHierarchy notificationContentHierarchy)
        : base(notificationContentHierarchy) { }
#pragma warning restore CS8618

    public NotificationContentHierarchy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationContentHierarchy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationContentHierarchyFromRaw.FromRawUnchecked"/>
    public static NotificationContentHierarchy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationContentHierarchyFromRaw : IFromRawJson<NotificationContentHierarchy>
{
    /// <inheritdoc/>
    public NotificationContentHierarchy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationContentHierarchy.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(LocaleConverter))]
public record class Locale : ModelBase
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

    public Locale(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Locale(LocaleNotificationContentHierarchy value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Locale(JsonElement element)
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
    /// type <see cref="LocaleNotificationContentHierarchy"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNotificationContentHierarchy(out var value)) {
    ///     // `value` is of type `LocaleNotificationContentHierarchy`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNotificationContentHierarchy(
        [NotNullWhen(true)] out LocaleNotificationContentHierarchy? value
    )
    {
        value = this.Value as LocaleNotificationContentHierarchy;
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
    ///     (LocaleNotificationContentHierarchy value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<LocaleNotificationContentHierarchy> notificationContentHierarchy
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case LocaleNotificationContentHierarchy value:
                notificationContentHierarchy(value);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Locale");
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
    ///     (LocaleNotificationContentHierarchy value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<LocaleNotificationContentHierarchy, T> notificationContentHierarchy
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            LocaleNotificationContentHierarchy value => notificationContentHierarchy(value),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Locale"),
        };
    }

    public static implicit operator Locale(string value) => new(value);

    public static implicit operator Locale(LocaleNotificationContentHierarchy value) => new(value);

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
            throw new CourierInvalidDataException("Data did not match any variant of Locale");
        }
        this.Switch(
            (_) => { },
            (notificationContentHierarchy) => notificationContentHierarchy.Validate()
        );
    }

    public virtual bool Equals(Locale? other)
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

sealed class LocaleConverter : JsonConverter<Locale>
{
    public override Locale? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<LocaleNotificationContentHierarchy>(
                element,
                options
            );
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

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Locale value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        LocaleNotificationContentHierarchy,
        LocaleNotificationContentHierarchyFromRaw
    >)
)]
public sealed record class LocaleNotificationContentHierarchy : JsonModel
{
    public string? Children
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("children");
        }
        init { this._rawData.Set("children", value); }
    }

    public string? Parent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parent");
        }
        init { this._rawData.Set("parent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Children;
        _ = this.Parent;
    }

    public LocaleNotificationContentHierarchy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LocaleNotificationContentHierarchy(
        LocaleNotificationContentHierarchy localeNotificationContentHierarchy
    )
        : base(localeNotificationContentHierarchy) { }
#pragma warning restore CS8618

    public LocaleNotificationContentHierarchy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LocaleNotificationContentHierarchy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LocaleNotificationContentHierarchyFromRaw.FromRawUnchecked"/>
    public static LocaleNotificationContentHierarchy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LocaleNotificationContentHierarchyFromRaw : IFromRawJson<LocaleNotificationContentHierarchy>
{
    /// <inheritdoc/>
    public LocaleNotificationContentHierarchy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LocaleNotificationContentHierarchy.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Channel, ChannelFromRaw>))]
public sealed record class Channel : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public string? Checksum
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("checksum");
        }
        init { this._rawData.Set("checksum", value); }
    }

    public ChannelContent? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChannelContent>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public IReadOnlyDictionary<string, LocalesItem>? Locales
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, LocalesItem>>("locales");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, LocalesItem>?>(
                "locales",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Checksum;
        this.Content?.Validate();
        if (this.Locales != null)
        {
            foreach (var item in this.Locales.Values)
            {
                item.Validate();
            }
        }
        _ = this.Type;
    }

    public Channel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Channel(Channel channel)
        : base(channel) { }
#pragma warning restore CS8618

    public Channel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Channel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelFromRaw.FromRawUnchecked"/>
    public static Channel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Channel(string id)
        : this()
    {
        this.ID = id;
    }
}

class ChannelFromRaw : IFromRawJson<Channel>
{
    /// <inheritdoc/>
    public Channel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Channel.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ChannelContent, ChannelContentFromRaw>))]
public sealed record class ChannelContent : JsonModel
{
    public string? Subject
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subject");
        }
        init { this._rawData.Set("subject", value); }
    }

    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Subject;
        _ = this.Title;
    }

    public ChannelContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelContent(ChannelContent channelContent)
        : base(channelContent) { }
#pragma warning restore CS8618

    public ChannelContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelContentFromRaw.FromRawUnchecked"/>
    public static ChannelContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChannelContentFromRaw : IFromRawJson<ChannelContent>
{
    /// <inheritdoc/>
    public ChannelContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelContent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<LocalesItem, LocalesItemFromRaw>))]
public sealed record class LocalesItem : JsonModel
{
    public string? Subject
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subject");
        }
        init { this._rawData.Set("subject", value); }
    }

    public string? Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Subject;
        _ = this.Title;
    }

    public LocalesItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LocalesItem(LocalesItem localesItem)
        : base(localesItem) { }
#pragma warning restore CS8618

    public LocalesItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LocalesItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LocalesItemFromRaw.FromRawUnchecked"/>
    public static LocalesItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LocalesItemFromRaw : IFromRawJson<LocalesItem>
{
    /// <inheritdoc/>
    public LocalesItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LocalesItem.FromRawUnchecked(rawData);
}
