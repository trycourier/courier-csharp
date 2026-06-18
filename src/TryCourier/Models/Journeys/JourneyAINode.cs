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
/// Invoke an AI step with `user_prompt` and optional `web_search`. Returns a structured
/// response conforming to `output_schema`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyAINode, JourneyAINodeFromRaw>))]
public sealed record class JourneyAINode : JsonModel
{
    /// <summary>
    /// A JSONSchema object (Draft-07-compatible). Validated at runtime by Ajv.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> OutputSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "output_schema"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "output_schema",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required ApiEnum<string, global::TryCourier.Models.Journeys.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::TryCourier.Models.Journeys.Type>
            >("type");
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

    public string? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    public string? UserPrompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_prompt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user_prompt", value);
        }
    }

    public bool? WebSearch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("web_search");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("web_search", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OutputSchema;
        this.Type.Validate();
        _ = this.ID;
        this.Conditions?.Validate();
        _ = this.Model;
        _ = this.UserPrompt;
        _ = this.WebSearch;
    }

    public JourneyAINode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyAINode(JourneyAINode journeyAINode)
        : base(journeyAINode) { }
#pragma warning restore CS8618

    public JourneyAINode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyAINode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyAINodeFromRaw.FromRawUnchecked"/>
    public static JourneyAINode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyAINodeFromRaw : IFromRawJson<JourneyAINode>
{
    /// <inheritdoc/>
    public JourneyAINode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JourneyAINode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    AI,
}

sealed class TypeConverter : JsonConverter<global::TryCourier.Models.Journeys.Type>
{
    public override global::TryCourier.Models.Journeys.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ai" => global::TryCourier.Models.Journeys.Type.AI,
            _ => (global::TryCourier.Models.Journeys.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::TryCourier.Models.Journeys.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::TryCourier.Models.Journeys.Type.AI => "ai",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
