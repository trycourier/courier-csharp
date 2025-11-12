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
    public required ApiEnum<string, OperatorModel> Operator
    {
        get
        {
            if (!this._properties.TryGetValue("operator", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'operator' cannot be null",
                    new System::ArgumentOutOfRangeException("operator", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, OperatorModel>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["operator"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("path", out JsonElement element))
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
            this._properties["path"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("value", out JsonElement element))
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
            this._properties["value"] = JsonSerializer.SerializeToElement(
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

    public FilterConfig(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FilterConfig(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static FilterConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// The operator to use for filtering
/// </summary>
[JsonConverter(typeof(OperatorModelConverter))]
public enum OperatorModel
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

sealed class OperatorModelConverter : JsonConverter<OperatorModel>
{
    public override OperatorModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ENDS_WITH" => OperatorModel.EndsWith,
            "EQ" => OperatorModel.Eq,
            "EXISTS" => OperatorModel.Exists,
            "GT" => OperatorModel.Gt,
            "GTE" => OperatorModel.Gte,
            "INCLUDES" => OperatorModel.Includes,
            "IS_AFTER" => OperatorModel.IsAfter,
            "IS_BEFORE" => OperatorModel.IsBefore,
            "LT" => OperatorModel.Lt,
            "LTE" => OperatorModel.Lte,
            "NEQ" => OperatorModel.Neq,
            "OMIT" => OperatorModel.Omit,
            "STARTS_WITH" => OperatorModel.StartsWith,
            "AND" => OperatorModel.And,
            "OR" => OperatorModel.Or,
            _ => (OperatorModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OperatorModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                OperatorModel.EndsWith => "ENDS_WITH",
                OperatorModel.Eq => "EQ",
                OperatorModel.Exists => "EXISTS",
                OperatorModel.Gt => "GT",
                OperatorModel.Gte => "GTE",
                OperatorModel.Includes => "INCLUDES",
                OperatorModel.IsAfter => "IS_AFTER",
                OperatorModel.IsBefore => "IS_BEFORE",
                OperatorModel.Lt => "LT",
                OperatorModel.Lte => "LTE",
                OperatorModel.Neq => "NEQ",
                OperatorModel.Omit => "OMIT",
                OperatorModel.StartsWith => "STARTS_WITH",
                OperatorModel.And => "AND",
                OperatorModel.Or => "OR",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
