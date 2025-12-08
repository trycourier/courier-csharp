using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Notifications;

[JsonConverter(typeof(ModelConverter<NotificationGetContent, NotificationGetContentFromRaw>))]
public sealed record class NotificationGetContent : ModelBase
{
    public IReadOnlyList<Block>? Blocks
    {
        get { return ModelBase.GetNullableClass<List<Block>>(this.RawData, "blocks"); }
        init { ModelBase.Set(this._rawData, "blocks", value); }
    }

    public IReadOnlyList<Channel>? Channels
    {
        get { return ModelBase.GetNullableClass<List<Channel>>(this.RawData, "channels"); }
        init { ModelBase.Set(this._rawData, "channels", value); }
    }

    public string? Checksum
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "checksum"); }
        init { ModelBase.Set(this._rawData, "checksum", value); }
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

    public NotificationGetContent(NotificationGetContent notificationGetContent)
        : base(notificationGetContent) { }

    public NotificationGetContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationGetContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class NotificationGetContentFromRaw : IFromRaw<NotificationGetContent>
{
    /// <inheritdoc/>
    public NotificationGetContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationGetContent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Block, BlockFromRaw>))]
public sealed record class Block : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required ApiEnum<string, BlockType> Type
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<string, BlockType>>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public string? Alias
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "alias"); }
        init { ModelBase.Set(this._rawData, "alias", value); }
    }

    public string? Checksum
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "checksum"); }
        init { ModelBase.Set(this._rawData, "checksum", value); }
    }

    public Content? Content
    {
        get { return ModelBase.GetNullableClass<Content>(this.RawData, "content"); }
        init { ModelBase.Set(this._rawData, "content", value); }
    }

    public string? Context
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "context"); }
        init { ModelBase.Set(this._rawData, "context", value); }
    }

    public IReadOnlyDictionary<string, Locale>? Locales
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, Locale>>(this.RawData, "locales");
        }
        init { ModelBase.Set(this._rawData, "locales", value); }
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

    public Block(Block block)
        : base(block) { }

    public Block(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Block(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlockFromRaw.FromRawUnchecked"/>
    public static Block FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BlockFromRaw : IFromRaw<Block>
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
public record class Content
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public Content(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Content(NotificationContentHierarchy value, JsonElement? json = null)
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

sealed class ContentConverter : JsonConverter<Content?>
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
            var deserialized = JsonSerializer.Deserialize<NotificationContentHierarchy>(
                json,
                options
            );
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

        return new(json);
    }

    public override void Write(Utf8JsonWriter writer, Content? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<NotificationContentHierarchy, NotificationContentHierarchyFromRaw>)
)]
public sealed record class NotificationContentHierarchy : ModelBase
{
    public string? Children
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "children"); }
        init { ModelBase.Set(this._rawData, "children", value); }
    }

    public string? Parent
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "parent"); }
        init { ModelBase.Set(this._rawData, "parent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Children;
        _ = this.Parent;
    }

    public NotificationContentHierarchy() { }

    public NotificationContentHierarchy(NotificationContentHierarchy notificationContentHierarchy)
        : base(notificationContentHierarchy) { }

    public NotificationContentHierarchy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationContentHierarchy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class NotificationContentHierarchyFromRaw : IFromRaw<NotificationContentHierarchy>
{
    /// <inheritdoc/>
    public NotificationContentHierarchy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationContentHierarchy.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(LocaleConverter))]
public record class Locale
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public Locale(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Locale(LocaleNotificationContentHierarchy value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Locale(JsonElement json)
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new CourierInvalidDataException("Data did not match any variant of Locale");
        }
    }

    public virtual bool Equals(Locale? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class LocaleConverter : JsonConverter<Locale>
{
    public override Locale? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<LocaleNotificationContentHierarchy>(
                json,
                options
            );
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

        return new(json);
    }

    public override void Write(Utf8JsonWriter writer, Locale value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(ModelConverter<
        LocaleNotificationContentHierarchy,
        LocaleNotificationContentHierarchyFromRaw
    >)
)]
public sealed record class LocaleNotificationContentHierarchy : ModelBase
{
    public string? Children
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "children"); }
        init { ModelBase.Set(this._rawData, "children", value); }
    }

    public string? Parent
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "parent"); }
        init { ModelBase.Set(this._rawData, "parent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Children;
        _ = this.Parent;
    }

    public LocaleNotificationContentHierarchy() { }

    public LocaleNotificationContentHierarchy(
        LocaleNotificationContentHierarchy localeNotificationContentHierarchy
    )
        : base(localeNotificationContentHierarchy) { }

    public LocaleNotificationContentHierarchy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LocaleNotificationContentHierarchy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class LocaleNotificationContentHierarchyFromRaw : IFromRaw<LocaleNotificationContentHierarchy>
{
    /// <inheritdoc/>
    public LocaleNotificationContentHierarchy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LocaleNotificationContentHierarchy.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Channel, ChannelFromRaw>))]
public sealed record class Channel : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public string? Checksum
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "checksum"); }
        init { ModelBase.Set(this._rawData, "checksum", value); }
    }

    public ChannelContent? Content
    {
        get { return ModelBase.GetNullableClass<ChannelContent>(this.RawData, "content"); }
        init { ModelBase.Set(this._rawData, "content", value); }
    }

    public IReadOnlyDictionary<string, LocalesItem>? Locales
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, LocalesItem>>(
                this.RawData,
                "locales"
            );
        }
        init { ModelBase.Set(this._rawData, "locales", value); }
    }

    public string? Type
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
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

    public Channel(Channel channel)
        : base(channel) { }

    public Channel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Channel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class ChannelFromRaw : IFromRaw<Channel>
{
    /// <inheritdoc/>
    public Channel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Channel.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<ChannelContent, ChannelContentFromRaw>))]
public sealed record class ChannelContent : ModelBase
{
    public string? Subject
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "subject"); }
        init { ModelBase.Set(this._rawData, "subject", value); }
    }

    public string? Title
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "title"); }
        init { ModelBase.Set(this._rawData, "title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Subject;
        _ = this.Title;
    }

    public ChannelContent() { }

    public ChannelContent(ChannelContent channelContent)
        : base(channelContent) { }

    public ChannelContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelContentFromRaw.FromRawUnchecked"/>
    public static ChannelContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChannelContentFromRaw : IFromRaw<ChannelContent>
{
    /// <inheritdoc/>
    public ChannelContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelContent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<LocalesItem, LocalesItemFromRaw>))]
public sealed record class LocalesItem : ModelBase
{
    public string? Subject
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "subject"); }
        init { ModelBase.Set(this._rawData, "subject", value); }
    }

    public string? Title
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "title"); }
        init { ModelBase.Set(this._rawData, "title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Subject;
        _ = this.Title;
    }

    public LocalesItem() { }

    public LocalesItem(LocalesItem localesItem)
        : base(localesItem) { }

    public LocalesItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LocalesItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LocalesItemFromRaw.FromRawUnchecked"/>
    public static LocalesItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LocalesItemFromRaw : IFromRaw<LocalesItem>
{
    /// <inheritdoc/>
    public LocalesItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LocalesItem.FromRawUnchecked(rawData);
}
