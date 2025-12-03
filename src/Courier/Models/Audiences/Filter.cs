using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Audiences;

[JsonConverter(typeof(ModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : ModelBase
{
    /// <summary>
    /// The operator to use for filtering
    /// </summary>
    public required ApiEnum<string, Operator> Operator
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, Operator>>(this.RawData, "operator");
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

    public override void Validate()
    {
        this.Operator.Validate();
        _ = this.Path;
        _ = this.Value;
    }

    public Filter() { }

    public Filter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Filter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FilterFromRaw : IFromRaw<Filter>
{
    public Filter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// The operator to use for filtering
/// </summary>
[JsonConverter(typeof(OperatorConverter))]
public enum Operator
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

sealed class OperatorConverter : JsonConverter<Operator>
{
    public override Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ENDS_WITH" => Operator.EndsWith,
            "EQ" => Operator.Eq,
            "EXISTS" => Operator.Exists,
            "GT" => Operator.Gt,
            "GTE" => Operator.Gte,
            "INCLUDES" => Operator.Includes,
            "IS_AFTER" => Operator.IsAfter,
            "IS_BEFORE" => Operator.IsBefore,
            "LT" => Operator.Lt,
            "LTE" => Operator.Lte,
            "NEQ" => Operator.Neq,
            "OMIT" => Operator.Omit,
            "STARTS_WITH" => Operator.StartsWith,
            "AND" => Operator.And,
            "OR" => Operator.Or,
            _ => (Operator)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Operator value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Operator.EndsWith => "ENDS_WITH",
                Operator.Eq => "EQ",
                Operator.Exists => "EXISTS",
                Operator.Gt => "GT",
                Operator.Gte => "GTE",
                Operator.Includes => "INCLUDES",
                Operator.IsAfter => "IS_AFTER",
                Operator.IsBefore => "IS_BEFORE",
                Operator.Lt => "LT",
                Operator.Lte => "LTE",
                Operator.Neq => "NEQ",
                Operator.Omit => "OMIT",
                Operator.StartsWith => "STARTS_WITH",
                Operator.And => "AND",
                Operator.Or => "OR",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
