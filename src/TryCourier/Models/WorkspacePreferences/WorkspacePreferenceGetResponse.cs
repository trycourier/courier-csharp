using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.WorkspacePreferences;

/// <summary>
/// A workspace preference in your workspace, including its topics.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        WorkspacePreferenceGetResponse,
        WorkspacePreferenceGetResponseFromRaw
    >)
)]
public sealed record class WorkspacePreferenceGetResponse : JsonModel
{
    /// <summary>
    /// The workspace preference id.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// ISO-8601 timestamp of when the workspace preference was created.
    /// </summary>
    public required string Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    /// <summary>
    /// Whether the workspace preference defines custom routing for its topics.
    /// </summary>
    public required bool HasCustomRouting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_custom_routing");
        }
        init { this._rawData.Set("has_custom_routing", value); }
    }

    /// <summary>
    /// Human-readable name.
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
    /// Default channels for the workspace preference. May be empty.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, ChannelClassification>> RoutingOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, ChannelClassification>>
            >("routing_options");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, ChannelClassification>>>(
                "routing_options",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The topics contained in this workspace preference.
    /// </summary>
    public required IReadOnlyList<WorkspacePreferenceTopicGetResponse> Topics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<WorkspacePreferenceTopicGetResponse>
            >("topics");
        }
        init
        {
            this._rawData.Set<ImmutableArray<WorkspacePreferenceTopicGetResponse>>(
                "topics",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Id of the creator.
    /// </summary>
    public string? Creator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("creator");
        }
        init { this._rawData.Set("creator", value); }
    }

    /// <summary>
    /// Optional description shown under the section on the hosted preferences page.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// ISO-8601 timestamp of the last update.
    /// </summary>
    public string? Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updated");
        }
        init { this._rawData.Set("updated", value); }
    }

    /// <summary>
    /// Id of the last updater.
    /// </summary>
    public string? Updater
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updater");
        }
        init { this._rawData.Set("updater", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Created;
        _ = this.HasCustomRouting;
        _ = this.Name;
        foreach (var item in this.RoutingOptions)
        {
            item.Validate();
        }
        foreach (var item in this.Topics)
        {
            item.Validate();
        }
        _ = this.Creator;
        _ = this.Description;
        _ = this.Updated;
        _ = this.Updater;
    }

    public WorkspacePreferenceGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspacePreferenceGetResponse(
        WorkspacePreferenceGetResponse workspacePreferenceGetResponse
    )
        : base(workspacePreferenceGetResponse) { }
#pragma warning restore CS8618

    public WorkspacePreferenceGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspacePreferenceGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspacePreferenceGetResponseFromRaw.FromRawUnchecked"/>
    public static WorkspacePreferenceGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkspacePreferenceGetResponseFromRaw : IFromRawJson<WorkspacePreferenceGetResponse>
{
    /// <inheritdoc/>
    public WorkspacePreferenceGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WorkspacePreferenceGetResponse.FromRawUnchecked(rawData);
}
