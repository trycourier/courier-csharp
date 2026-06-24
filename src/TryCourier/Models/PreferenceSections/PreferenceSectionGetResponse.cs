using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.PreferenceSections;

/// <summary>
/// A preference section in your workspace, including its topics.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PreferenceSectionGetResponse, PreferenceSectionGetResponseFromRaw>)
)]
public sealed record class PreferenceSectionGetResponse : JsonModel
{
    /// <summary>
    /// The preference section id.
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
    /// ISO-8601 timestamp of when the section was created.
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
    /// Whether the section defines custom routing for its topics.
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
    /// Default channels for the section. May be empty.
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
    /// The topics contained in this section.
    /// </summary>
    public required IReadOnlyList<PreferenceTopicGetResponse> Topics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PreferenceTopicGetResponse>>(
                "topics"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PreferenceTopicGetResponse>>(
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
        _ = this.Updated;
        _ = this.Updater;
    }

    public PreferenceSectionGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceSectionGetResponse(PreferenceSectionGetResponse preferenceSectionGetResponse)
        : base(preferenceSectionGetResponse) { }
#pragma warning restore CS8618

    public PreferenceSectionGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceSectionGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceSectionGetResponseFromRaw.FromRawUnchecked"/>
    public static PreferenceSectionGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreferenceSectionGetResponseFromRaw : IFromRawJson<PreferenceSectionGetResponse>
{
    /// <inheritdoc/>
    public PreferenceSectionGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceSectionGetResponse.FromRawUnchecked(rawData);
}
