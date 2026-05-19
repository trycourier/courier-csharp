using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Journeys;

/// <summary>
/// Send a notification template to the recipient. Optionally override the recipient
/// address, delay the send, or attach `data`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneySendNode, JourneySendNodeFromRaw>))]
public sealed record class JourneySendNode : JsonModel
{
    public required Message Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Message>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    public required ApiEnum<string, JourneySendNodeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneySendNodeType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Condition spec for a journey node. Accepts a single condition atom, an AND/OR
    /// group, or an AND/OR nested group. Omit the `conditions` property entirely
    /// to express "no conditions".
    /// </summary>
    public JourneyConditionsField? Conditions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JourneyConditionsField>("conditions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("conditions", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Message.Validate();
        this.Type.Validate();
        _ = this.ID;
        this.Conditions?.Validate();
    }

    public JourneySendNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneySendNode(JourneySendNode journeySendNode)
        : base(journeySendNode) { }
#pragma warning restore CS8618

    public JourneySendNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneySendNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneySendNodeFromRaw.FromRawUnchecked"/>
    public static JourneySendNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneySendNodeFromRaw : IFromRawJson<JourneySendNode>
{
    /// <inheritdoc/>
    public JourneySendNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JourneySendNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Message, MessageFromRaw>))]
public sealed record class Message : JsonModel
{
    public required string Template
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("template");
        }
        init { this._rawData.Set("template", value); }
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
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public Delay? Delay
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Delay>("delay");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("delay", value);
        }
    }

    public To? To
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<To>("to");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Template;
        _ = this.Data;
        this.Delay?.Validate();
        this.To?.Validate();
    }

    public Message() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Message(Message message)
        : base(message) { }
#pragma warning restore CS8618

    public Message(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Message(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageFromRaw.FromRawUnchecked"/>
    public static Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Message(string template)
        : this()
    {
        this.Template = template;
    }
}

class MessageFromRaw : IFromRawJson<Message>
{
    /// <inheritdoc/>
    public Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Message.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Delay, DelayFromRaw>))]
public sealed record class Delay : JsonModel
{
    public required string Until
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("until");
        }
        init { this._rawData.Set("until", value); }
    }

    public string? Timezone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("timezone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timezone", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Until;
        _ = this.Timezone;
    }

    public Delay() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Delay(Delay delay)
        : base(delay) { }
#pragma warning restore CS8618

    public Delay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Delay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DelayFromRaw.FromRawUnchecked"/>
    public static Delay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Delay(string until)
        : this()
    {
        this.Until = until;
    }
}

class DelayFromRaw : IFromRawJson<Delay>
{
    /// <inheritdoc/>
    public Delay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Delay.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<To, ToFromRaw>))]
public sealed record class To : JsonModel
{
    public string? EmailOverride
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email_override");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email_override", value);
        }
    }

    public string? PhoneNumberOverride
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone_number_override");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("phone_number_override", value);
        }
    }

    public string? UserIDOverride
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_id_override");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user_id_override", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EmailOverride;
        _ = this.PhoneNumberOverride;
        _ = this.UserIDOverride;
    }

    public To() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public To(To to)
        : base(to) { }
#pragma warning restore CS8618

    public To(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    To(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToFromRaw.FromRawUnchecked"/>
    public static To FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToFromRaw : IFromRawJson<To>
{
    /// <inheritdoc/>
    public To FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        To.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JourneySendNodeTypeConverter))]
public enum JourneySendNodeType
{
    Send,
}

sealed class JourneySendNodeTypeConverter : JsonConverter<JourneySendNodeType>
{
    public override JourneySendNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "send" => JourneySendNodeType.Send,
            _ => (JourneySendNodeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneySendNodeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneySendNodeType.Send => "send",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
