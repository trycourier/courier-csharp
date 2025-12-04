using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Audiences;

[JsonConverter(typeof(ModelConverter<FilterConfig, FilterConfigFromRaw>))]
public sealed record class FilterConfig : ModelBase
{
    /// <summary>
    /// The operator to use for filtering
    /// </summary>
    public required ApiEnum<string, FilterConfigOperator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, FilterConfigOperator>>(
                this.RawData,
                "operator"
            );
        }
        init { ModelBase.Set(this._rawData, "operator", value); }
    }

    /// <summary>
    /// The attribe name from profile whose value will be operated against the filter value
    /// </summary>
    public required string Path
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "path"); }
        init { ModelBase.Set(this._rawData, "path", value); }
    }

    /// <summary>
    /// The value to use for filtering
    /// </summary>
    public required string Value
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "value"); }
        init { ModelBase.Set(this._rawData, "value", value); }
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="FilterConfigFromRaw.FromRawUnchecked"/>
    public static FilterConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FilterConfigFromRaw : IFromRaw<FilterConfig>
{
    /// <inheritdoc/>
    public FilterConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FilterConfig.FromRawUnchecked(rawData);
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
