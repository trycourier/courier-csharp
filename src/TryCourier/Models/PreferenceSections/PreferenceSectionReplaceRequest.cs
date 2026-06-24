using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.PreferenceSections;

/// <summary>
/// Request body for replacing a preference section. Full document replacement; missing
/// optional fields are cleared.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PreferenceSectionReplaceRequest,
        PreferenceSectionReplaceRequestFromRaw
    >)
)]
public sealed record class PreferenceSectionReplaceRequest : JsonModel
{
    /// <summary>
    /// Human-readable name for the section.
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
    /// Whether the section defines custom routing for its topics.
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
    /// Default channels for the section. Omit to clear.
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

    public PreferenceSectionReplaceRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceSectionReplaceRequest(
        PreferenceSectionReplaceRequest preferenceSectionReplaceRequest
    )
        : base(preferenceSectionReplaceRequest) { }
#pragma warning restore CS8618

    public PreferenceSectionReplaceRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceSectionReplaceRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceSectionReplaceRequestFromRaw.FromRawUnchecked"/>
    public static PreferenceSectionReplaceRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PreferenceSectionReplaceRequest(string name)
        : this()
    {
        this.Name = name;
    }
}

class PreferenceSectionReplaceRequestFromRaw : IFromRawJson<PreferenceSectionReplaceRequest>
{
    /// <inheritdoc/>
    public PreferenceSectionReplaceRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceSectionReplaceRequest.FromRawUnchecked(rawData);
}
