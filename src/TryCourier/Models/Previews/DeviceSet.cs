using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Previews;

/// <summary>
/// A named, reusable list of preview devices.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DeviceSet, DeviceSetFromRaw>))]
public sealed record class DeviceSet : JsonModel
{
    /// <summary>
    /// Unique identifier for the device set.
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
    /// ISO-8601 timestamp of when the set was created.
    /// </summary>
    public required string CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The devices in this set, by `PreviewDevice.id`.
    /// </summary>
    public required IReadOnlyList<string> DeviceIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("device_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "device_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
    /// ISO-8601 timestamp of when the set was last written.
    /// </summary>
    public required string UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// ISO-8601 timestamp of when the set was archived. Present only on the archive
    /// response, which is the one place the state is observable.
    /// </summary>
    public string? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("archived_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("archived_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DeviceIds;
        _ = this.Name;
        _ = this.UpdatedAt;
        _ = this.ArchivedAt;
    }

    public DeviceSet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeviceSet(DeviceSet deviceSet)
        : base(deviceSet) { }
#pragma warning restore CS8618

    public DeviceSet(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeviceSet(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeviceSetFromRaw.FromRawUnchecked"/>
    public static DeviceSet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeviceSetFromRaw : IFromRawJson<DeviceSet>
{
    /// <inheritdoc/>
    public DeviceSet FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DeviceSet.FromRawUnchecked(rawData);
}
