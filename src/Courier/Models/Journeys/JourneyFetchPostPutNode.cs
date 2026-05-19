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
/// Issue an HTTP POST or PUT request with a `body` and merge the response into the
/// journey state per `merge_strategy`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyFetchPostPutNode, JourneyFetchPostPutNodeFromRaw>))]
public sealed record class JourneyFetchPostPutNode : JsonModel
{
    /// <summary>
    /// Strategy for merging a fetch response into the journey run state.
    /// </summary>
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

    public required ApiEnum<string, JourneyFetchPostPutNodeMethod> Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyFetchPostPutNodeMethod>>(
                "method"
            );
        }
        init { this._rawData.Set("method", value); }
    }

    public required ApiEnum<string, JourneyFetchPostPutNodeType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JourneyFetchPostPutNodeType>>(
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

    public string? Body
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("body");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("body", value);
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
        _ = this.Body;
        this.Conditions?.Validate();
        _ = this.Headers;
        _ = this.QueryParams;
        _ = this.ResponseSchema;
    }

    public JourneyFetchPostPutNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyFetchPostPutNode(JourneyFetchPostPutNode journeyFetchPostPutNode)
        : base(journeyFetchPostPutNode) { }
#pragma warning restore CS8618

    public JourneyFetchPostPutNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyFetchPostPutNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyFetchPostPutNodeFromRaw.FromRawUnchecked"/>
    public static JourneyFetchPostPutNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyFetchPostPutNodeFromRaw : IFromRawJson<JourneyFetchPostPutNode>
{
    /// <inheritdoc/>
    public JourneyFetchPostPutNode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyFetchPostPutNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JourneyFetchPostPutNodeMethodConverter))]
public enum JourneyFetchPostPutNodeMethod
{
    Post,
    Put,
}

sealed class JourneyFetchPostPutNodeMethodConverter : JsonConverter<JourneyFetchPostPutNodeMethod>
{
    public override JourneyFetchPostPutNodeMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "post" => JourneyFetchPostPutNodeMethod.Post,
            "put" => JourneyFetchPostPutNodeMethod.Put,
            _ => (JourneyFetchPostPutNodeMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyFetchPostPutNodeMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyFetchPostPutNodeMethod.Post => "post",
                JourneyFetchPostPutNodeMethod.Put => "put",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JourneyFetchPostPutNodeTypeConverter))]
public enum JourneyFetchPostPutNodeType
{
    Fetch,
}

sealed class JourneyFetchPostPutNodeTypeConverter : JsonConverter<JourneyFetchPostPutNodeType>
{
    public override JourneyFetchPostPutNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fetch" => JourneyFetchPostPutNodeType.Fetch,
            _ => (JourneyFetchPostPutNodeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyFetchPostPutNodeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyFetchPostPutNodeType.Fetch => "fetch",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
