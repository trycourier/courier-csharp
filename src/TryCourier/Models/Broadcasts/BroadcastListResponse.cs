using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Broadcasts;

/// <summary>
/// Paginated list of broadcasts.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BroadcastListResponse, BroadcastListResponseFromRaw>))]
public sealed record class BroadcastListResponse : JsonModel
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

    public required IReadOnlyList<Broadcast> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Broadcast>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Broadcast>>(
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

    public BroadcastListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BroadcastListResponse(BroadcastListResponse broadcastListResponse)
        : base(broadcastListResponse) { }
#pragma warning restore CS8618

    public BroadcastListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BroadcastListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastListResponseFromRaw.FromRawUnchecked"/>
    public static BroadcastListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BroadcastListResponseFromRaw : IFromRawJson<BroadcastListResponse>
{
    /// <inheritdoc/>
    public BroadcastListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BroadcastListResponse.FromRawUnchecked(rawData);
}
