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
/// Throttle the journey by a dynamic `throttle_key`, allowing at most `max_allowed`
/// invocations per `period`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<JourneyThrottleDynamicNode, JourneyThrottleDynamicNodeFromRaw>)
)]
public sealed record class JourneyThrottleDynamicNode : JsonModel
{
    public required long MaxAllowed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("max_allowed");
        }
        init { this._rawData.Set("max_allowed", value); }
    }

    public required string Period
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("period");
        }
        init { this._rawData.Set("period", value); }
    }

    public required ApiEnum<string, JourneyThrottleDynamicNodeScope> Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyThrottleDynamicNodeScope>>(
                "scope"
            );
        }
        init { this._rawData.Set("scope", value); }
    }

    public required string ThrottleKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("throttle_key");
        }
        init { this._rawData.Set("throttle_key", value); }
    }

    public required ApiEnum<string, JourneyThrottleDynamicNodeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyThrottleDynamicNodeType>>(
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
        _ = this.MaxAllowed;
        _ = this.Period;
        this.Scope.Validate();
        _ = this.ThrottleKey;
        this.Type.Validate();
        _ = this.ID;
        this.Conditions?.Validate();
    }

    public JourneyThrottleDynamicNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyThrottleDynamicNode(JourneyThrottleDynamicNode journeyThrottleDynamicNode)
        : base(journeyThrottleDynamicNode) { }
#pragma warning restore CS8618

    public JourneyThrottleDynamicNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyThrottleDynamicNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyThrottleDynamicNodeFromRaw.FromRawUnchecked"/>
    public static JourneyThrottleDynamicNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyThrottleDynamicNodeFromRaw : IFromRawJson<JourneyThrottleDynamicNode>
{
    /// <inheritdoc/>
    public JourneyThrottleDynamicNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyThrottleDynamicNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JourneyThrottleDynamicNodeScopeConverter))]
public enum JourneyThrottleDynamicNodeScope
{
    Dynamic,
}

sealed class JourneyThrottleDynamicNodeScopeConverter
    : JsonConverter<JourneyThrottleDynamicNodeScope>
{
    public override JourneyThrottleDynamicNodeScope Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dynamic" => JourneyThrottleDynamicNodeScope.Dynamic,
            _ => (JourneyThrottleDynamicNodeScope)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyThrottleDynamicNodeScope value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyThrottleDynamicNodeScope.Dynamic => "dynamic",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JourneyThrottleDynamicNodeTypeConverter))]
public enum JourneyThrottleDynamicNodeType
{
    Throttle,
}

sealed class JourneyThrottleDynamicNodeTypeConverter : JsonConverter<JourneyThrottleDynamicNodeType>
{
    public override JourneyThrottleDynamicNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "throttle" => JourneyThrottleDynamicNodeType.Throttle,
            _ => (JourneyThrottleDynamicNodeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyThrottleDynamicNodeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyThrottleDynamicNodeType.Throttle => "throttle",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
