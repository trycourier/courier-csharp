using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.WorkspacePreferences;

/// <summary>
/// Topics contained in a workspace preference.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkspacePreferenceTopicListResponse,
        WorkspacePreferenceTopicListResponseFromRaw
    >)
)]
public sealed record class WorkspacePreferenceTopicListResponse : JsonModel
{
    public required IReadOnlyList<WorkspacePreferenceTopicGetResponse> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<WorkspacePreferenceTopicGetResponse>
            >("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WorkspacePreferenceTopicGetResponse>>(
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

    public WorkspacePreferenceTopicListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspacePreferenceTopicListResponse(
        WorkspacePreferenceTopicListResponse workspacePreferenceTopicListResponse
    )
        : base(workspacePreferenceTopicListResponse) { }
#pragma warning restore CS8618

    public WorkspacePreferenceTopicListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspacePreferenceTopicListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspacePreferenceTopicListResponseFromRaw.FromRawUnchecked"/>
    public static WorkspacePreferenceTopicListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WorkspacePreferenceTopicListResponse(
        IReadOnlyList<WorkspacePreferenceTopicGetResponse> results
    )
        : this()
    {
        this.Results = results;
    }
}

class WorkspacePreferenceTopicListResponseFromRaw
    : IFromRawJson<WorkspacePreferenceTopicListResponse>
{
    /// <inheritdoc/>
    public WorkspacePreferenceTopicListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspacePreferenceTopicListResponse.FromRawUnchecked(rawData);
}
