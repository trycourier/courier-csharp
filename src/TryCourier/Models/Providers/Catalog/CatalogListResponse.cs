using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Providers.Catalog;

/// <summary>
/// Paginated list of available provider types with their configuration schemas.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CatalogListResponse, CatalogListResponseFromRaw>))]
public sealed record class CatalogListResponse : JsonModel
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

    public required IReadOnlyList<ProvidersCatalogEntry> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ProvidersCatalogEntry>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ProvidersCatalogEntry>>(
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

    public CatalogListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CatalogListResponse(CatalogListResponse catalogListResponse)
        : base(catalogListResponse) { }
#pragma warning restore CS8618

    public CatalogListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CatalogListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CatalogListResponseFromRaw.FromRawUnchecked"/>
    public static CatalogListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CatalogListResponseFromRaw : IFromRawJson<CatalogListResponse>
{
    /// <inheritdoc/>
    public CatalogListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CatalogListResponse.FromRawUnchecked(rawData);
}
