using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Profiles.ProfileCreateResponseProperties;

namespace Courier.Models.Profiles;

[JsonConverter(typeof(ModelConverter<ProfileCreateResponse>))]
public sealed record class ProfileCreateResponse : ModelBase, IFromRaw<ProfileCreateResponse>
{
    public required ApiEnum<string, Status> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Status.Validate();
    }

    public ProfileCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileCreateResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ProfileCreateResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ProfileCreateResponse(ApiEnum<string, Status> status)
        : this()
    {
        this.Status = status;
    }
}
