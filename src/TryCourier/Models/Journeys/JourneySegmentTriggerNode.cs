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
/// Trigger fired by a segment event (`identify`, `group`, or `track`).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<JourneySegmentTriggerNode, JourneySegmentTriggerNodeFromRaw>)
)]
public sealed record class JourneySegmentTriggerNode : JsonModel
{
    public required ApiEnum<string, RequestType> RequestType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RequestType>>("request_type");
        }
        init { this._rawData.Set("request_type", value); }
    }

    public required ApiEnum<string, JourneySegmentTriggerNodeTriggerType> TriggerType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, JourneySegmentTriggerNodeTriggerType>
            >("trigger_type");
        }
        init { this._rawData.Set("trigger_type", value); }
    }

    public required ApiEnum<string, JourneySegmentTriggerNodeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneySegmentTriggerNodeType>>(
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
        this.RequestType.Validate();
        this.TriggerType.Validate();
        this.Type.Validate();
        _ = this.ID;
        this.Conditions?.Validate();
        _ = this.EventID;
    }

    public JourneySegmentTriggerNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneySegmentTriggerNode(JourneySegmentTriggerNode journeySegmentTriggerNode)
        : base(journeySegmentTriggerNode) { }
#pragma warning restore CS8618

    public JourneySegmentTriggerNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneySegmentTriggerNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneySegmentTriggerNodeFromRaw.FromRawUnchecked"/>
    public static JourneySegmentTriggerNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneySegmentTriggerNodeFromRaw : IFromRawJson<JourneySegmentTriggerNode>
{
    /// <inheritdoc/>
    public JourneySegmentTriggerNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneySegmentTriggerNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RequestTypeConverter))]
public enum RequestType
{
    Identify,
    Group,
    Track,
}

sealed class RequestTypeConverter : JsonConverter<RequestType>
{
    public override RequestType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "identify" => RequestType.Identify,
            "group" => RequestType.Group,
            "track" => RequestType.Track,
            _ => (RequestType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RequestType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RequestType.Identify => "identify",
                RequestType.Group => "group",
                RequestType.Track => "track",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JourneySegmentTriggerNodeTriggerTypeConverter))]
public enum JourneySegmentTriggerNodeTriggerType
{
    Segment,
}

sealed class JourneySegmentTriggerNodeTriggerTypeConverter
    : JsonConverter<JourneySegmentTriggerNodeTriggerType>
{
    public override JourneySegmentTriggerNodeTriggerType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "segment" => JourneySegmentTriggerNodeTriggerType.Segment,
            _ => (JourneySegmentTriggerNodeTriggerType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneySegmentTriggerNodeTriggerType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneySegmentTriggerNodeTriggerType.Segment => "segment",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JourneySegmentTriggerNodeTypeConverter))]
public enum JourneySegmentTriggerNodeType
{
    Trigger,
}

sealed class JourneySegmentTriggerNodeTypeConverter : JsonConverter<JourneySegmentTriggerNodeType>
{
    public override JourneySegmentTriggerNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "trigger" => JourneySegmentTriggerNodeType.Trigger,
            _ => (JourneySegmentTriggerNodeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneySegmentTriggerNodeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneySegmentTriggerNodeType.Trigger => "trigger",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
