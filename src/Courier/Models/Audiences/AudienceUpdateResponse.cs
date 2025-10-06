using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Audiences;

[JsonConverter(typeof(ModelConverter<AudienceUpdateResponse>))]
public sealed record class AudienceUpdateResponse : ModelBase, IFromRaw<AudienceUpdateResponse>
{
    public required Audience Audience
    {
        get
        {
            if (!this.Properties.TryGetValue("audience", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'audience' cannot be null",
                    new ArgumentOutOfRangeException("audience", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Audience>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'audience' cannot be null",
                    new ArgumentNullException("audience")
                );
        }
        set
        {
            this.Properties["audience"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Audience.Validate();
    }

    public AudienceUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudienceUpdateResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AudienceUpdateResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public AudienceUpdateResponse(Audience audience)
        : this()
    {
        this.Audience = audience;
    }
}
