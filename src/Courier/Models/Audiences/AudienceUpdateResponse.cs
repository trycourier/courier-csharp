using System;
using System.Collections.Frozen;
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
            if (!this._properties.TryGetValue("audience", out JsonElement element))
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
        init
        {
            this._properties["audience"] = JsonSerializer.SerializeToElement(
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

    public AudienceUpdateResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudienceUpdateResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static AudienceUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public AudienceUpdateResponse(Audience audience)
        : this()
    {
        this.Audience = audience;
    }
}
