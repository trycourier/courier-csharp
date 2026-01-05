using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<AirshipProfileAudience, AirshipProfileAudienceFromRaw>))]
public sealed record class AirshipProfileAudience : JsonModel
{
    public required string NamedUser
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "named_user"); }
        init { JsonModel.Set(this._rawData, "named_user", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NamedUser;
    }

    public AirshipProfileAudience() { }

    public AirshipProfileAudience(AirshipProfileAudience airshipProfileAudience)
        : base(airshipProfileAudience) { }

    public AirshipProfileAudience(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AirshipProfileAudience(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AirshipProfileAudienceFromRaw.FromRawUnchecked"/>
    public static AirshipProfileAudience FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AirshipProfileAudience(string namedUser)
        : this()
    {
        this.NamedUser = namedUser;
    }
}

class AirshipProfileAudienceFromRaw : IFromRawJson<AirshipProfileAudience>
{
    /// <inheritdoc/>
    public AirshipProfileAudience FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AirshipProfileAudience.FromRawUnchecked(rawData);
}
