using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Bulk;

/// <summary>
/// Bulk message definition. Supports two formats: - V1 format: Requires `event` field
/// (event ID or notification ID) - V2 format: Optionally use `template` (notification
/// ID) or `content` (Elemental content) in addition to `event`
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InboundBulkMessage, InboundBulkMessageFromRaw>))]
public sealed record class InboundBulkMessage : JsonModel
{
    /// <summary>
    /// Event ID or Notification ID (required). Can be either a  Notification ID
    /// (e.g., "FRH3QXM9E34W4RKP7MRC8NZ1T8V8") or a custom Event ID  (e.g., "welcome-email")
    /// mapped to a notification.
    /// </summary>
    public required string Event
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event");
        }
        init { this._rawData.Set("event", value); }
    }

    public string? Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("brand");
        }
        init { this._rawData.Set("brand", value); }
    }

    /// <summary>
    /// Elemental content (optional, for V2 format). When provided, this will be used
    ///  instead of the notification associated with the `event` field.
    /// </summary>
    public Content? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Content>("content");
        }
        init { this._rawData.Set("content", value); }
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

    public IReadOnlyDictionary<string, IReadOnlyDictionary<string, JsonElement>>? Locale
    {
        get
        {
            this._rawData.Freeze();
            var value = this._rawData.GetNullableClass<
                FrozenDictionary<string, FrozenDictionary<string, JsonElement>>
            >("locale");
            if (value == null)
            {
                return null;
            }

            return FrozenDictionary.ToFrozenDictionary(
                value,
                entry => entry.Key,
                (entry) => (IReadOnlyDictionary<string, JsonElement>)entry.Value
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, FrozenDictionary<string, JsonElement>>?>(
                "locale",
                value == null
                    ? null
                    : FrozenDictionary.ToFrozenDictionary(
                        value,
                        entry => entry.Key,
                        (entry) => FrozenDictionary.ToFrozenDictionary(entry.Value)
                    )
            );
        }
    }

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
    /// Notification ID or template ID (optional, for V2 format). When provided,
    /// this will be used instead of the notification associated with the `event`
    /// field.
    /// </summary>
    public string? Template
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template");
        }
        init { this._rawData.Set("template", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Event;
        _ = this.Brand;
        this.Content?.Validate();
        _ = this.Data;
        _ = this.Locale;
        _ = this.Override;
        _ = this.Template;
    }

    public InboundBulkMessage() { }

    public InboundBulkMessage(InboundBulkMessage inboundBulkMessage)
        : base(inboundBulkMessage) { }

    public InboundBulkMessage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundBulkMessage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InboundBulkMessageFromRaw.FromRawUnchecked"/>
    public static InboundBulkMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public InboundBulkMessage(string event_)
        : this()
    {
        this.Event = event_;
    }
}

class InboundBulkMessageFromRaw : IFromRawJson<InboundBulkMessage>
{
    /// <inheritdoc/>
    public InboundBulkMessage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        InboundBulkMessage.FromRawUnchecked(rawData);
}

/// <summary>
/// Elemental content (optional, for V2 format). When provided, this will be used
///  instead of the notification associated with the `event` field.
/// </summary>
[JsonConverter(typeof(ContentConverter))]
public record class Content : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public override void Write(Utf8JsonWriter writer, Content? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
