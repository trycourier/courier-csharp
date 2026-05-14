using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Journeys;

[JsonConverter(typeof(JsonModelConverter<JourneyDelayUntilNode, JourneyDelayUntilNodeFromRaw>))]
public sealed record class JourneyDelayUntilNode : JsonModel
{
    public required ApiEnum<string, JourneyDelayUntilNodeMode> Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyDelayUntilNodeMode>>(
                "mode"
            );
        }
        init { this._rawData.Set("mode", value); }
    }

    public required ApiEnum<string, JourneyDelayUntilNodeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyDelayUntilNodeType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    public required string Until
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("until");
        }
        init { this._rawData.Set("until", value); }
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
        this.Mode.Validate();
        this.Type.Validate();
        _ = this.Until;
        _ = this.ID;
        this.Conditions?.Validate();
    }

    public JourneyDelayUntilNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyDelayUntilNode(JourneyDelayUntilNode journeyDelayUntilNode)
        : base(journeyDelayUntilNode) { }
#pragma warning restore CS8618

    public JourneyDelayUntilNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyDelayUntilNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyDelayUntilNodeFromRaw.FromRawUnchecked"/>
    public static JourneyDelayUntilNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyDelayUntilNodeFromRaw : IFromRawJson<JourneyDelayUntilNode>
{
    /// <inheritdoc/>
    public JourneyDelayUntilNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyDelayUntilNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JourneyDelayUntilNodeModeConverter))]
public enum JourneyDelayUntilNodeMode
{
    Until,
}

sealed class JourneyDelayUntilNodeModeConverter : JsonConverter<JourneyDelayUntilNodeMode>
{
    public override JourneyDelayUntilNodeMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "until" => JourneyDelayUntilNodeMode.Until,
            _ => (JourneyDelayUntilNodeMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyDelayUntilNodeMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyDelayUntilNodeMode.Until => "until",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JourneyDelayUntilNodeTypeConverter))]
public enum JourneyDelayUntilNodeType
{
    Delay,
}

sealed class JourneyDelayUntilNodeTypeConverter : JsonConverter<JourneyDelayUntilNodeType>
{
    public override JourneyDelayUntilNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "delay" => JourneyDelayUntilNodeType.Delay,
            _ => (JourneyDelayUntilNodeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyDelayUntilNodeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyDelayUntilNodeType.Delay => "delay",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
