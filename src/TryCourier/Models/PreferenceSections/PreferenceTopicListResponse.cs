using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.PreferenceSections;

/// <summary>
/// Topics contained in a preference section.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PreferenceTopicListResponse, PreferenceTopicListResponseFromRaw>)
)]
public sealed record class PreferenceTopicListResponse : JsonModel
{
    public required IReadOnlyList<PreferenceTopicGetResponse> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PreferenceTopicGetResponse>>(
                "results"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PreferenceTopicGetResponse>>(
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

    public PreferenceTopicListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceTopicListResponse(PreferenceTopicListResponse preferenceTopicListResponse)
        : base(preferenceTopicListResponse) { }
#pragma warning restore CS8618

    public PreferenceTopicListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceTopicListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceTopicListResponseFromRaw.FromRawUnchecked"/>
    public static PreferenceTopicListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PreferenceTopicListResponse(IReadOnlyList<PreferenceTopicGetResponse> results)
        : this()
    {
        this.Results = results;
    }
}

class PreferenceTopicListResponseFromRaw : IFromRawJson<PreferenceTopicListResponse>
{
    /// <inheritdoc/>
    public PreferenceTopicListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceTopicListResponse.FromRawUnchecked(rawData);
}
