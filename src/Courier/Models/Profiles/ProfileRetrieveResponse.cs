using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Profiles;

[JsonConverter(typeof(ModelConverter<ProfileRetrieveResponse>))]
public sealed record class ProfileRetrieveResponse : ModelBase, IFromRaw<ProfileRetrieveResponse>
{
    public required Dictionary<string, JsonElement> Profile
    {
        get
        {
            if (!this._rawData.TryGetValue("profile", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'profile' cannot be null",
                    new ArgumentOutOfRangeException("profile", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'profile' cannot be null",
                    new ArgumentNullException("profile")
                );
        }
        init
        {
            this._rawData["profile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public RecipientPreferences? Preferences
    {
        get
        {
            if (!this._rawData.TryGetValue("preferences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<RecipientPreferences?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["preferences"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Profile;
        this.Preferences?.Validate();
    }

    public ProfileRetrieveResponse() { }

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

    public static ProfileRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}
