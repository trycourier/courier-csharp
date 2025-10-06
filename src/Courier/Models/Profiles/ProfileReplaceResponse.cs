using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Profiles.ProfileReplaceResponseProperties;

namespace Courier.Models.Profiles;

[JsonConverter(typeof(ModelConverter<ProfileReplaceResponse>))]
public sealed record class ProfileReplaceResponse : ModelBase, IFromRaw<ProfileReplaceResponse>
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

    public ProfileReplaceResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileReplaceResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ProfileReplaceResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ProfileReplaceResponse(ApiEnum<string, Status> status)
        : this()
    {
        this.Status = status;
    }
}
