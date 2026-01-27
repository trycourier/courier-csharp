using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

/// <summary>
/// A filter rule that can be either a single condition (with path/value) or a  nested
/// group (with filters array). Use comparison operators (EQ, GT, etc.)  for single
/// conditions, and logical operators (AND, OR) for nested groups.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FilterConfig, FilterConfigFromRaw>))]
public sealed record class FilterConfig : JsonModel
{
    /// <summary>
    /// The operator for this filter. Use comparison operators (EQ, GT, LT, GTE,
    /// LTE,  NEQ, EXISTS, INCLUDES, STARTS_WITH, ENDS_WITH, IS_BEFORE, IS_AFTER,
    /// OMIT) for  single conditions, or logical operators (AND, OR) for nested filter groups.
    /// </summary>
    public required string Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("operator");
        }
        init { this._rawData.Set("operator", value); }
    }

    /// <summary>
    /// Nested filter rules to combine with AND/OR. Required for nested filter groups,
    /// not used for single filter conditions.
    /// </summary>
    public IReadOnlyList<FilterConfig>? Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FilterConfig>>("filters");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FilterConfig>?>(
                "filters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The attribute path from the user profile to filter on. Required for single
    ///  filter conditions, not used for nested filter groups.
    /// </summary>
    public string? Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("path");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("path", value);
        }
    }

    /// <summary>
    /// The value to compare against. Required for single filter conditions,  not
    /// used for nested filter groups.
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Operator;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.Path;
        _ = this.Value;
    }

    public FilterConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FilterConfig(FilterConfig filterConfig)
        : base(filterConfig) { }
#pragma warning restore CS8618

    public FilterConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FilterConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FilterConfigFromRaw.FromRawUnchecked"/>
    public static FilterConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FilterConfig(string operator_)
        : this()
    {
        this.Operator = operator_;
    }
}

class FilterConfigFromRaw : IFromRawJson<FilterConfig>
{
    /// <inheritdoc/>
    public FilterConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FilterConfig.FromRawUnchecked(rawData);
}
