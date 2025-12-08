using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Profiles;

[JsonConverter(typeof(ModelConverter<ProfileRetrieveResponse, ProfileRetrieveResponseFromRaw>))]
public sealed record class ProfileRetrieveResponse : ModelBase
{
    public required IReadOnlyDictionary<string, JsonElement> Profile
    {
        get
        {
            return ModelBase.GetNotNullClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "profile"
            );
        }
        init { ModelBase.Set(this._rawData, "profile", value); }
    }

    public RecipientPreferences? Preferences
    {
        get
        {
            return ModelBase.GetNullableClass<RecipientPreferences>(this.RawData, "preferences");
        }
        init { ModelBase.Set(this._rawData, "preferences", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Profile;
        this.Preferences?.Validate();
    }

    public ProfileRetrieveResponse() { }

    public ProfileRetrieveResponse(ProfileRetrieveResponse profileRetrieveResponse)
        : base(profileRetrieveResponse) { }

    public ProfileRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ProfileRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProfileRetrieveResponseFromRaw : IFromRaw<ProfileRetrieveResponse>
{
    /// <inheritdoc/>
    public ProfileRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProfileRetrieveResponse.FromRawUnchecked(rawData);
}
