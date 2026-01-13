using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<AirshipProfile, AirshipProfileFromRaw>))]
public sealed record class AirshipProfile : JsonModel
{
    public required AirshipProfileAudience Audience
    {
        get { return this._rawData.GetNotNullClass<AirshipProfileAudience>("audience"); }
        init { this._rawData.Set("audience", value); }
    }

    public required IReadOnlyList<string> DeviceTypes
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<string>>("device_types"); }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "device_types",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Audience.Validate();
        _ = this.DeviceTypes;
    }

    public AirshipProfile() { }

    public AirshipProfile(AirshipProfile airshipProfile)
        : base(airshipProfile) { }

    public AirshipProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AirshipProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AirshipProfileFromRaw.FromRawUnchecked"/>
    public static AirshipProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AirshipProfileFromRaw : IFromRawJson<AirshipProfile>
{
    /// <inheritdoc/>
    public AirshipProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AirshipProfile.FromRawUnchecked(rawData);
}
