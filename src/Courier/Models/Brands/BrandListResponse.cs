using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandListResponse, BrandListResponseFromRaw>))]
public sealed record class BrandListResponse : ModelBase
{
    public required Paging Paging
    {
        get
        {
            if (!this._rawData.TryGetValue("paging", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'paging' cannot be null",
                    new ArgumentOutOfRangeException("paging", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Paging>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'paging' cannot be null",
                    new ArgumentNullException("paging")
                );
        }
        init
        {
            this._rawData["paging"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required List<Brand> Results
    {
        get
        {
            if (!this._rawData.TryGetValue("results", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'results' cannot be null",
                    new ArgumentOutOfRangeException("results", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Brand>>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'results' cannot be null",
                    new ArgumentNullException("results")
                );
        }
        init
        {
            this._rawData["results"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Paging.Validate();
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public BrandListResponse() { }

    public BrandListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BrandListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandListResponseFromRaw : IFromRaw<BrandListResponse>
{
    public BrandListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandListResponse.FromRawUnchecked(rawData);
}
