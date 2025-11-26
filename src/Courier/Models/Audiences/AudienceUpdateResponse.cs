using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Audiences;

[JsonConverter(typeof(ModelConverter<AudienceUpdateResponse, AudienceUpdateResponseFromRaw>))]
public sealed record class AudienceUpdateResponse : ModelBase
{
    public required Audience Audience
    {
        get
        {
            if (!this._rawData.TryGetValue("audience", out JsonElement element))
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
            this._rawData["audience"] = JsonSerializer.SerializeToElement(
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

    public AudienceUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudienceUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AudienceUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AudienceUpdateResponse(Audience audience)
        : this()
    {
        this.Audience = audience;
    }
}

class AudienceUpdateResponseFromRaw : IFromRaw<AudienceUpdateResponse>
{
    public AudienceUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AudienceUpdateResponse.FromRawUnchecked(rawData);
}
