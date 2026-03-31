using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.RoutingStrategies;

/// <summary>
/// Routing strategy metadata returned in list responses. Does not include routing/channels/providers content.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RoutingStrategySummary, RoutingStrategySummaryFromRaw>))]
public sealed record class RoutingStrategySummary : JsonModel
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
        _ = this.Created;
        _ = this.Creator;
        _ = this.Name;
        _ = this.Description;
        _ = this.Tags;
        _ = this.Updated;
        _ = this.Updater;
    }

    public RoutingStrategySummary() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoutingStrategySummary(RoutingStrategySummary routingStrategySummary)
        : base(routingStrategySummary) { }
#pragma warning restore CS8618

    public RoutingStrategySummary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RoutingStrategySummary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RoutingStrategySummaryFromRaw.FromRawUnchecked"/>
    public static RoutingStrategySummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RoutingStrategySummaryFromRaw : IFromRawJson<RoutingStrategySummary>
{
    /// <inheritdoc/>
    public RoutingStrategySummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RoutingStrategySummary.FromRawUnchecked(rawData);
}
