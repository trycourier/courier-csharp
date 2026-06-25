using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.WorkspacePreferences;

/// <summary>
/// The workspace's preferences, each with its topics.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkspacePreferenceListResponse,
        WorkspacePreferenceListResponseFromRaw
    >)
)]
public sealed record class WorkspacePreferenceListResponse : JsonModel
{
    public required IReadOnlyList<WorkspacePreferenceGetResponse> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WorkspacePreferenceGetResponse>>(
                "results"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<WorkspacePreferenceGetResponse>>(
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

    public WorkspacePreferenceListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspacePreferenceListResponse(
        WorkspacePreferenceListResponse workspacePreferenceListResponse
    )
        : base(workspacePreferenceListResponse) { }
#pragma warning restore CS8618

    public WorkspacePreferenceListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspacePreferenceListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspacePreferenceListResponseFromRaw.FromRawUnchecked"/>
    public static WorkspacePreferenceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WorkspacePreferenceListResponse(IReadOnlyList<WorkspacePreferenceGetResponse> results)
        : this()
    {
        this.Results = results;
    }
}

class WorkspacePreferenceListResponseFromRaw : IFromRawJson<WorkspacePreferenceListResponse>
{
    /// <inheritdoc/>
    public WorkspacePreferenceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspacePreferenceListResponse.FromRawUnchecked(rawData);
}
