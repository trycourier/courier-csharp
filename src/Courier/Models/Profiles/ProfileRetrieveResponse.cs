using System;
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
            if (!this.Properties.TryGetValue("profile", out JsonElement element))
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
        set
        {
            this.Properties["profile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public RecipientPreferences? Preferences
    {
        get
        {
            if (!this.Properties.TryGetValue("preferences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<RecipientPreferences?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["preferences"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRetrieveResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ProfileRetrieveResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
