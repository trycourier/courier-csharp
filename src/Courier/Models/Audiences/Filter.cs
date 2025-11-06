using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Audiences;

[JsonConverter(typeof(ModelConverter<Filter>))]
public sealed record class Filter : ModelBase, IFromRaw<Filter>
{
    /// <summary>
    /// The operator to use for filtering
    /// </summary>
    public required ApiEnum<string, Operator> Operator
    {
        get
        {
            if (!this.Properties.TryGetValue("operator", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["operator"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("path", out JsonElement element))
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
        set
        {
            this.Properties["path"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("value", out JsonElement element))
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
        set
        {
            this.Properties["value"] = JsonSerializer.SerializeToElement(
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

    public Filter() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Filter FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
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
