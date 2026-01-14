using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Filters)
        {
            item.Validate();
        }
    }

    public AudienceFilterConfig() { }

    public AudienceFilterConfig(AudienceFilterConfig audienceFilterConfig)
        : base(audienceFilterConfig) { }

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
