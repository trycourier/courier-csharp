using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(SlackConverter))]
public record class Slack : ModelBase
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

    public string AccessToken
    {
        get
        {
            return Match(
                sendToSlackChannel: (x) => x.AccessToken,
                sendToSlackEmail: (x) => x.AccessToken,
                sendToSlackUserID: (x) => x.AccessToken
            );
        }
    }

    public Slack(SendToSlackChannel value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Slack(SendToSlackEmail value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Slack(SendToSlackUserID value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Slack(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SendToSlackChannel"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSendToSlackChannel(out var value)) {
    ///     // `value` is of type `SendToSlackChannel`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSendToSlackChannel([NotNullWhen(true)] out SendToSlackChannel? value)
    {
        value = this.Value as SendToSlackChannel;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SendToSlackEmail"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSendToSlackEmail(out var value)) {
    ///     // `value` is of type `SendToSlackEmail`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSendToSlackEmail([NotNullWhen(true)] out SendToSlackEmail? value)
    {
        value = this.Value as SendToSlackEmail;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SendToSlackUserID"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSendToSlackUserID(out var value)) {
    ///     // `value` is of type `SendToSlackUserID`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSendToSlackUserID([NotNullWhen(true)] out SendToSlackUserID? value)
    {
        value = this.Value as SendToSlackUserID;
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
    ///     (SendToSlackChannel value) => {...},
    ///     (SendToSlackEmail value) => {...},
    ///     (SendToSlackUserID value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SendToSlackChannel> sendToSlackChannel,
        System::Action<SendToSlackEmail> sendToSlackEmail,
        System::Action<SendToSlackUserID> sendToSlackUserID
    )
    {
        switch (this.Value)
        {
            case SendToSlackChannel value:
                sendToSlackChannel(value);
                break;
            case SendToSlackEmail value:
                sendToSlackEmail(value);
                break;
            case SendToSlackUserID value:
                sendToSlackUserID(value);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of Slack");
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
    ///     (SendToSlackChannel value) => {...},
    ///     (SendToSlackEmail value) => {...},
    ///     (SendToSlackUserID value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SendToSlackChannel, T> sendToSlackChannel,
        System::Func<SendToSlackEmail, T> sendToSlackEmail,
        System::Func<SendToSlackUserID, T> sendToSlackUserID
    )
    {
        return this.Value switch
        {
            SendToSlackChannel value => sendToSlackChannel(value),
            SendToSlackEmail value => sendToSlackEmail(value),
            SendToSlackUserID value => sendToSlackUserID(value),
            _ => throw new CourierInvalidDataException("Data did not match any variant of Slack"),
        };
    }

    public static implicit operator Slack(SendToSlackChannel value) => new(value);

    public static implicit operator Slack(SendToSlackEmail value) => new(value);

    public static implicit operator Slack(SendToSlackUserID value) => new(value);

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
            throw new CourierInvalidDataException("Data did not match any variant of Slack");
        }
        this.Switch(
            (sendToSlackChannel) => sendToSlackChannel.Validate(),
            (sendToSlackEmail) => sendToSlackEmail.Validate(),
            (sendToSlackUserID) => sendToSlackUserID.Validate()
        );
    }

    public virtual bool Equals(Slack? other)
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

sealed class SlackConverter : JsonConverter<Slack>
{
    public override Slack? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<SendToSlackChannel>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<SendToSlackEmail>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<SendToSlackUserID>(element, options);
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

    public override void Write(Utf8JsonWriter writer, Slack value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
