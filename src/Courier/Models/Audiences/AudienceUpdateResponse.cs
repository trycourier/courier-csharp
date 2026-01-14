using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Audiences;

[JsonConverter(typeof(JsonModelConverter<AudienceUpdateResponse, AudienceUpdateResponseFromRaw>))]
public sealed record class AudienceUpdateResponse : JsonModel
{
    public required Audience Audience
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Audience>("audience");
        }
        init { this._rawData.Set("audience", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Audience.Validate();
    }

    public AudienceUpdateResponse() { }

    public AudienceUpdateResponse(AudienceUpdateResponse audienceUpdateResponse)
        : base(audienceUpdateResponse) { }

    public AudienceUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudienceUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudienceUpdateResponseFromRaw.FromRawUnchecked"/>
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

class AudienceUpdateResponseFromRaw : IFromRawJson<AudienceUpdateResponse>
{
    /// <inheritdoc/>
    public AudienceUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AudienceUpdateResponse.FromRawUnchecked(rawData);
}
