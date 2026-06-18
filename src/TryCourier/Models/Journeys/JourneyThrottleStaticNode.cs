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
/// Throttle the journey by a static `scope` (`user` or `global`), allowing at most
/// `max_allowed` invocations per `period`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<JourneyThrottleStaticNode, JourneyThrottleStaticNodeFromRaw>)
)]
public sealed record class JourneyThrottleStaticNode : JsonModel
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

    public required ApiEnum<string, JourneyThrottleStaticNodeScope> Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyThrottleStaticNodeScope>>(
                "scope"
            );
        }
        init { this._rawData.Set("scope", value); }
    }

    public required ApiEnum<string, JourneyThrottleStaticNodeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyThrottleStaticNodeType>>(
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
        this.Type.Validate();
        _ = this.ID;
        this.Conditions?.Validate();
    }

    public JourneyThrottleStaticNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyThrottleStaticNode(JourneyThrottleStaticNode journeyThrottleStaticNode)
        : base(journeyThrottleStaticNode) { }
#pragma warning restore CS8618

    public JourneyThrottleStaticNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyThrottleStaticNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyThrottleStaticNodeFromRaw.FromRawUnchecked"/>
    public static JourneyThrottleStaticNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyThrottleStaticNodeFromRaw : IFromRawJson<JourneyThrottleStaticNode>
{
    /// <inheritdoc/>
    public JourneyThrottleStaticNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyThrottleStaticNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JourneyThrottleStaticNodeScopeConverter))]
public enum JourneyThrottleStaticNodeScope
{
    User,
    Global,
}

sealed class JourneyThrottleStaticNodeScopeConverter : JsonConverter<JourneyThrottleStaticNodeScope>
{
    public override JourneyThrottleStaticNodeScope Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => JourneyThrottleStaticNodeScope.User,
            "global" => JourneyThrottleStaticNodeScope.Global,
            _ => (JourneyThrottleStaticNodeScope)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyThrottleStaticNodeScope value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyThrottleStaticNodeScope.User => "user",
                JourneyThrottleStaticNodeScope.Global => "global",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JourneyThrottleStaticNodeTypeConverter))]
public enum JourneyThrottleStaticNodeType
{
    Throttle,
}

sealed class JourneyThrottleStaticNodeTypeConverter : JsonConverter<JourneyThrottleStaticNodeType>
{
    public override JourneyThrottleStaticNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "throttle" => JourneyThrottleStaticNodeType.Throttle,
            _ => (JourneyThrottleStaticNodeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyThrottleStaticNodeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyThrottleStaticNodeType.Throttle => "throttle",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
