using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Users.Preferences;

[JsonConverter(
    typeof(JsonModelConverter<
        PreferenceUpdateOrCreateTopicResponse,
        PreferenceUpdateOrCreateTopicResponseFromRaw
    >)
)]
public sealed record class PreferenceUpdateOrCreateTopicResponse : JsonModel
{
    public required string Message
    {
        get { return this._rawData.GetNotNullClass<string>("message"); }
        init { this._rawData.Set("message", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
    }

    public PreferenceUpdateOrCreateTopicResponse() { }

    public PreferenceUpdateOrCreateTopicResponse(
        PreferenceUpdateOrCreateTopicResponse preferenceUpdateOrCreateTopicResponse
    )
        : base(preferenceUpdateOrCreateTopicResponse) { }

    public PreferenceUpdateOrCreateTopicResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceUpdateOrCreateTopicResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceUpdateOrCreateTopicResponseFromRaw.FromRawUnchecked"/>
    public static PreferenceUpdateOrCreateTopicResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PreferenceUpdateOrCreateTopicResponse(string message)
        : this()
    {
        this.Message = message;
    }
}

class PreferenceUpdateOrCreateTopicResponseFromRaw
    : IFromRawJson<PreferenceUpdateOrCreateTopicResponse>
{
    /// <inheritdoc/>
    public PreferenceUpdateOrCreateTopicResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceUpdateOrCreateTopicResponse.FromRawUnchecked(rawData);
}
