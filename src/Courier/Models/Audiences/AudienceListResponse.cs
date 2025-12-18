using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Audiences;

[JsonConverter(typeof(JsonModelConverter<AudienceListResponse, AudienceListResponseFromRaw>))]
public sealed record class AudienceListResponse : JsonModel
{
    public required IReadOnlyList<Audience> Items
    {
        get { return JsonModel.GetNotNullClass<List<Audience>>(this.RawData, "items"); }
        init { JsonModel.Set(this._rawData, "items", value); }
    }

    public required Paging Paging
    {
        get { return JsonModel.GetNotNullClass<Paging>(this.RawData, "paging"); }
        init { JsonModel.Set(this._rawData, "paging", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        this.Paging.Validate();
    }

    public AudienceListResponse() { }

    public AudienceListResponse(AudienceListResponse audienceListResponse)
        : base(audienceListResponse) { }

    public AudienceListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudienceListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudienceListResponseFromRaw.FromRawUnchecked"/>
    public static AudienceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudienceListResponseFromRaw : IFromRawJson<AudienceListResponse>
{
    /// <inheritdoc/>
    public AudienceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AudienceListResponse.FromRawUnchecked(rawData);
}
