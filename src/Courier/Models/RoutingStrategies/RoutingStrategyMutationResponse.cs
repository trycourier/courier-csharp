using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.RoutingStrategies;

/// <summary>
/// Response returned by create and replace operations.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        RoutingStrategyMutationResponse,
        RoutingStrategyMutationResponseFromRaw
    >)
)]
public sealed record class RoutingStrategyMutationResponse : JsonModel
{
    /// <summary>
    /// The routing strategy ID (rs_ prefix).
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public RoutingStrategyMutationResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoutingStrategyMutationResponse(
        RoutingStrategyMutationResponse routingStrategyMutationResponse
    )
        : base(routingStrategyMutationResponse) { }
#pragma warning restore CS8618

    public RoutingStrategyMutationResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RoutingStrategyMutationResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RoutingStrategyMutationResponseFromRaw.FromRawUnchecked"/>
    public static RoutingStrategyMutationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RoutingStrategyMutationResponse(string id)
        : this()
    {
        this.ID = id;
    }
}

class RoutingStrategyMutationResponseFromRaw : IFromRawJson<RoutingStrategyMutationResponse>
{
    /// <inheritdoc/>
    public RoutingStrategyMutationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RoutingStrategyMutationResponse.FromRawUnchecked(rawData);
}
