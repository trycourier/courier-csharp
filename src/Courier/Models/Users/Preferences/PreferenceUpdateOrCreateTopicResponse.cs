using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Users.Preferences;

[JsonConverter(typeof(ModelConverter<PreferenceUpdateOrCreateTopicResponse>))]
public sealed record class PreferenceUpdateOrCreateTopicResponse
    : ModelBase,
        IFromRaw<PreferenceUpdateOrCreateTopicResponse>
{
    public required string Message
    {
        get
        {
            if (!this._rawData.TryGetValue("message", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'message' cannot be null",
                    new ArgumentOutOfRangeException("message", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'message' cannot be null",
                    new ArgumentNullException("message")
                );
        }
        init
        {
            this._rawData["message"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
