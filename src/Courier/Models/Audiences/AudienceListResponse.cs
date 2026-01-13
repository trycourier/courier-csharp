using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        get { return this._rawData.GetNotNullStruct<ImmutableArray<Audience>>("items"); }
        init
        {
            this._rawData.Set<ImmutableArray<Audience>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Paging Paging
    {
        get { return this._rawData.GetNotNullClass<Paging>("paging"); }
        init { this._rawData.Set("paging", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudienceListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
