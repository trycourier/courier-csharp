using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.PreferenceSections;

/// <summary>
/// The workspace's preference sections, each with its topics.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PreferenceSectionListResponse, PreferenceSectionListResponseFromRaw>)
)]
public sealed record class PreferenceSectionListResponse : JsonModel
{
    public required IReadOnlyList<PreferenceSectionGetResponse> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PreferenceSectionGetResponse>>(
                "results"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PreferenceSectionGetResponse>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public PreferenceSectionListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceSectionListResponse(
        PreferenceSectionListResponse preferenceSectionListResponse
    )
        : base(preferenceSectionListResponse) { }
#pragma warning restore CS8618

    public PreferenceSectionListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceSectionListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceSectionListResponseFromRaw.FromRawUnchecked"/>
    public static PreferenceSectionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PreferenceSectionListResponse(IReadOnlyList<PreferenceSectionGetResponse> results)
        : this()
    {
        this.Results = results;
    }
}

class PreferenceSectionListResponseFromRaw : IFromRawJson<PreferenceSectionListResponse>
{
    /// <inheritdoc/>
    public PreferenceSectionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceSectionListResponse.FromRawUnchecked(rawData);
}
