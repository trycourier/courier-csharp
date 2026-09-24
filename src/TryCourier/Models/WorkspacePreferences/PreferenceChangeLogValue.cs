using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.WorkspacePreferences;

[JsonConverter(
    typeof(JsonModelConverter<PreferenceChangeLogValue, PreferenceChangeLogValueFromRaw>)
)]
public sealed record class PreferenceChangeLogValue : JsonModel
{
    /// <summary>
    /// The channels chosen before the change.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, ChannelClassification>> CustomRouting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, ChannelClassification>>
            >("custom_routing");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, ChannelClassification>>>(
                "custom_routing",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether custom routing was in effect before the change.
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
    /// The subscription status before the change.
    /// </summary>
    public required ApiEnum<string, PreferenceStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PreferenceStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.CustomRouting)
        {
            item.Validate();
        }
        _ = this.HasCustomRouting;
        this.Status.Validate();
    }

    public PreferenceChangeLogValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceChangeLogValue(PreferenceChangeLogValue preferenceChangeLogValue)
        : base(preferenceChangeLogValue) { }
#pragma warning restore CS8618

    public PreferenceChangeLogValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceChangeLogValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceChangeLogValueFromRaw.FromRawUnchecked"/>
    public static PreferenceChangeLogValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreferenceChangeLogValueFromRaw : IFromRawJson<PreferenceChangeLogValue>
{
    /// <inheritdoc/>
    public PreferenceChangeLogValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceChangeLogValue.FromRawUnchecked(rawData);
}
