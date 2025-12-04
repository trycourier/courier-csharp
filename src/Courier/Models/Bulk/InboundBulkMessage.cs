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

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InboundBulkTemplateMessage"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTemplate(out var value)) {
    ///     // `value` is of type `InboundBulkTemplateMessage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTemplate([NotNullWhen(true)] out InboundBulkTemplateMessage? value)
    {
        value = this.Value as InboundBulkTemplateMessage;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="InboundBulkContentMessage"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickContent(out var value)) {
    ///     // `value` is of type `InboundBulkContentMessage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickContent([NotNullWhen(true)] out InboundBulkContentMessage? value)
    {
        value = this.Value as InboundBulkContentMessage;
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
    ///     (InboundBulkTemplateMessage value) => {...},
    ///     (InboundBulkContentMessage value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
    ///     (InboundBulkTemplateMessage value) => {...},
    ///     (InboundBulkContentMessage value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
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
            throw new CourierInvalidDataException(
                "Data did not match any variant of InboundBulkMessage"
            );
        }
    }

    public virtual bool Equals(InboundBulkMessage? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
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

[JsonConverter(
    typeof(ModelConverter<InboundBulkTemplateMessage, InboundBulkTemplateMessageFromRaw>)
)]
public sealed record class InboundBulkTemplateMessage : ModelBase
{
    public required string Template
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "template"); }
        init { ModelBase.Set(this._rawData, "template", value); }
    }

    public string? Brand
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "brand"); }
        init { ModelBase.Set(this._rawData, "brand", value); }
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

    public string? Event
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "event"); }
        init { ModelBase.Set(this._rawData, "event", value); }
    }

    public IReadOnlyDictionary<string, Dictionary<string, JsonElement>>? Locale
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, Dictionary<string, JsonElement>>>(
                this.RawData,
                "locale"
            );
        }
        init { ModelBase.Set(this._rawData, "locale", value); }
    }

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

    /// <inheritdoc/>
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

    public InboundBulkTemplateMessage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundBulkTemplateMessage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundBulkTemplateMessageFromRaw.FromRawUnchecked"/>
    public static InboundBulkTemplateMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InboundBulkTemplateMessage(string template)
        : this()
    {
        this.Template = template;
    }
}

class InboundBulkTemplateMessageFromRaw : IFromRaw<InboundBulkTemplateMessage>
{
    /// <inheritdoc/>
    public InboundBulkTemplateMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundBulkTemplateMessage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<InboundBulkContentMessage, InboundBulkContentMessageFromRaw>))]
public sealed record class InboundBulkContentMessage : ModelBase
{
    /// <summary>
    /// Syntactic sugar to provide a fast shorthand for Courier Elemental Blocks.
    /// </summary>
    public required Content Content
    {
        get { return ModelBase.GetNotNullClass<Content>(this.RawData, "content"); }
        init { ModelBase.Set(this._rawData, "content", value); }
    }

    public string? Brand
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "brand"); }
        init { ModelBase.Set(this._rawData, "brand", value); }
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

    public string? Event
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "event"); }
        init { ModelBase.Set(this._rawData, "event", value); }
    }

    public IReadOnlyDictionary<string, Dictionary<string, JsonElement>>? Locale
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, Dictionary<string, JsonElement>>>(
                this.RawData,
                "locale"
            );
        }
        init { ModelBase.Set(this._rawData, "locale", value); }
    }

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

    /// <inheritdoc/>
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

    public InboundBulkContentMessage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundBulkContentMessage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundBulkContentMessageFromRaw.FromRawUnchecked"/>
    public static InboundBulkContentMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InboundBulkContentMessage(Content content)
        : this()
    {
        this.Content = content;
    }
}

class InboundBulkContentMessageFromRaw : IFromRaw<InboundBulkContentMessage>
{
    /// <inheritdoc/>
    public InboundBulkContentMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InboundBulkContentMessage.FromRawUnchecked(rawData);
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
