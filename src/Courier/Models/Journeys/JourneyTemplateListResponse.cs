using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Journeys;

/// <summary>
/// Paged list of journey-scoped notification templates.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<JourneyTemplateListResponse, JourneyTemplateListResponseFromRaw>)
)]
public sealed record class JourneyTemplateListResponse : JsonModel
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

    public required IReadOnlyList<JourneyTemplateSummary> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<JourneyTemplateSummary>>(
                "results"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<JourneyTemplateSummary>>(
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

    public JourneyTemplateListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyTemplateListResponse(JourneyTemplateListResponse journeyTemplateListResponse)
        : base(journeyTemplateListResponse) { }
#pragma warning restore CS8618

    public JourneyTemplateListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyTemplateListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyTemplateListResponseFromRaw.FromRawUnchecked"/>
    public static JourneyTemplateListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyTemplateListResponseFromRaw : IFromRawJson<JourneyTemplateListResponse>
{
    /// <inheritdoc/>
    public JourneyTemplateListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyTemplateListResponse.FromRawUnchecked(rawData);
}
