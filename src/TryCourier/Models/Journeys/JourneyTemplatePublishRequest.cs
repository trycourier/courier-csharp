using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

/// <summary>
/// Request body for publishing a journey-scoped notification template. Pass `version`
/// to roll back to a prior version; omit to publish the current draft.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<JourneyTemplatePublishRequest, JourneyTemplatePublishRequestFromRaw>)
)]
public sealed record class JourneyTemplatePublishRequest : JsonModel
{
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Version;
    }

    public JourneyTemplatePublishRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyTemplatePublishRequest(
        JourneyTemplatePublishRequest journeyTemplatePublishRequest
    )
        : base(journeyTemplatePublishRequest) { }
#pragma warning restore CS8618

    public JourneyTemplatePublishRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyTemplatePublishRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyTemplatePublishRequestFromRaw.FromRawUnchecked"/>
    public static JourneyTemplatePublishRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyTemplatePublishRequestFromRaw : IFromRawJson<JourneyTemplatePublishRequest>
{
    /// <inheritdoc/>
    public JourneyTemplatePublishRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyTemplatePublishRequest.FromRawUnchecked(rawData);
}
