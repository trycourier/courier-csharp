using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.WorkspacePreferences;

[JsonConverter(
    typeof(JsonModelConverter<PreferenceLogsListResponse, PreferenceLogsListResponseFromRaw>)
)]
public sealed record class PreferenceLogsListResponse : JsonModel
{
    /// <summary>
    /// One entry per preference change, newest first.
    /// </summary>
    public required IReadOnlyList<PreferenceChangeLogEntry> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PreferenceChangeLogEntry>>(
                "items"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<PreferenceChangeLogEntry>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Paging Paging
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Paging>("paging");
        }
        init { this._rawData.Set("paging", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        this.Paging.Validate();
    }

    public PreferenceLogsListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceLogsListResponse(PreferenceLogsListResponse preferenceLogsListResponse)
        : base(preferenceLogsListResponse) { }
#pragma warning restore CS8618

    public PreferenceLogsListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceLogsListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceLogsListResponseFromRaw.FromRawUnchecked"/>
    public static PreferenceLogsListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreferenceLogsListResponseFromRaw : IFromRawJson<PreferenceLogsListResponse>
{
    /// <inheritdoc/>
    public PreferenceLogsListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceLogsListResponse.FromRawUnchecked(rawData);
}
