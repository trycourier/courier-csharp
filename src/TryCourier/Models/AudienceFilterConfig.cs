using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models;

/// <summary>
/// Filter configuration for audience membership containing an array of filter rules
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AudienceFilterConfig, AudienceFilterConfigFromRaw>))]
public sealed record class AudienceFilterConfig : JsonModel
{
    /// <summary>
    /// Array of filter rules (single conditions or nested groups)
    /// </summary>
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
    /// The logical operator (AND/OR) combining the rules in `filters`. Required
    /// when `filters` contains more than one rule. If omitted, the top-level `operator`
    /// field on the request is used instead.
    /// </summary>
    public ApiEnum<string, AudienceFilterConfigOperator>? Operator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AudienceFilterConfigOperator>>(
                "operator"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("operator", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
        this.Operator?.Validate();
    }

    public AudienceFilterConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AudienceFilterConfig(AudienceFilterConfig audienceFilterConfig)
        : base(audienceFilterConfig) { }
#pragma warning restore CS8618

    public AudienceFilterConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudienceFilterConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudienceFilterConfigFromRaw.FromRawUnchecked"/>
    public static AudienceFilterConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AudienceFilterConfig(IReadOnlyList<FilterConfig> filters)
        : this()
    {
        this.Filters = filters;
    }
}

class AudienceFilterConfigFromRaw : IFromRawJson<AudienceFilterConfig>
{
    /// <inheritdoc/>
    public AudienceFilterConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AudienceFilterConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// The logical operator (AND/OR) combining the rules in `filters`. Required when
/// `filters` contains more than one rule. If omitted, the top-level `operator` field
/// on the request is used instead.
/// </summary>
[JsonConverter(typeof(AudienceFilterConfigOperatorConverter))]
public enum AudienceFilterConfigOperator
{
    And,
    Or,
}

sealed class AudienceFilterConfigOperatorConverter : JsonConverter<AudienceFilterConfigOperator>
{
    public override AudienceFilterConfigOperator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AND" => AudienceFilterConfigOperator.And,
            "OR" => AudienceFilterConfigOperator.Or,
            _ => (AudienceFilterConfigOperator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AudienceFilterConfigOperator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AudienceFilterConfigOperator.And => "AND",
                AudienceFilterConfigOperator.Or => "OR",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
