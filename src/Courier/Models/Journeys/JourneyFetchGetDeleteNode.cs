using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Journeys;

[JsonConverter(
    typeof(JsonModelConverter<JourneyFetchGetDeleteNode, JourneyFetchGetDeleteNodeFromRaw>)
)]
public sealed record class JourneyFetchGetDeleteNode : JsonModel
{
    public required ApiEnum<string, JourneyMergeStrategy> MergeStrategy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyMergeStrategy>>(
                "merge_strategy"
            );
        }
        init { this._rawData.Set("merge_strategy", value); }
    }

    public required ApiEnum<string, Method> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Method>>("method");
        }
        init { this._rawData.Set("method", value); }
    }

    public required ApiEnum<string, JourneyFetchGetDeleteNodeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyFetchGetDeleteNodeType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
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

    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyDictionary<string, string>? QueryParams
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("query_params");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "query_params",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A JSONSchema object (Draft-07-compatible). Validated at runtime by Ajv.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? ResponseSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "response_schema"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "response_schema",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.MergeStrategy.Validate();
        this.Method.Validate();
        this.Type.Validate();
        _ = this.Url;
        _ = this.ID;
        this.Conditions?.Validate();
        _ = this.Headers;
        _ = this.QueryParams;
        _ = this.ResponseSchema;
    }

    public JourneyFetchGetDeleteNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyFetchGetDeleteNode(JourneyFetchGetDeleteNode journeyFetchGetDeleteNode)
        : base(journeyFetchGetDeleteNode) { }
#pragma warning restore CS8618

    public JourneyFetchGetDeleteNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyFetchGetDeleteNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyFetchGetDeleteNodeFromRaw.FromRawUnchecked"/>
    public static JourneyFetchGetDeleteNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyFetchGetDeleteNodeFromRaw : IFromRawJson<JourneyFetchGetDeleteNode>
{
    /// <inheritdoc/>
    public JourneyFetchGetDeleteNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyFetchGetDeleteNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MethodConverter))]
public enum Method
{
    Get,
    Delete,
}

sealed class MethodConverter : JsonConverter<Method>
{
    public override Method Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "get" => Method.Get,
            "delete" => Method.Delete,
            _ => (Method)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Method value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Method.Get => "get",
                Method.Delete => "delete",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JourneyFetchGetDeleteNodeTypeConverter))]
public enum JourneyFetchGetDeleteNodeType
{
    Fetch,
}

sealed class JourneyFetchGetDeleteNodeTypeConverter : JsonConverter<JourneyFetchGetDeleteNodeType>
{
    public override JourneyFetchGetDeleteNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fetch" => JourneyFetchGetDeleteNodeType.Fetch,
            _ => (JourneyFetchGetDeleteNodeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyFetchGetDeleteNodeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyFetchGetDeleteNodeType.Fetch => "fetch",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
