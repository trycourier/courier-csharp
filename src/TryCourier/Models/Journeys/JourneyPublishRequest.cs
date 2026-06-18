using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

/// <summary>
/// Request body for publishing a journey. Pass `version` to roll back to a prior
/// version; omit to publish the current draft.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyPublishRequest, JourneyPublishRequestFromRaw>))]
public sealed record class JourneyPublishRequest : JsonModel
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

    public JourneyPublishRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyPublishRequest(JourneyPublishRequest journeyPublishRequest)
        : base(journeyPublishRequest) { }
#pragma warning restore CS8618

    public JourneyPublishRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyPublishRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyPublishRequestFromRaw.FromRawUnchecked"/>
    public static JourneyPublishRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyPublishRequestFromRaw : IFromRawJson<JourneyPublishRequest>
{
    /// <inheritdoc/>
    public JourneyPublishRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneyPublishRequest.FromRawUnchecked(rawData);
}
