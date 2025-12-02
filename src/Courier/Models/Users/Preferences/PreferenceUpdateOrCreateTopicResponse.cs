using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Users.Preferences;

[JsonConverter(
    typeof(ModelConverter<
        PreferenceUpdateOrCreateTopicResponse,
        PreferenceUpdateOrCreateTopicResponseFromRaw
    >)
)]
public sealed record class PreferenceUpdateOrCreateTopicResponse : ModelBase
{
    public required string Message
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "message"); }
        init { ModelBase.Set(this._rawData, "message", value); }
    }

    public override void Validate()
    {
        _ = this.Message;
    }

    public PreferenceUpdateOrCreateTopicResponse() { }

    public PreferenceUpdateOrCreateTopicResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceUpdateOrCreateTopicResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

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

class PreferenceUpdateOrCreateTopicResponseFromRaw : IFromRaw<PreferenceUpdateOrCreateTopicResponse>
{
    public PreferenceUpdateOrCreateTopicResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceUpdateOrCreateTopicResponse.FromRawUnchecked(rawData);
}
