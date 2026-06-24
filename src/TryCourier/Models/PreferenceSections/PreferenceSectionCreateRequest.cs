using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.PreferenceSections;

/// <summary>
/// Request body for creating a preference section.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PreferenceSectionCreateRequest,
        PreferenceSectionCreateRequestFromRaw
    >)
)]
public sealed record class PreferenceSectionCreateRequest : JsonModel
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
    /// Default channels for the section. Defaults to empty if omitted.
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

    public PreferenceSectionCreateRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceSectionCreateRequest(
        PreferenceSectionCreateRequest preferenceSectionCreateRequest
    )
        : base(preferenceSectionCreateRequest) { }
#pragma warning restore CS8618

    public PreferenceSectionCreateRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceSectionCreateRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceSectionCreateRequestFromRaw.FromRawUnchecked"/>
    public static PreferenceSectionCreateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PreferenceSectionCreateRequest(string name)
        : this()
    {
        this.Name = name;
    }
}

class PreferenceSectionCreateRequestFromRaw : IFromRawJson<PreferenceSectionCreateRequest>
{
    /// <inheritdoc/>
    public PreferenceSectionCreateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceSectionCreateRequest.FromRawUnchecked(rawData);
}
