using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Providers;

/// <summary>
/// Paginated list of provider configurations.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProviderListResponse, ProviderListResponseFromRaw>))]
public sealed record class ProviderListResponse : JsonModel
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

    public required IReadOnlyList<Provider> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Provider>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Provider>>(
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

    public ProviderListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProviderListResponse(ProviderListResponse providerListResponse)
        : base(providerListResponse) { }
#pragma warning restore CS8618

    public ProviderListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProviderListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProviderListResponseFromRaw.FromRawUnchecked"/>
    public static ProviderListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProviderListResponseFromRaw : IFromRawJson<ProviderListResponse>
{
    /// <inheritdoc/>
    public ProviderListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProviderListResponse.FromRawUnchecked(rawData);
}
