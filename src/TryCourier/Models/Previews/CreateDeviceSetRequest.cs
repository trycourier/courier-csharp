using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Previews;

/// <summary>
/// Request body for creating or replacing a device set. A full replace, not a patch
/// — both fields are always written.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreateDeviceSetRequest, CreateDeviceSetRequestFromRaw>))]
public sealed record class CreateDeviceSetRequest : JsonModel
{
    /// <summary>
    /// The devices the set contains, by `PreviewDevice.id`. At least one is required.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DeviceIds;
        _ = this.Name;
    }

    public CreateDeviceSetRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreateDeviceSetRequest(CreateDeviceSetRequest createDeviceSetRequest)
        : base(createDeviceSetRequest) { }
#pragma warning restore CS8618

    public CreateDeviceSetRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateDeviceSetRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreateDeviceSetRequestFromRaw.FromRawUnchecked"/>
    public static CreateDeviceSetRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreateDeviceSetRequestFromRaw : IFromRawJson<CreateDeviceSetRequest>
{
    /// <inheritdoc/>
    public CreateDeviceSetRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CreateDeviceSetRequest.FromRawUnchecked(rawData);
}
