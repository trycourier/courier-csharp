using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Journeys;

/// <summary>
/// Send to a Slack address directly, bypassing the recipient's stored profile. Requires
/// exactly one of `channel`, `user_id`, or `email`.
/// </summary>
[JsonConverter(typeof(JourneySendNodeToSlackConverter))]
public record class JourneySendNodeToSlack : ModelBase
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

    public string? AccessToken
    {
        get
        {
            return Match<string?>(
                channel: (x) => x.AccessToken,
                userID: (x) => x.AccessToken,
                email: (x) => x.AccessToken
            );
        }
    }

    public JourneySendNodeToSlack(JourneySendNodeToSlackChannel value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneySendNodeToSlack(JourneySendNodeToSlackUserID value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneySendNodeToSlack(JourneySendNodeToSlackEmail value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public JourneySendNodeToSlack(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneySendNodeToSlackChannel"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChannel(out var value)) {
    ///     // `value` is of type `JourneySendNodeToSlackChannel`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChannel([NotNullWhen(true)] out JourneySendNodeToSlackChannel? value)
    {
        value = this.Value as JourneySendNodeToSlackChannel;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneySendNodeToSlackUserID"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserID(out var value)) {
    ///     // `value` is of type `JourneySendNodeToSlackUserID`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserID([NotNullWhen(true)] out JourneySendNodeToSlackUserID? value)
    {
        value = this.Value as JourneySendNodeToSlackUserID;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="JourneySendNodeToSlackEmail"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEmail(out var value)) {
    ///     // `value` is of type `JourneySendNodeToSlackEmail`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEmail([NotNullWhen(true)] out JourneySendNodeToSlackEmail? value)
    {
        value = this.Value as JourneySendNodeToSlackEmail;
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
    ///     (JourneySendNodeToSlackChannel value) =&gt; {...},
    ///     (JourneySendNodeToSlackUserID value) =&gt; {...},
    ///     (JourneySendNodeToSlackEmail value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<JourneySendNodeToSlackChannel> channel,
        System::Action<JourneySendNodeToSlackUserID> userID,
        System::Action<JourneySendNodeToSlackEmail> email
    )
    {
        switch (this.Value)
        {
            case JourneySendNodeToSlackChannel value:
                channel(value);
                break;
            case JourneySendNodeToSlackUserID value:
                userID(value);
                break;
            case JourneySendNodeToSlackEmail value:
                email(value);
                break;
            default:
                throw new CourierInvalidDataException(
                    "Data did not match any variant of JourneySendNodeToSlack"
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
    ///     (JourneySendNodeToSlackChannel value) =&gt; {...},
    ///     (JourneySendNodeToSlackUserID value) =&gt; {...},
    ///     (JourneySendNodeToSlackEmail value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<JourneySendNodeToSlackChannel, T> channel,
        System::Func<JourneySendNodeToSlackUserID, T> userID,
        System::Func<JourneySendNodeToSlackEmail, T> email
    )
    {
        return this.Value switch
        {
            JourneySendNodeToSlackChannel value => channel(value),
            JourneySendNodeToSlackUserID value => userID(value),
            JourneySendNodeToSlackEmail value => email(value),
            _ => throw new CourierInvalidDataException(
                "Data did not match any variant of JourneySendNodeToSlack"
            ),
        };
    }

    public static implicit operator JourneySendNodeToSlack(JourneySendNodeToSlackChannel value) =>
        new(value);

    public static implicit operator JourneySendNodeToSlack(JourneySendNodeToSlackUserID value) =>
        new(value);

    public static implicit operator JourneySendNodeToSlack(JourneySendNodeToSlackEmail value) =>
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
                "Data did not match any variant of JourneySendNodeToSlack"
            );
        }
        this.Switch(
            (channel) => channel.Validate(),
            (userID) => userID.Validate(),
            (email) => email.Validate()
        );
    }

    public virtual bool Equals(JourneySendNodeToSlack? other) =>
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
            JourneySendNodeToSlackChannel _ => 0,
            JourneySendNodeToSlackUserID _ => 1,
            JourneySendNodeToSlackEmail _ => 2,
            _ => -1,
        };
    }
}

sealed class JourneySendNodeToSlackConverter : JsonConverter<JourneySendNodeToSlack>
{
    public override JourneySendNodeToSlack? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<JourneySendNodeToSlackChannel>(
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
            var deserialized = JsonSerializer.Deserialize<JourneySendNodeToSlackUserID>(
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
            var deserialized = JsonSerializer.Deserialize<JourneySendNodeToSlackEmail>(
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

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneySendNodeToSlack value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
