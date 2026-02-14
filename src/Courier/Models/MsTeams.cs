using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(MsTeamsConverter))]
public record class MsTeams : ModelBase
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

    public string ServiceUrl
    {
        get
        {
            return Match(
                sendToMsTeamsUserID: (x) => x.ServiceUrl,
                sendToMsTeamsEmail: (x) => x.ServiceUrl,
                sendToMsTeamsChannelID: (x) => x.ServiceUrl,
                sendToMsTeamsConversationID: (x) => x.ServiceUrl,
                sendToMsTeamsChannelName: (x) => x.ServiceUrl
            );
        }
    }

    public string TenantID
    {
        get
        {
            return Match(
                sendToMsTeamsUserID: (x) => x.TenantID,
                sendToMsTeamsEmail: (x) => x.TenantID,
                sendToMsTeamsChannelID: (x) => x.TenantID,
                sendToMsTeamsConversationID: (x) => x.TenantID,
                sendToMsTeamsChannelName: (x) => x.TenantID
            );
        }
    }

    public MsTeams(SendToMsTeamsUserID value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MsTeams(SendToMsTeamsEmail value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MsTeams(SendToMsTeamsChannelID value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MsTeams(SendToMsTeamsConversationID value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MsTeams(SendToMsTeamsChannelName value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MsTeams(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SendToMsTeamsUserID"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSendToMsTeamsUserID(out var value)) {
    ///     // `value` is of type `SendToMsTeamsUserID`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSendToMsTeamsUserID([NotNullWhen(true)] out SendToMsTeamsUserID? value)
    {
        value = this.Value as SendToMsTeamsUserID;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SendToMsTeamsEmail"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSendToMsTeamsEmail(out var value)) {
    ///     // `value` is of type `SendToMsTeamsEmail`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSendToMsTeamsEmail([NotNullWhen(true)] out SendToMsTeamsEmail? value)
    {
        value = this.Value as SendToMsTeamsEmail;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SendToMsTeamsChannelID"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSendToMsTeamsChannelID(out var value)) {
    ///     // `value` is of type `SendToMsTeamsChannelID`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSendToMsTeamsChannelID([NotNullWhen(true)] out SendToMsTeamsChannelID? value)
    {
        value = this.Value as SendToMsTeamsChannelID;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SendToMsTeamsConversationID"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSendToMsTeamsConversationID(out var value)) {
    ///     // `value` is of type `SendToMsTeamsConversationID`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSendToMsTeamsConversationID(
        [NotNullWhen(true)] out SendToMsTeamsConversationID? value
    )
    {
        value = this.Value as SendToMsTeamsConversationID;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SendToMsTeamsChannelName"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSendToMsTeamsChannelName(out var value)) {
    ///     // `value` is of type `SendToMsTeamsChannelName`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSendToMsTeamsChannelName(
        [NotNullWhen(true)] out SendToMsTeamsChannelName? value
    )
    {
        value = this.Value as SendToMsTeamsChannelName;
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
    ///     (SendToMsTeamsUserID value) => {...},
    ///     (SendToMsTeamsEmail value) => {...},
    ///     (SendToMsTeamsChannelID value) => {...},
    ///     (SendToMsTeamsConversationID value) => {...},
    ///     (SendToMsTeamsChannelName value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<SendToMsTeamsUserID> sendToMsTeamsUserID,
        System::Action<SendToMsTeamsEmail> sendToMsTeamsEmail,
        System::Action<SendToMsTeamsChannelID> sendToMsTeamsChannelID,
        System::Action<SendToMsTeamsConversationID> sendToMsTeamsConversationID,
        System::Action<SendToMsTeamsChannelName> sendToMsTeamsChannelName
    )
    {
        switch (this.Value)
        {
            case SendToMsTeamsUserID value:
                sendToMsTeamsUserID(value);
                break;
            case SendToMsTeamsEmail value:
                sendToMsTeamsEmail(value);
                break;
            case SendToMsTeamsChannelID value:
                sendToMsTeamsChannelID(value);
                break;
            case SendToMsTeamsConversationID value:
                sendToMsTeamsConversationID(value);
                break;
            case SendToMsTeamsChannelName value:
                sendToMsTeamsChannelName(value);
                break;
            default:
                throw new CourierInvalidDataException("Data did not match any variant of MsTeams");
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
    ///     (SendToMsTeamsUserID value) => {...},
    ///     (SendToMsTeamsEmail value) => {...},
    ///     (SendToMsTeamsChannelID value) => {...},
    ///     (SendToMsTeamsConversationID value) => {...},
    ///     (SendToMsTeamsChannelName value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<SendToMsTeamsUserID, T> sendToMsTeamsUserID,
        System::Func<SendToMsTeamsEmail, T> sendToMsTeamsEmail,
        System::Func<SendToMsTeamsChannelID, T> sendToMsTeamsChannelID,
        System::Func<SendToMsTeamsConversationID, T> sendToMsTeamsConversationID,
        System::Func<SendToMsTeamsChannelName, T> sendToMsTeamsChannelName
    )
    {
        return this.Value switch
        {
            SendToMsTeamsUserID value => sendToMsTeamsUserID(value),
            SendToMsTeamsEmail value => sendToMsTeamsEmail(value),
            SendToMsTeamsChannelID value => sendToMsTeamsChannelID(value),
            SendToMsTeamsConversationID value => sendToMsTeamsConversationID(value),
            SendToMsTeamsChannelName value => sendToMsTeamsChannelName(value),
            _ => throw new CourierInvalidDataException("Data did not match any variant of MsTeams"),
        };
    }

    public static implicit operator MsTeams(SendToMsTeamsUserID value) => new(value);

    public static implicit operator MsTeams(SendToMsTeamsEmail value) => new(value);

    public static implicit operator MsTeams(SendToMsTeamsChannelID value) => new(value);

    public static implicit operator MsTeams(SendToMsTeamsConversationID value) => new(value);

    public static implicit operator MsTeams(SendToMsTeamsChannelName value) => new(value);

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
            throw new CourierInvalidDataException("Data did not match any variant of MsTeams");
        }
        this.Switch(
            (sendToMsTeamsUserID) => sendToMsTeamsUserID.Validate(),
            (sendToMsTeamsEmail) => sendToMsTeamsEmail.Validate(),
            (sendToMsTeamsChannelID) => sendToMsTeamsChannelID.Validate(),
            (sendToMsTeamsConversationID) => sendToMsTeamsConversationID.Validate(),
            (sendToMsTeamsChannelName) => sendToMsTeamsChannelName.Validate()
        );
    }

    public virtual bool Equals(MsTeams? other) =>
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
            SendToMsTeamsUserID _ => 0,
            SendToMsTeamsEmail _ => 1,
            SendToMsTeamsChannelID _ => 2,
            SendToMsTeamsConversationID _ => 3,
            SendToMsTeamsChannelName _ => 4,
            _ => -1,
        };
    }
}

sealed class MsTeamsConverter : JsonConverter<MsTeams>
{
    public override MsTeams? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<SendToMsTeamsUserID>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<SendToMsTeamsEmail>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<SendToMsTeamsChannelID>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<SendToMsTeamsConversationID>(
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
            var deserialized = JsonSerializer.Deserialize<SendToMsTeamsChannelName>(
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

    public override void Write(Utf8JsonWriter writer, MsTeams value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
