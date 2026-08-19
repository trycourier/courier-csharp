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
/// Trigger fired when an external system POSTs to the webhook URL minted for `event_source`.
/// Narrow it to one event with `event_id`, or omit `event_id` to accept every event
/// delivered to the URL.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<JourneyWebhookTriggerNode, JourneyWebhookTriggerNodeFromRaw>)
)]
public sealed record class JourneyWebhookTriggerNode : JsonModel
{
    /// <summary>
    /// The provider key the webhook URL is minted for. Required, and must not contain
    /// a forward slash.
    /// </summary>
    public required string EventSource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("event_source");
        }
        init { this._rawData.Set("event_source", value); }
    }

    public required ApiEnum<string, JourneyWebhookTriggerNodeTriggerType> TriggerType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, JourneyWebhookTriggerNodeTriggerType>
            >("trigger_type");
        }
        init { this._rawData.Set("trigger_type", value); }
    }

    public required ApiEnum<string, JourneyWebhookTriggerNodeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyWebhookTriggerNodeType>>(
                "type"
            );
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
    /// An optional event filter, matched against the payload's `event` field. A sender
    /// that supplies no `event` matches the literal `custom`. Must not contain a
    /// forward slash. Omit to accept every event delivered to the URL.
    /// </summary>
    public string? EventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("event_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("event_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EventSource;
        this.TriggerType.Validate();
        this.Type.Validate();
        _ = this.ID;
        this.Conditions?.Validate();
        _ = this.EventID;
    }

    public JourneyWebhookTriggerNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyWebhookTriggerNode(JourneyWebhookTriggerNode journeyWebhookTriggerNode)
        : base(journeyWebhookTriggerNode) { }
#pragma warning restore CS8618

    public JourneyWebhookTriggerNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyWebhookTriggerNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyWebhookTriggerNodeFromRaw.FromRawUnchecked"/>
    public static JourneyWebhookTriggerNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyWebhookTriggerNodeFromRaw : IFromRawJson<JourneyWebhookTriggerNode>
{
    /// <inheritdoc/>
    public JourneyWebhookTriggerNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyWebhookTriggerNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JourneyWebhookTriggerNodeTriggerTypeConverter))]
public enum JourneyWebhookTriggerNodeTriggerType
{
    Webhook,
}

sealed class JourneyWebhookTriggerNodeTriggerTypeConverter
    : JsonConverter<JourneyWebhookTriggerNodeTriggerType>
{
    public override JourneyWebhookTriggerNodeTriggerType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "webhook" => JourneyWebhookTriggerNodeTriggerType.Webhook,
            _ => (JourneyWebhookTriggerNodeTriggerType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyWebhookTriggerNodeTriggerType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyWebhookTriggerNodeTriggerType.Webhook => "webhook",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JourneyWebhookTriggerNodeTypeConverter))]
public enum JourneyWebhookTriggerNodeType
{
    Trigger,
}

sealed class JourneyWebhookTriggerNodeTypeConverter : JsonConverter<JourneyWebhookTriggerNodeType>
{
    public override JourneyWebhookTriggerNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "trigger" => JourneyWebhookTriggerNodeType.Trigger,
            _ => (JourneyWebhookTriggerNodeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyWebhookTriggerNodeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyWebhookTriggerNodeType.Trigger => "trigger",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
