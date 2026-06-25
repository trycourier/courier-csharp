using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.WorkspacePreferences;

/// <summary>
/// Request body for creating a workspace preference.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkspacePreferenceCreateRequest,
        WorkspacePreferenceCreateRequestFromRaw
    >)
)]
public sealed record class WorkspacePreferenceCreateRequest : JsonModel
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
    /// Default channels for the workspace preference. Defaults to empty if omitted.
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

    public WorkspacePreferenceCreateRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspacePreferenceCreateRequest(
        WorkspacePreferenceCreateRequest workspacePreferenceCreateRequest
    )
        : base(workspacePreferenceCreateRequest) { }
#pragma warning restore CS8618

    public WorkspacePreferenceCreateRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspacePreferenceCreateRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspacePreferenceCreateRequestFromRaw.FromRawUnchecked"/>
    public static WorkspacePreferenceCreateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WorkspacePreferenceCreateRequest(string name)
        : this()
    {
        this.Name = name;
    }
}

class WorkspacePreferenceCreateRequestFromRaw : IFromRawJson<WorkspacePreferenceCreateRequest>
{
    /// <inheritdoc/>
    public WorkspacePreferenceCreateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspacePreferenceCreateRequest.FromRawUnchecked(rawData);
}
