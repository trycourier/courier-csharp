using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Notifications;

[JsonConverter(typeof(ModelConverter<NotificationGetContent>))]
public sealed record class NotificationGetContent : ModelBase, IFromRaw<NotificationGetContent>
{
    public List<Block>? Blocks
    {
        get
        {
            if (!this._properties.TryGetValue("blocks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Block>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["blocks"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<Channel>? Channels
    {
        get
        {
            if (!this._properties.TryGetValue("channels", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Channel>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["channels"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Checksum
    {
        get
        {
            if (!this._properties.TryGetValue("checksum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["checksum"] = JsonSerializer.SerializeToElement(
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

    public NotificationGetContent(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationGetContent(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static NotificationGetContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<Block>))]
public sealed record class Block : ModelBase, IFromRaw<Block>
{
    public required string ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
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
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Courier.Models.Notifications.TypeModel> Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Courier.Models.Notifications.TypeModel>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Alias
    {
        get
        {
            if (!this._properties.TryGetValue("alias", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["alias"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Checksum
    {
        get
        {
            if (!this._properties.TryGetValue("checksum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["checksum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
            this._properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Context
    {
        get
        {
            if (!this._properties.TryGetValue("context", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["context"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, Locale>? Locales
    {
        get
        {
            if (!this._properties.TryGetValue("locales", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, Locale>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["locales"] = JsonSerializer.SerializeToElement(
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

    public Block(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Block(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Block FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(global::Courier.Models.Notifications.TypeModelConverter))]
public enum TypeModel
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

sealed class TypeModelConverter : JsonConverter<global::Courier.Models.Notifications.TypeModel>
{
    public override global::Courier.Models.Notifications.TypeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "action" => global::Courier.Models.Notifications.TypeModel.Action,
            "divider" => global::Courier.Models.Notifications.TypeModel.Divider,
            "image" => global::Courier.Models.Notifications.TypeModel.Image,
            "jsonnet" => global::Courier.Models.Notifications.TypeModel.Jsonnet,
            "list" => global::Courier.Models.Notifications.TypeModel.List,
            "markdown" => global::Courier.Models.Notifications.TypeModel.Markdown,
            "quote" => global::Courier.Models.Notifications.TypeModel.Quote,
            "template" => global::Courier.Models.Notifications.TypeModel.Template,
            "text" => global::Courier.Models.Notifications.TypeModel.Text,
            _ => (global::Courier.Models.Notifications.TypeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Courier.Models.Notifications.TypeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Courier.Models.Notifications.TypeModel.Action => "action",
                global::Courier.Models.Notifications.TypeModel.Divider => "divider",
                global::Courier.Models.Notifications.TypeModel.Image => "image",
                global::Courier.Models.Notifications.TypeModel.Jsonnet => "jsonnet",
                global::Courier.Models.Notifications.TypeModel.List => "list",
                global::Courier.Models.Notifications.TypeModel.Markdown => "markdown",
                global::Courier.Models.Notifications.TypeModel.Quote => "quote",
                global::Courier.Models.Notifications.TypeModel.Template => "template",
                global::Courier.Models.Notifications.TypeModel.Text => "text",
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
    public object Value { get; private init; }

    public Content(string value)
    {
        Value = value;
    }

    public Content(NotificationContentHierarchy value)
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
        if (this.Value is UnknownVariant)
        {
            throw new CourierInvalidDataException("Data did not match any variant of Content");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ContentConverter : JsonConverter<Content?>
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
            var deserialized = JsonSerializer.Deserialize<NotificationContentHierarchy>(
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
                    "Data does not match union variant 'NotificationContentHierarchy'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new Content(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException("Data does not match union variant 'string'", e)
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content? value, JsonSerializerOptions options)
    {
        object? variant = value?.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<NotificationContentHierarchy>))]
public sealed record class NotificationContentHierarchy
    : ModelBase,
        IFromRaw<NotificationContentHierarchy>
{
    public string? Children
    {
        get
        {
            if (!this._properties.TryGetValue("children", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["children"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Parent
    {
        get
        {
            if (!this._properties.TryGetValue("parent", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["parent"] = JsonSerializer.SerializeToElement(
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

    public NotificationContentHierarchy(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationContentHierarchy(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static NotificationContentHierarchy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(LocaleConverter))]
public record class Locale
{
    public object Value { get; private init; }

    public Locale(string value)
    {
        Value = value;
    }

    public Locale(NotificationContentHierarchyModel value)
    {
        Value = value;
    }

    Locale(UnknownVariant value)
    {
        Value = value;
    }

    public static Locale CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickNotificationContentHierarchy(
        [NotNullWhen(true)] out NotificationContentHierarchyModel? value
    )
    {
        value = this.Value as NotificationContentHierarchyModel;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<NotificationContentHierarchyModel> notificationContentHierarchy
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case NotificationContentHierarchyModel value:
                notificationContentHierarchy(value);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Locale");
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<NotificationContentHierarchyModel, T> notificationContentHierarchy
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            NotificationContentHierarchyModel value => notificationContentHierarchy(value),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Locale"),
        };
    }

    public static implicit operator Locale(string value) => new(value);

    public static implicit operator Locale(NotificationContentHierarchyModel value) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new CourierInvalidDataException("Data did not match any variant of Locale");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class LocaleConverter : JsonConverter<Locale>
{
    public override Locale? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<CourierInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<NotificationContentHierarchyModel>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Locale(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException(
                    "Data does not match union variant 'NotificationContentHierarchyModel'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new Locale(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is CourierInvalidDataException)
        {
            exceptions.Add(
                new CourierInvalidDataException("Data does not match union variant 'string'", e)
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Locale value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(ModelConverter<NotificationContentHierarchyModel>))]
public sealed record class NotificationContentHierarchyModel
    : ModelBase,
        IFromRaw<NotificationContentHierarchyModel>
{
    public string? Children
    {
        get
        {
            if (!this._properties.TryGetValue("children", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["children"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Parent
    {
        get
        {
            if (!this._properties.TryGetValue("parent", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["parent"] = JsonSerializer.SerializeToElement(
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

    public NotificationContentHierarchyModel() { }

    public NotificationContentHierarchyModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationContentHierarchyModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static NotificationContentHierarchyModel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<Channel>))]
public sealed record class Channel : ModelBase, IFromRaw<Channel>
{
    public required string ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
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
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Checksum
    {
        get
        {
            if (!this._properties.TryGetValue("checksum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["checksum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ContentModel? Content
    {
        get
        {
            if (!this._properties.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ContentModel?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, LocalesItem>? Locales
    {
        get
        {
            if (!this._properties.TryGetValue("locales", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, LocalesItem>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["locales"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
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

    public Channel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Channel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Channel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public Channel(string id)
        : this()
    {
        this.ID = id;
    }
}

[JsonConverter(typeof(ModelConverter<ContentModel>))]
public sealed record class ContentModel : ModelBase, IFromRaw<ContentModel>
{
    public string? Subject
    {
        get
        {
            if (!this._properties.TryGetValue("subject", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["subject"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Title
    {
        get
        {
            if (!this._properties.TryGetValue("title", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["title"] = JsonSerializer.SerializeToElement(
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

    public ContentModel() { }

    public ContentModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContentModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ContentModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<LocalesItem>))]
public sealed record class LocalesItem : ModelBase, IFromRaw<LocalesItem>
{
    public string? Subject
    {
        get
        {
            if (!this._properties.TryGetValue("subject", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["subject"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Title
    {
        get
        {
            if (!this._properties.TryGetValue("title", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["title"] = JsonSerializer.SerializeToElement(
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

    public LocalesItem(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LocalesItem(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static LocalesItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
