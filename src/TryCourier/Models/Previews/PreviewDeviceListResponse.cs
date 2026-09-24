using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Previews;

/// <summary>
/// The full catalog of renderable devices. Not paginated.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PreviewDeviceListResponse, PreviewDeviceListResponseFromRaw>)
)]
public sealed record class PreviewDeviceListResponse : JsonModel
{
    public required IReadOnlyList<PreviewDevice> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<PreviewDevice>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<PreviewDevice>>(
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

    public PreviewDeviceListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreviewDeviceListResponse(PreviewDeviceListResponse previewDeviceListResponse)
        : base(previewDeviceListResponse) { }
#pragma warning restore CS8618

    public PreviewDeviceListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreviewDeviceListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreviewDeviceListResponseFromRaw.FromRawUnchecked"/>
    public static PreviewDeviceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PreviewDeviceListResponse(IReadOnlyList<PreviewDevice> results)
        : this()
    {
        this.Results = results;
    }
}

class PreviewDeviceListResponseFromRaw : IFromRawJson<PreviewDeviceListResponse>
{
    /// <inheritdoc/>
    public PreviewDeviceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreviewDeviceListResponse.FromRawUnchecked(rawData);
}
