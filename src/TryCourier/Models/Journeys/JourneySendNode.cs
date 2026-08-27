using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Journeys;

/// <summary>
/// Send to the recipient. A send node sources its content from EXACTLY ONE of `message.template`
/// (a single notification template) or `experiment` (an A/B split across weighted
/// template variants) — supplying both, or neither, is rejected. Optionally override
/// the recipient address, send as a tenant, delay the send, or attach `data`.
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

    /// <summary>
    /// A/B experiment config for a send node. The recipient is deterministically
    /// bucketed by `bucketingKey` and routed to one of the `variants` in proportion
    /// to its `weight`. Present on a send node INSTEAD OF `message.template`.
    /// </summary>
    public JourneyExperiment? Experiment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JourneyExperiment>("experiment");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("experiment", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Message.Validate();
        this.Type.Validate();
        _ = this.ID;
        this.Conditions?.Validate();
        this.Experiment?.Validate();
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
    /// <summary>
    /// Tenant context for this send. Set it to deliver on behalf of one of your customers,
    /// so the message uses that tenant's brand and settings.
    /// </summary>
    public Context? Context
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Context>("context");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("context", value);
        }
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

    public string? Template
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("template");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("template", value);
        }
    }

    /// <summary>
    /// Recipient override for this send. Provide exactly one of `email_override`,
    /// `phone_number_override`, `user_id_override`, `slack`, or `ms_teams` — not
    /// a combination.
    /// </summary>
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
        this.Context?.Validate();
        _ = this.Data;
        this.Delay?.Validate();
        _ = this.Template;
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
}

class MessageFromRaw : IFromRawJson<Message>
{
    /// <inheritdoc/>
    public Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Message.FromRawUnchecked(rawData);
}

/// <summary>
/// Tenant context for this send. Set it to deliver on behalf of one of your customers,
/// so the message uses that tenant's brand and settings.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Context, ContextFromRaw>))]
public sealed record class Context : JsonModel
{
    /// <summary>
    /// The tenant to send as. Accepts either a literal tenant id (`acme-tenant`)
    /// or a whole-string mustache reference to a value the run already holds — `{{data.tenant_id}}`
    /// from the invocation payload, or `{{f1.body.tenant_id}}` from the response
    /// of an earlier fetch node with id `f1`. A reference is resolved separately
    /// on every run, so a single journey can deliver as many tenants. Two forms
    /// are rejected with `400`: mid-string interpolation such as `tenant-{{data.region}}`,
    /// and any value beginning with `refs.`, which is reserved for internal use.
    /// A reference that resolves to nothing at run time does not stop the run —
    /// the message is still sent, with no tenant context — so make sure the referenced
    /// value is always present. `GET` returns the value in the same form it was supplied.
    /// </summary>
    public required string TenantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tenant_id");
        }
        init { this._rawData.Set("tenant_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TenantID;
    }

    public Context() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Context(Context context)
        : base(context) { }
#pragma warning restore CS8618

    public Context(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Context(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContextFromRaw.FromRawUnchecked"/>
    public static Context FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Context(string tenantID)
        : this()
    {
        this.TenantID = tenantID;
    }
}

class ContextFromRaw : IFromRawJson<Context>
{
    /// <inheritdoc/>
    public Context FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Context.FromRawUnchecked(rawData);
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

/// <summary>
/// Recipient override for this send. Provide exactly one of `email_override`, `phone_number_override`,
/// `user_id_override`, `slack`, or `ms_teams` — not a combination.
/// </summary>
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

    /// <summary>
    /// Send to a Microsoft Teams address directly, bypassing the recipient's stored
    /// profile. Requires exactly one target: `channel_id`, `channel_name` (with `team_id`),
    /// `user_id`, or `email`. `channel_name`, `user_id`, and `email` also need at
    /// least one of `service_url` or `tenant_id` — if you provide both, they must
    /// agree. `channel_id` doesn't require tenant context to publish, but provide
    /// `service_url` or `tenant_id` anyway: sends without either have failed at delivery
    /// in testing. `conversation_id` and `reply_to_activity_id`, available on the
    /// send API's `MsTeams` profile, aren't supported here yet.
    /// </summary>
    public JourneySendNodeToMsTeams? MsTeams
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JourneySendNodeToMsTeams>("ms_teams");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ms_teams", value);
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

    /// <summary>
    /// Send to a Slack address directly, bypassing the recipient's stored profile.
    /// Requires exactly one of `channel`, `user_id`, or `email`.
    /// </summary>
    public JourneySendNodeToSlack? Slack
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JourneySendNodeToSlack>("slack");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("slack", value);
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
        this.MsTeams?.Validate();
        _ = this.PhoneNumberOverride;
        this.Slack?.Validate();
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
