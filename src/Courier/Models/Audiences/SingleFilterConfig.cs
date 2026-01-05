using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Audiences;

[JsonConverter(typeof(JsonModelConverter<SingleFilterConfig, SingleFilterConfigFromRaw>))]
public sealed record class SingleFilterConfig : JsonModel
{
    /// <summary>
    /// The operator to use for filtering
    /// </summary>
    public required ApiEnum<string, SingleFilterConfigOperator> Operator
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, SingleFilterConfigOperator>>(
                this.RawData,
                "operator"
            );
        }
        init { JsonModel.Set(this._rawData, "operator", value); }
    }

    /// <summary>
    /// The attribe name from profile whose value will be operated against the filter value
    /// </summary>
    public required string Path
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "path"); }
        init { JsonModel.Set(this._rawData, "path", value); }
    }

    /// <summary>
    /// The value to use for filtering
    /// </summary>
    public required string Value
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "value"); }
        init { JsonModel.Set(this._rawData, "value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Operator.Validate();
        _ = this.Path;
        _ = this.Value;
    }

    public SingleFilterConfig() { }

    public SingleFilterConfig(SingleFilterConfig singleFilterConfig)
        : base(singleFilterConfig) { }

    public SingleFilterConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SingleFilterConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SingleFilterConfigFromRaw.FromRawUnchecked"/>
    public static SingleFilterConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SingleFilterConfigFromRaw : IFromRawJson<SingleFilterConfig>
{
    /// <inheritdoc/>
    public SingleFilterConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SingleFilterConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The operator to use for filtering
/// </summary>
[JsonConverter(typeof(SingleFilterConfigOperatorConverter))]
public enum SingleFilterConfigOperator
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

sealed class SingleFilterConfigOperatorConverter : JsonConverter<SingleFilterConfigOperator>
{
    public override SingleFilterConfigOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ENDS_WITH" => SingleFilterConfigOperator.EndsWith,
            "EQ" => SingleFilterConfigOperator.Eq,
            "EXISTS" => SingleFilterConfigOperator.Exists,
            "GT" => SingleFilterConfigOperator.Gt,
            "GTE" => SingleFilterConfigOperator.Gte,
            "INCLUDES" => SingleFilterConfigOperator.Includes,
            "IS_AFTER" => SingleFilterConfigOperator.IsAfter,
            "IS_BEFORE" => SingleFilterConfigOperator.IsBefore,
            "LT" => SingleFilterConfigOperator.Lt,
            "LTE" => SingleFilterConfigOperator.Lte,
            "NEQ" => SingleFilterConfigOperator.Neq,
            "OMIT" => SingleFilterConfigOperator.Omit,
            "STARTS_WITH" => SingleFilterConfigOperator.StartsWith,
            "AND" => SingleFilterConfigOperator.And,
            "OR" => SingleFilterConfigOperator.Or,
            _ => (SingleFilterConfigOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SingleFilterConfigOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SingleFilterConfigOperator.EndsWith => "ENDS_WITH",
                SingleFilterConfigOperator.Eq => "EQ",
                SingleFilterConfigOperator.Exists => "EXISTS",
                SingleFilterConfigOperator.Gt => "GT",
                SingleFilterConfigOperator.Gte => "GTE",
                SingleFilterConfigOperator.Includes => "INCLUDES",
                SingleFilterConfigOperator.IsAfter => "IS_AFTER",
                SingleFilterConfigOperator.IsBefore => "IS_BEFORE",
                SingleFilterConfigOperator.Lt => "LT",
                SingleFilterConfigOperator.Lte => "LTE",
                SingleFilterConfigOperator.Neq => "NEQ",
                SingleFilterConfigOperator.Omit => "OMIT",
                SingleFilterConfigOperator.StartsWith => "STARTS_WITH",
                SingleFilterConfigOperator.And => "AND",
                SingleFilterConfigOperator.Or => "OR",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
