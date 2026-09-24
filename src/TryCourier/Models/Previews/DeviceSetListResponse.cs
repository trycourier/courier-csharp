using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Previews;

/// <summary>
/// The workspace's active device sets. Not paginated.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DeviceSetListResponse, DeviceSetListResponseFromRaw>))]
public sealed record class DeviceSetListResponse : JsonModel
{
    public required IReadOnlyList<DeviceSet> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DeviceSet>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DeviceSet>>(
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

    public DeviceSetListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeviceSetListResponse(DeviceSetListResponse deviceSetListResponse)
        : base(deviceSetListResponse) { }
#pragma warning restore CS8618

    public DeviceSetListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeviceSetListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeviceSetListResponseFromRaw.FromRawUnchecked"/>
    public static DeviceSetListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DeviceSetListResponse(IReadOnlyList<DeviceSet> results)
        : this()
    {
        this.Results = results;
    }
}

class DeviceSetListResponseFromRaw : IFromRawJson<DeviceSetListResponse>
{
    /// <inheritdoc/>
    public DeviceSetListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DeviceSetListResponse.FromRawUnchecked(rawData);
}
