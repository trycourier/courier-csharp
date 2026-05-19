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
/// Pause the journey run for a fixed `duration`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<JourneyDelayDurationNode, JourneyDelayDurationNodeFromRaw>)
)]
public sealed record class JourneyDelayDurationNode : JsonModel
{
    public required string Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("duration");
        }
        init { this._rawData.Set("duration", value); }
    }

    public required ApiEnum<string, Mode> Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Mode>>("mode");
        }
        init { this._rawData.Set("mode", value); }
    }

    public required ApiEnum<string, JourneyDelayDurationNodeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyDelayDurationNodeType>>(
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
        _ = this.Duration;
        this.Mode.Validate();
        this.Type.Validate();
        _ = this.ID;
        this.Conditions?.Validate();
    }

    public JourneyDelayDurationNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyDelayDurationNode(JourneyDelayDurationNode journeyDelayDurationNode)
        : base(journeyDelayDurationNode) { }
#pragma warning restore CS8618

    public JourneyDelayDurationNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyDelayDurationNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyDelayDurationNodeFromRaw.FromRawUnchecked"/>
    public static JourneyDelayDurationNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyDelayDurationNodeFromRaw : IFromRawJson<JourneyDelayDurationNode>
{
    /// <inheritdoc/>
    public JourneyDelayDurationNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyDelayDurationNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModeConverter))]
public enum Mode
{
    Duration,
}

sealed class ModeConverter : JsonConverter<Mode>
{
    public override Mode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "duration" => Mode.Duration,
            _ => (Mode)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Mode value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Mode.Duration => "duration",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JourneyDelayDurationNodeTypeConverter))]
public enum JourneyDelayDurationNodeType
{
    Delay,
}

sealed class JourneyDelayDurationNodeTypeConverter : JsonConverter<JourneyDelayDurationNodeType>
{
    public override JourneyDelayDurationNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "delay" => JourneyDelayDurationNodeType.Delay,
            _ => (JourneyDelayDurationNodeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyDelayDurationNodeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyDelayDurationNodeType.Delay => "delay",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
