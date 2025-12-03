using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Audiences;

[JsonConverter(typeof(ModelConverter<AudienceListResponse, AudienceListResponseFromRaw>))]
public sealed record class AudienceListResponse : ModelBase
{
    public required IReadOnlyList<Audience> Items
    {
        get { return ModelBase.GetNotNullClass<List<Audience>>(this.RawData, "items"); }
        init { ModelBase.Set(this._rawData, "items", value); }
    }

    public required Paging Paging
    {
        get { return ModelBase.GetNotNullClass<Paging>(this.RawData, "paging"); }
        init { ModelBase.Set(this._rawData, "paging", value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        this.Paging.Validate();
    }

    public AudienceListResponse() { }

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

    public static AudienceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudienceListResponseFromRaw : IFromRaw<AudienceListResponse>
{
    public AudienceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AudienceListResponse.FromRawUnchecked(rawData);
}
