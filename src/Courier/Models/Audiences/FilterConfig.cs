using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Audiences;

[JsonConverter(typeof(ModelConverter<FilterConfig>))]
public sealed record class FilterConfig : ModelBase, IFromRaw<FilterConfig>
{
    /// <summary>
    /// The operator to use for filtering
    /// </summary>
    public required ApiEnum<string, FilterConfigOperator> Operator
    {
        get
        {
            if (!this._rawData.TryGetValue("operator", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, FilterConfigOperator>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["operator"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The attribe name from profile whose value will be operated against the filter value
    /// </summary>
    public required string Path
    {
        get
        {
            if (!this._rawData.TryGetValue("path", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'path' cannot be null",
                    new System::ArgumentOutOfRangeException("path", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'path' cannot be null",
                    new System::ArgumentNullException("path")
                );
        }
        init
        {
            this._rawData["path"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The value to use for filtering
    /// </summary>
    public required string Value
    {
        get
        {
            if (!this._rawData.TryGetValue("value", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentOutOfRangeException("value", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentNullException("value")
                );
        }
        init
        {
            this._rawData["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Operator.Validate();
        _ = this.Path;
        _ = this.Value;
    }

    public FilterConfig() { }

    public FilterConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FilterConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static FilterConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

/// <summary>
/// The operator to use for filtering
/// </summary>
[JsonConverter(typeof(FilterConfigOperatorConverter))]
public enum FilterConfigOperator
{
    EndsWith,
    Eq,
    Exists,
    Gt,
    Gte,
    Includes,
    IsAfter,
    IsBefore,
    Lt,
    Lte,
    Neq,
    Omit,
    StartsWith,
    And,
    Or,
}

sealed class FilterConfigOperatorConverter : JsonConverter<FilterConfigOperator>
{
    public override FilterConfigOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ENDS_WITH" => FilterConfigOperator.EndsWith,
            "EQ" => FilterConfigOperator.Eq,
            "EXISTS" => FilterConfigOperator.Exists,
            "GT" => FilterConfigOperator.Gt,
            "GTE" => FilterConfigOperator.Gte,
            "INCLUDES" => FilterConfigOperator.Includes,
            "IS_AFTER" => FilterConfigOperator.IsAfter,
            "IS_BEFORE" => FilterConfigOperator.IsBefore,
            "LT" => FilterConfigOperator.Lt,
            "LTE" => FilterConfigOperator.Lte,
            "NEQ" => FilterConfigOperator.Neq,
            "OMIT" => FilterConfigOperator.Omit,
            "STARTS_WITH" => FilterConfigOperator.StartsWith,
            "AND" => FilterConfigOperator.And,
            "OR" => FilterConfigOperator.Or,
            _ => (FilterConfigOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FilterConfigOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FilterConfigOperator.EndsWith => "ENDS_WITH",
                FilterConfigOperator.Eq => "EQ",
                FilterConfigOperator.Exists => "EXISTS",
                FilterConfigOperator.Gt => "GT",
                FilterConfigOperator.Gte => "GTE",
                FilterConfigOperator.Includes => "INCLUDES",
                FilterConfigOperator.IsAfter => "IS_AFTER",
                FilterConfigOperator.IsBefore => "IS_BEFORE",
                FilterConfigOperator.Lt => "LT",
                FilterConfigOperator.Lte => "LTE",
                FilterConfigOperator.Neq => "NEQ",
                FilterConfigOperator.Omit => "OMIT",
                FilterConfigOperator.StartsWith => "STARTS_WITH",
                FilterConfigOperator.And => "AND",
                FilterConfigOperator.Or => "OR",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
