using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.RoutingStrategies;

/// <summary>
/// Full routing strategy entity returned by GET.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RoutingStrategyGetResponse, RoutingStrategyGetResponseFromRaw>)
)]
public sealed record class RoutingStrategyGetResponse : JsonModel
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

    /// <summary>
    /// Per-channel delivery configuration. May be empty.
    /// </summary>
    public required IReadOnlyDictionary<string, Channel> Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, Channel>>("channels");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, Channel>>(
                "channels",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Epoch milliseconds when the strategy was created.
    /// </summary>
    public required long Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    /// <summary>
    /// User ID of the creator.
    /// </summary>
    public required string Creator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creator");
        }
        init { this._rawData.Set("creator", value); }
    }

    /// <summary>
    /// Human-readable name.
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
    /// Per-provider delivery configuration. May be empty.
    /// </summary>
    public required IReadOnlyDictionary<string, MessageProvidersType> Providers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, MessageProvidersType>>(
                "providers"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, MessageProvidersType>>(
                "providers",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
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
    /// Description of the routing strategy.
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
    /// Tags for categorization.
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

    /// <summary>
    /// Epoch milliseconds of last update.
    /// </summary>
    public long? Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("updated");
        }
        init { this._rawData.Set("updated", value); }
    }

    /// <summary>
    /// User ID of the last updater.
    /// </summary>
    public string? Updater
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updater");
        }
        init { this._rawData.Set("updater", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Channels.Values)
        {
            item.Validate();
        }
        _ = this.Created;
        _ = this.Creator;
        _ = this.Name;
        foreach (var item in this.Providers.Values)
        {
            item.Validate();
        }
        this.Routing.Validate();
        _ = this.Description;
        _ = this.Tags;
        _ = this.Updated;
        _ = this.Updater;
    }

    public RoutingStrategyGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoutingStrategyGetResponse(RoutingStrategyGetResponse routingStrategyGetResponse)
        : base(routingStrategyGetResponse) { }
#pragma warning restore CS8618

    public RoutingStrategyGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RoutingStrategyGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RoutingStrategyGetResponseFromRaw.FromRawUnchecked"/>
    public static RoutingStrategyGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RoutingStrategyGetResponseFromRaw : IFromRawJson<RoutingStrategyGetResponse>
{
    /// <inheritdoc/>
    public RoutingStrategyGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RoutingStrategyGetResponse.FromRawUnchecked(rawData);
}
