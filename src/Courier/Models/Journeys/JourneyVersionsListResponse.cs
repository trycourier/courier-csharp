using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Journeys;

[JsonConverter(
    typeof(JsonModelConverter<JourneyVersionsListResponse, JourneyVersionsListResponseFromRaw>)
)]
public sealed record class JourneyVersionsListResponse : JsonModel
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

    public required IReadOnlyList<JourneyVersionItem> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JourneyVersionItem>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<JourneyVersionItem>>(
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

    public JourneyVersionsListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyVersionsListResponse(JourneyVersionsListResponse journeyVersionsListResponse)
        : base(journeyVersionsListResponse) { }
#pragma warning restore CS8618

    public JourneyVersionsListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyVersionsListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyVersionsListResponseFromRaw.FromRawUnchecked"/>
    public static JourneyVersionsListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyVersionsListResponseFromRaw : IFromRawJson<JourneyVersionsListResponse>
{
    /// <inheritdoc/>
    public JourneyVersionsListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyVersionsListResponse.FromRawUnchecked(rawData);
}
