using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.WorkspacePreferences;

/// <summary>
/// Request body for replacing a workspace preference. Full document replacement;
/// missing optional fields are cleared.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkspacePreferenceReplaceRequest,
        WorkspacePreferenceReplaceRequestFromRaw
    >)
)]
public sealed record class WorkspacePreferenceReplaceRequest : JsonModel
{
    /// <summary>
    /// Human-readable name for the workspace preference.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Whether the workspace preference defines custom routing for its topics.
    /// </summary>
    public bool? HasCustomRouting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("has_custom_routing");
        }
        init { this._rawData.Set("has_custom_routing", value); }
    }

    /// <summary>
    /// Default channels for the workspace preference. Omit to clear.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ChannelClassification>>? RoutingOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, ChannelClassification>>
            >("routing_options");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, ChannelClassification>>?>(
                "routing_options",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.HasCustomRouting;
        foreach (var item in this.RoutingOptions ?? [])
        {
            item.Validate();
        }
    }

    public WorkspacePreferenceReplaceRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspacePreferenceReplaceRequest(
        WorkspacePreferenceReplaceRequest workspacePreferenceReplaceRequest
    )
        : base(workspacePreferenceReplaceRequest) { }
#pragma warning restore CS8618

    public WorkspacePreferenceReplaceRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspacePreferenceReplaceRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspacePreferenceReplaceRequestFromRaw.FromRawUnchecked"/>
    public static WorkspacePreferenceReplaceRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WorkspacePreferenceReplaceRequest(string name)
        : this()
    {
        this.Name = name;
    }
}

class WorkspacePreferenceReplaceRequestFromRaw : IFromRawJson<WorkspacePreferenceReplaceRequest>
{
    /// <inheritdoc/>
    public WorkspacePreferenceReplaceRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspacePreferenceReplaceRequest.FromRawUnchecked(rawData);
}
