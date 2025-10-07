using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Audiences.FilterProperties;

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
        Type typeToConvert,
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
