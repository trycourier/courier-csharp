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
    public List<Block>? Blocks
    {
        get
        {
            if (!this._rawData.TryGetValue("blocks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Block>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["blocks"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<Channel>? Channels
    {
        get
        {
            if (!this._rawData.TryGetValue("channels", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Channel>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["channels"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Checksum
    {
        get
        {
            if (!this._rawData.TryGetValue("checksum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["checksum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static NotificationGetContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationGetContentFromRaw : IFromRaw<NotificationGetContent>
{
    public NotificationGetContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationGetContent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Block, BlockFromRaw>))]
public sealed record class Block : ModelBase
{
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, BlockType> Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, BlockType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Alias
    {
        get
        {
            if (!this._rawData.TryGetValue("alias", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["alias"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Checksum
    {
        get
        {
            if (!this._rawData.TryGetValue("checksum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["checksum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Content? Content
    {
        get
        {
            if (!this._rawData.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Content?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Context
    {
        get
        {
            if (!this._rawData.TryGetValue("context", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["context"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, Locale>? Locales
    {
        get
        {
            if (!this._rawData.TryGetValue("locales", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, Locale>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["locales"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static Block FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BlockFromRaw : IFromRaw<Block>
{
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

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickNotificationContentHierarchy(
        [NotNullWhen(true)] out NotificationContentHierarchy? value
    )
    {
        value = this.Value as NotificationContentHierarchy;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new CourierInvalidDataException("Data did not match any variant of Content");
        }
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
        get
        {
            if (!this._rawData.TryGetValue("children", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["children"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Parent
    {
        get
        {
            if (!this._rawData.TryGetValue("parent", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["parent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Children;
        _ = this.Parent;
    }

    public NotificationContentHierarchy() { }

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

    public static NotificationContentHierarchy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationContentHierarchyFromRaw : IFromRaw<NotificationContentHierarchy>
{
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

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickNotificationContentHierarchy(
        [NotNullWhen(true)] out LocaleNotificationContentHierarchy? value
    )
    {
        value = this.Value as LocaleNotificationContentHierarchy;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new CourierInvalidDataException("Data did not match any variant of Locale");
        }
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
        get
        {
            if (!this._rawData.TryGetValue("children", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["children"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Parent
    {
        get
        {
            if (!this._rawData.TryGetValue("parent", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["parent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Children;
        _ = this.Parent;
    }

    public LocaleNotificationContentHierarchy() { }

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

    public static LocaleNotificationContentHierarchy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LocaleNotificationContentHierarchyFromRaw : IFromRaw<LocaleNotificationContentHierarchy>
{
    public LocaleNotificationContentHierarchy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LocaleNotificationContentHierarchy.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Channel, ChannelFromRaw>))]
public sealed record class Channel : ModelBase
{
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Checksum
    {
        get
        {
            if (!this._rawData.TryGetValue("checksum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["checksum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ChannelContent? Content
    {
        get
        {
            if (!this._rawData.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ChannelContent?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, LocalesItem>? Locales
    {
        get
        {
            if (!this._rawData.TryGetValue("locales", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, LocalesItem>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["locales"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
    public Channel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Channel.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<ChannelContent, ChannelContentFromRaw>))]
public sealed record class ChannelContent : ModelBase
{
    public string? Subject
    {
        get
        {
            if (!this._rawData.TryGetValue("subject", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["subject"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Title
    {
        get
        {
            if (!this._rawData.TryGetValue("title", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["title"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Subject;
        _ = this.Title;
    }

    public ChannelContent() { }

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

    public static ChannelContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChannelContentFromRaw : IFromRaw<ChannelContent>
{
    public ChannelContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ChannelContent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<LocalesItem, LocalesItemFromRaw>))]
public sealed record class LocalesItem : ModelBase
{
    public string? Subject
    {
        get
        {
            if (!this._rawData.TryGetValue("subject", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["subject"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Title
    {
        get
        {
            if (!this._rawData.TryGetValue("title", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["title"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Subject;
        _ = this.Title;
    }

    public LocalesItem() { }

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

    public static LocalesItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LocalesItemFromRaw : IFromRaw<LocalesItem>
{
    public LocalesItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LocalesItem.FromRawUnchecked(rawData);
}
