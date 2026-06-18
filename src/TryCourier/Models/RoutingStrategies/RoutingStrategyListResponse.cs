using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.RoutingStrategies;

/// <summary>
/// Paginated list of routing strategy summaries.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RoutingStrategyListResponse, RoutingStrategyListResponseFromRaw>)
)]
public sealed record class RoutingStrategyListResponse : JsonModel
{
    public required Paging Paging
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Paging>("paging");
        }
        init { this._rawData.Set("paging", value); }
    }

    public required IReadOnlyList<RoutingStrategySummary> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RoutingStrategySummary>>(
                "results"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<RoutingStrategySummary>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Paging.Validate();
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public RoutingStrategyListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoutingStrategyListResponse(RoutingStrategyListResponse routingStrategyListResponse)
        : base(routingStrategyListResponse) { }
#pragma warning restore CS8618

    public RoutingStrategyListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RoutingStrategyListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RoutingStrategyListResponseFromRaw.FromRawUnchecked"/>
    public static RoutingStrategyListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RoutingStrategyListResponseFromRaw : IFromRawJson<RoutingStrategyListResponse>
{
    /// <inheritdoc/>
    public RoutingStrategyListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RoutingStrategyListResponse.FromRawUnchecked(rawData);
}
