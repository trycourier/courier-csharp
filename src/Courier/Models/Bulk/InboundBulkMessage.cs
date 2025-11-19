using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Bulk;

[JsonConverter(typeof(InboundBulkMessageConverter))]
public record class InboundBulkMessage
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string? Brand
    {
        get { return Match<string?>(template: (x) => x.Brand, content: (x) => x.Brand); }
    }

    public string? Event
    {
        get { return Match<string?>(template: (x) => x.Event, content: (x) => x.Event); }
    }

    public InboundBulkMessage(InboundBulkTemplateMessage value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public InboundBulkMessage(InboundBulkContentMessage value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public InboundBulkMessage(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickTemplate([NotNullWhen(true)] out InboundBulkTemplateMessage? value)
    {
        value = this.Value as InboundBulkTemplateMessage;
        return value != null;
    }

    public bool TryPickContent([NotNullWhen(true)] out InboundBulkContentMessage? value)
    {
        value = this.Value as InboundBulkContentMessage;
        return value != null;
    }

    public void Switch(
        System::Action<InboundBulkTemplateMessage> template,
        System::Action<InboundBulkContentMessage> content
    )
    {
        switch (this.Value)
        {
            case InboundBulkTemplateMessage value:
                template(value);
                break;
            case InboundBulkContentMessage value:
                content(value);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of InboundBulkMessage"
                );
        }
    }

    public T Match<T>(
        System::Func<InboundBulkTemplateMessage, T> template,
        System::Func<InboundBulkContentMessage, T> content
    )
    {
        return this.Value switch
        {
            InboundBulkTemplateMessage value => template(value),
            InboundBulkContentMessage value => content(value),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of InboundBulkMessage"
            ),
        };
    }

    public static implicit operator InboundBulkMessage(InboundBulkTemplateMessage value) =>
        new(value);

    public static implicit operator InboundBulkMessage(InboundBulkContentMessage value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new CourierInvalidDataException(
                "Data did not match any variant of InboundBulkMessage"
            );
        }
    }
}

sealed class InboundBulkMessageConverter : JsonConverter<InboundBulkMessage>
{
    public override InboundBulkMessage? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<InboundBulkTemplateMessage>(
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
            var deserialized = JsonSerializer.Deserialize<InboundBulkContentMessage>(json, options);
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

    public override void Write(
        Utf8JsonWriter writer,
        InboundBulkMessage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ModelConverter<InboundBulkTemplateMessage>))]
public sealed record class InboundBulkTemplateMessage
    : ModelBase,
        IFromRaw<InboundBulkTemplateMessage>
{
    public required string Template
    {
        get
        {
            if (!this._properties.TryGetValue("template", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'template' cannot be null",
                    new System::ArgumentOutOfRangeException("template", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'template' cannot be null",
                    new System::ArgumentNullException("template")
                );
        }
        init
        {
            this._properties["template"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Brand
    {
        get
        {
            if (!this._properties.TryGetValue("brand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["brand"] = JsonSerializer.SerializeToElement(
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

    public Dictionary<string, Dictionary<string, JsonElement>>? Locale
    {
        get
        {
            if (!this._properties.TryGetValue("locale", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, JsonElement>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["locale"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public override void Validate()
    {
        _ = this.Template;
        _ = this.Brand;
        _ = this.Data;
        _ = this.Event;
        _ = this.Locale;
        _ = this.Override;
    }

    public InboundBulkTemplateMessage() { }

    public InboundBulkTemplateMessage(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundBulkTemplateMessage(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static InboundBulkTemplateMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public InboundBulkTemplateMessage(string template)
        : this()
    {
        this.Template = template;
    }
}

[JsonConverter(typeof(ModelConverter<InboundBulkContentMessage>))]
public sealed record class InboundBulkContentMessage
    : ModelBase,
        IFromRaw<InboundBulkContentMessage>
{
    /// <summary>
    /// Syntactic sugar to provide a fast shorthand for Courier Elemental Blocks.
    /// </summary>
    public required Content Content
    {
        get
        {
            if (!this._properties.TryGetValue("content", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Content>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentNullException("content")
                );
        }
        init
        {
            this._properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Brand
    {
        get
        {
            if (!this._properties.TryGetValue("brand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["brand"] = JsonSerializer.SerializeToElement(
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

    public Dictionary<string, Dictionary<string, JsonElement>>? Locale
    {
        get
        {
            if (!this._properties.TryGetValue("locale", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, JsonElement>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["locale"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public override void Validate()
    {
        this.Content.Validate();
        _ = this.Brand;
        _ = this.Data;
        _ = this.Event;
        _ = this.Locale;
        _ = this.Override;
    }

    public InboundBulkContentMessage() { }

    public InboundBulkContentMessage(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundBulkContentMessage(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static InboundBulkContentMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public InboundBulkContentMessage(Content content)
        : this()
    {
        this.Content = content;
    }
}

/// <summary>
/// Syntactic sugar to provide a fast shorthand for Courier Elemental Blocks.
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
        if (this.Value == null)
        {
            throw new CourierInvalidDataException("Data did not match any variant of Content");
        }
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
