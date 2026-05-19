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
/// Trigger fired when the journey is invoked via the API. The optional `schema` field
/// is a JSON Schema that validates the invocation payload.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<JourneyApiInvokeTriggerNode, JourneyApiInvokeTriggerNodeFromRaw>)
)]
public sealed record class JourneyApiInvokeTriggerNode : JsonModel
{
    public required ApiEnum<string, TriggerType> TriggerType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TriggerType>>("trigger_type");
        }
        init { this._rawData.Set("trigger_type", value); }
    }

    public required ApiEnum<string, JourneyApiInvokeTriggerNodeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyApiInvokeTriggerNodeType>>(
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
    /// A JSONSchema object (Draft-07-compatible). Validated at runtime by Ajv.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Schema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("schema");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "schema",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.TriggerType.Validate();
        this.Type.Validate();
        _ = this.ID;
        this.Conditions?.Validate();
        _ = this.Schema;
    }

    public JourneyApiInvokeTriggerNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyApiInvokeTriggerNode(JourneyApiInvokeTriggerNode journeyApiInvokeTriggerNode)
        : base(journeyApiInvokeTriggerNode) { }
#pragma warning restore CS8618

    public JourneyApiInvokeTriggerNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyApiInvokeTriggerNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyApiInvokeTriggerNodeFromRaw.FromRawUnchecked"/>
    public static JourneyApiInvokeTriggerNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyApiInvokeTriggerNodeFromRaw : IFromRawJson<JourneyApiInvokeTriggerNode>
{
    /// <inheritdoc/>
    public JourneyApiInvokeTriggerNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyApiInvokeTriggerNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TriggerTypeConverter))]
public enum TriggerType
{
    ApiInvoke,
}

sealed class TriggerTypeConverter : JsonConverter<TriggerType>
{
    public override TriggerType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "api-invoke" => TriggerType.ApiInvoke,
            _ => (TriggerType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TriggerType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TriggerType.ApiInvoke => "api-invoke",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JourneyApiInvokeTriggerNodeTypeConverter))]
public enum JourneyApiInvokeTriggerNodeType
{
    Trigger,
}

sealed class JourneyApiInvokeTriggerNodeTypeConverter
    : JsonConverter<JourneyApiInvokeTriggerNodeType>
{
    public override JourneyApiInvokeTriggerNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "trigger" => JourneyApiInvokeTriggerNodeType.Trigger,
            _ => (JourneyApiInvokeTriggerNodeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyApiInvokeTriggerNodeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyApiInvokeTriggerNodeType.Trigger => "trigger",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
