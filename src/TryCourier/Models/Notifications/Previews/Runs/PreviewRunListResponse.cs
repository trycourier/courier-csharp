using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Notifications.Previews.Runs;

/// <summary>
/// Paginated list of preview runs, newest first.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PreviewRunListResponse, PreviewRunListResponseFromRaw>))]
public sealed record class PreviewRunListResponse : JsonModel
{
    public required Paging Paging
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Paging>("paging");
        }
        init { this._rawData.Set("paging", value); }
    }

    public required IReadOnlyList<PreviewRun> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PreviewRun>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PreviewRun>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Paging.Validate();
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public PreviewRunListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreviewRunListResponse(PreviewRunListResponse previewRunListResponse)
        : base(previewRunListResponse) { }
#pragma warning restore CS8618

    public PreviewRunListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreviewRunListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreviewRunListResponseFromRaw.FromRawUnchecked"/>
    public static PreviewRunListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreviewRunListResponseFromRaw : IFromRawJson<PreviewRunListResponse>
{
    /// <inheritdoc/>
    public PreviewRunListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreviewRunListResponse.FromRawUnchecked(rawData);
}
