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
/// Trigger fired when a user newly matches an Audience. Leaving and re-joining the
/// Audience re-enters the Journey. Membership is new-members-only: users already
/// in the Audience when the Journey is published do not enter. Unlike the v2 Automations
/// audience trigger, there is no member scope, event type, or frequency mode to
/// configure, and `audience_id` must name one Audience — wildcards are not supported.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<JourneyAudienceTriggerNode, JourneyAudienceTriggerNodeFromRaw>)
)]
public sealed record class JourneyAudienceTriggerNode : JsonModel
{
    /// <summary>
    /// The Audience to watch. Must name a single Audience; wildcards are not supported.
    /// </summary>
    public required string AudienceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("audience_id");
        }
        init { this._rawData.Set("audience_id", value); }
    }

    public required ApiEnum<string, JourneyAudienceTriggerNodeTriggerType> TriggerType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, JourneyAudienceTriggerNodeTriggerType>
            >("trigger_type");
        }
        init { this._rawData.Set("trigger_type", value); }
    }

    public required ApiEnum<string, JourneyAudienceTriggerNodeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyAudienceTriggerNodeType>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AudienceID;
        this.TriggerType.Validate();
        this.Type.Validate();
        _ = this.ID;
        this.Conditions?.Validate();
    }

    public JourneyAudienceTriggerNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyAudienceTriggerNode(JourneyAudienceTriggerNode journeyAudienceTriggerNode)
        : base(journeyAudienceTriggerNode) { }
#pragma warning restore CS8618

    public JourneyAudienceTriggerNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyAudienceTriggerNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyAudienceTriggerNodeFromRaw.FromRawUnchecked"/>
    public static JourneyAudienceTriggerNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyAudienceTriggerNodeFromRaw : IFromRawJson<JourneyAudienceTriggerNode>
{
    /// <inheritdoc/>
    public JourneyAudienceTriggerNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyAudienceTriggerNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JourneyAudienceTriggerNodeTriggerTypeConverter))]
public enum JourneyAudienceTriggerNodeTriggerType
{
    Audience,
}

sealed class JourneyAudienceTriggerNodeTriggerTypeConverter
    : JsonConverter<JourneyAudienceTriggerNodeTriggerType>
{
    public override JourneyAudienceTriggerNodeTriggerType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "audience" => JourneyAudienceTriggerNodeTriggerType.Audience,
            _ => (JourneyAudienceTriggerNodeTriggerType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyAudienceTriggerNodeTriggerType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyAudienceTriggerNodeTriggerType.Audience => "audience",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JourneyAudienceTriggerNodeTypeConverter))]
public enum JourneyAudienceTriggerNodeType
{
    Trigger,
}

sealed class JourneyAudienceTriggerNodeTypeConverter : JsonConverter<JourneyAudienceTriggerNodeType>
{
    public override JourneyAudienceTriggerNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "trigger" => JourneyAudienceTriggerNodeType.Trigger,
            _ => (JourneyAudienceTriggerNodeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyAudienceTriggerNodeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyAudienceTriggerNodeType.Trigger => "trigger",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
