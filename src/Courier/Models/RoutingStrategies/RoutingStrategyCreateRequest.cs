using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.RoutingStrategies;

/// <summary>
/// Request body for creating a routing strategy.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RoutingStrategyCreateRequest, RoutingStrategyCreateRequestFromRaw>)
)]
public sealed record class RoutingStrategyCreateRequest : JsonModel
{
    /// <summary>
    /// Human-readable name for the routing strategy.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Routing tree defining channel selection method and order.
    /// </summary>
    public required MessageRouting Routing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MessageRouting>("routing");
        }
        init { this._rawData.Set("routing", value); }
    }

    /// <summary>
    /// Per-channel delivery configuration. Defaults to empty if omitted.
    /// </summary>
    public IReadOnlyDictionary<string, Channel>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, Channel>>("channels");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, Channel>?>(
                "channels",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Optional description of the routing strategy.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Per-provider delivery configuration. Defaults to empty if omitted.
    /// </summary>
    public IReadOnlyDictionary<string, MessageProvidersType>? Providers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, MessageProvidersType>>(
                "providers"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, MessageProvidersType>?>(
                "providers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Optional tags for categorization.
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        this.Routing.Validate();
        if (this.Channels != null)
        {
            foreach (var item in this.Channels.Values)
            {
                item.Validate();
            }
        }
        _ = this.Description;
        if (this.Providers != null)
        {
            foreach (var item in this.Providers.Values)
            {
                item.Validate();
            }
        }
        _ = this.Tags;
    }

    public RoutingStrategyCreateRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoutingStrategyCreateRequest(RoutingStrategyCreateRequest routingStrategyCreateRequest)
        : base(routingStrategyCreateRequest) { }
#pragma warning restore CS8618

    public RoutingStrategyCreateRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RoutingStrategyCreateRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RoutingStrategyCreateRequestFromRaw.FromRawUnchecked"/>
    public static RoutingStrategyCreateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RoutingStrategyCreateRequestFromRaw : IFromRawJson<RoutingStrategyCreateRequest>
{
    /// <inheritdoc/>
    public RoutingStrategyCreateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RoutingStrategyCreateRequest.FromRawUnchecked(rawData);
}
