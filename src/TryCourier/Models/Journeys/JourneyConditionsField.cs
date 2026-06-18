using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Journeys;

/// <summary>
/// Condition spec for a journey node. Accepts a single condition atom, an AND/OR
/// group, or an AND/OR nested group. Omit the `conditions` property entirely to express
/// "no conditions".
/// </summary>
[JsonConverter(typeof(JourneyConditionsFieldConverter))]
public record class JourneyConditionsField : ModelBase
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

    public JourneyConditionsField(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public JourneyConditionsField(JourneyConditionGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneyConditionsField(JourneyConditionNestedGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneyConditionsField(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>string</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickConditionAtom(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;string&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickConditionAtom([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneyConditionGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickConditionGroup(out var value)) {
    ///     // `value` is of type `JourneyConditionGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickConditionGroup([NotNullWhen(true)] out JourneyConditionGroup? value)
    {
        value = this.Value as JourneyConditionGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneyConditionNestedGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickConditionNestedGroup(out var value)) {
    ///     // `value` is of type `JourneyConditionNestedGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickConditionNestedGroup(
        [NotNullWhen(true)] out JourneyConditionNestedGroup? value
    )
    {
        value = this.Value as JourneyConditionNestedGroup;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...},
    ///     (JourneyConditionGroup value) =&gt; {...},
    ///     (JourneyConditionNestedGroup value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<IReadOnlyList<string>> journeyConditionAtom,
        System::Action<JourneyConditionGroup> conditionGroup,
        System::Action<JourneyConditionNestedGroup> conditionNestedGroup
    )
    {
        switch (this.Value)
        {
            case IReadOnlyList<string> value:
                journeyConditionAtom(value);
                break;
            case JourneyConditionGroup value:
                conditionGroup(value);
                break;
            case JourneyConditionNestedGroup value:
                conditionNestedGroup(value);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of JourneyConditionsField"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...},
    ///     (JourneyConditionGroup value) =&gt; {...},
    ///     (JourneyConditionNestedGroup value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<IReadOnlyList<string>, T> journeyConditionAtom,
        System::Func<JourneyConditionGroup, T> conditionGroup,
        System::Func<JourneyConditionNestedGroup, T> conditionNestedGroup
    )
    {
        return this.Value switch
        {
            IReadOnlyList<string> value => journeyConditionAtom(value),
            JourneyConditionGroup value => conditionGroup(value),
            JourneyConditionNestedGroup value => conditionNestedGroup(value),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of JourneyConditionsField"
            ),
        };
    }

    public static implicit operator JourneyConditionsField(List<string> value) =>
        new((IReadOnlyList<string>)value);

    public static implicit operator JourneyConditionsField(JourneyConditionGroup value) =>
        new(value);

    public static implicit operator JourneyConditionsField(JourneyConditionNestedGroup value) =>
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
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new CourierInvalidDataException(
                "Data did not match any variant of JourneyConditionsField"
            );
        }
        this.Switch(
            (_) => { },
            (conditionGroup) => conditionGroup.Validate(),
            (conditionNestedGroup) => conditionNestedGroup.Validate()
        );
    }

    public virtual bool Equals(JourneyConditionsField? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            IReadOnlyList<string> _ => 0,
            JourneyConditionGroup _ => 1,
            JourneyConditionNestedGroup _ => 2,
            _ => -1,
        };
    }
}

sealed class JourneyConditionsFieldConverter : JsonConverter<JourneyConditionsField>
{
    public override JourneyConditionsField? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<JourneyConditionGroup>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<JourneyConditionNestedGroup>(
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
            var deserialized = JsonSerializer.Deserialize<List<string>>(element, options);
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

    public override void Write(
        Utf8JsonWriter writer,
        JourneyConditionsField value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
