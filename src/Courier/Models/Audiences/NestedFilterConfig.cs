using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Audiences;

[JsonConverter(typeof(JsonModelConverter<NestedFilterConfig, NestedFilterConfigFromRaw>))]
public sealed record class NestedFilterConfig : JsonModel
{
    public required IReadOnlyList<FilterConfig> Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FilterConfig>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FilterConfig>>(
                "filters",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The operator to use for filtering
    /// </summary>
    public required ApiEnum<string, NestedFilterConfigOperator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, NestedFilterConfigOperator>>(
                "operator"
            );
        }
        init { this._rawData.Set("operator", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        this.Operator.Validate();
    }

    public NestedFilterConfig() { }

    public NestedFilterConfig(NestedFilterConfig nestedFilterConfig)
        : base(nestedFilterConfig) { }

    public NestedFilterConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NestedFilterConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NestedFilterConfigFromRaw.FromRawUnchecked"/>
    public static NestedFilterConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NestedFilterConfigFromRaw : IFromRawJson<NestedFilterConfig>
{
    /// <inheritdoc/>
    public NestedFilterConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NestedFilterConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The operator to use for filtering
/// </summary>
[JsonConverter(typeof(NestedFilterConfigOperatorConverter))]
public enum NestedFilterConfigOperator
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

sealed class NestedFilterConfigOperatorConverter : JsonConverter<NestedFilterConfigOperator>
{
    public override NestedFilterConfigOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ENDS_WITH" => NestedFilterConfigOperator.EndsWith,
            "EQ" => NestedFilterConfigOperator.Eq,
            "EXISTS" => NestedFilterConfigOperator.Exists,
            "GT" => NestedFilterConfigOperator.Gt,
            "GTE" => NestedFilterConfigOperator.Gte,
            "INCLUDES" => NestedFilterConfigOperator.Includes,
            "IS_AFTER" => NestedFilterConfigOperator.IsAfter,
            "IS_BEFORE" => NestedFilterConfigOperator.IsBefore,
            "LT" => NestedFilterConfigOperator.Lt,
            "LTE" => NestedFilterConfigOperator.Lte,
            "NEQ" => NestedFilterConfigOperator.Neq,
            "OMIT" => NestedFilterConfigOperator.Omit,
            "STARTS_WITH" => NestedFilterConfigOperator.StartsWith,
            "AND" => NestedFilterConfigOperator.And,
            "OR" => NestedFilterConfigOperator.Or,
            _ => (NestedFilterConfigOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NestedFilterConfigOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NestedFilterConfigOperator.EndsWith => "ENDS_WITH",
                NestedFilterConfigOperator.Eq => "EQ",
                NestedFilterConfigOperator.Exists => "EXISTS",
                NestedFilterConfigOperator.Gt => "GT",
                NestedFilterConfigOperator.Gte => "GTE",
                NestedFilterConfigOperator.Includes => "INCLUDES",
                NestedFilterConfigOperator.IsAfter => "IS_AFTER",
                NestedFilterConfigOperator.IsBefore => "IS_BEFORE",
                NestedFilterConfigOperator.Lt => "LT",
                NestedFilterConfigOperator.Lte => "LTE",
                NestedFilterConfigOperator.Neq => "NEQ",
                NestedFilterConfigOperator.Omit => "OMIT",
                NestedFilterConfigOperator.StartsWith => "STARTS_WITH",
                NestedFilterConfigOperator.And => "AND",
                NestedFilterConfigOperator.Or => "OR",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
