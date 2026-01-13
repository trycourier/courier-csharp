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
    /// <summary>
    /// The operator to use for filtering
    /// </summary>
    public required ApiEnum<string, global::Courier.Models.Audiences.Operator> Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Courier.Models.Audiences.Operator>
            >("operator");
        }
        init { this._rawData.Set("operator", value); }
    }

    public required IReadOnlyList<Filter> Rules
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Filter>>("rules");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Filter>>(
                "rules",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Operator.Validate();
        foreach (var item in this.Rules)
        {
            item.Validate();
        }
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
[JsonConverter(typeof(global::Courier.Models.Audiences.OperatorConverter))]
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

sealed class OperatorConverter : JsonConverter<global::Courier.Models.Audiences.Operator>
{
    public override global::Courier.Models.Audiences.Operator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ENDS_WITH" => global::Courier.Models.Audiences.Operator.EndsWith,
            "EQ" => global::Courier.Models.Audiences.Operator.Eq,
            "EXISTS" => global::Courier.Models.Audiences.Operator.Exists,
            "GT" => global::Courier.Models.Audiences.Operator.Gt,
            "GTE" => global::Courier.Models.Audiences.Operator.Gte,
            "INCLUDES" => global::Courier.Models.Audiences.Operator.Includes,
            "IS_AFTER" => global::Courier.Models.Audiences.Operator.IsAfter,
            "IS_BEFORE" => global::Courier.Models.Audiences.Operator.IsBefore,
            "LT" => global::Courier.Models.Audiences.Operator.Lt,
            "LTE" => global::Courier.Models.Audiences.Operator.Lte,
            "NEQ" => global::Courier.Models.Audiences.Operator.Neq,
            "OMIT" => global::Courier.Models.Audiences.Operator.Omit,
            "STARTS_WITH" => global::Courier.Models.Audiences.Operator.StartsWith,
            "AND" => global::Courier.Models.Audiences.Operator.And,
            "OR" => global::Courier.Models.Audiences.Operator.Or,
            _ => (global::Courier.Models.Audiences.Operator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Courier.Models.Audiences.Operator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Courier.Models.Audiences.Operator.EndsWith => "ENDS_WITH",
                global::Courier.Models.Audiences.Operator.Eq => "EQ",
                global::Courier.Models.Audiences.Operator.Exists => "EXISTS",
                global::Courier.Models.Audiences.Operator.Gt => "GT",
                global::Courier.Models.Audiences.Operator.Gte => "GTE",
                global::Courier.Models.Audiences.Operator.Includes => "INCLUDES",
                global::Courier.Models.Audiences.Operator.IsAfter => "IS_AFTER",
                global::Courier.Models.Audiences.Operator.IsBefore => "IS_BEFORE",
                global::Courier.Models.Audiences.Operator.Lt => "LT",
                global::Courier.Models.Audiences.Operator.Lte => "LTE",
                global::Courier.Models.Audiences.Operator.Neq => "NEQ",
                global::Courier.Models.Audiences.Operator.Omit => "OMIT",
                global::Courier.Models.Audiences.Operator.StartsWith => "STARTS_WITH",
                global::Courier.Models.Audiences.Operator.And => "AND",
                global::Courier.Models.Audiences.Operator.Or => "OR",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
