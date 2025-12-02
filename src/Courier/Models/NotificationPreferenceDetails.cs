using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models;

[JsonConverter(
    typeof(ModelConverter<NotificationPreferenceDetails, NotificationPreferenceDetailsFromRaw>)
)]
public sealed record class NotificationPreferenceDetails : ModelBase
{
    public required ApiEnum<string, PreferenceStatus> Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, PreferenceStatus>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentNullException("status")
                );
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public IReadOnlyList<ChannelPreference>? ChannelPreferences
    {
        get
        {
            if (!this._rawData.TryGetValue("channel_preferences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ChannelPreference>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["channel_preferences"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public IReadOnlyList<Rule>? Rules
    {
        get
        {
            if (!this._rawData.TryGetValue("rules", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Rule>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["rules"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Status.Validate();
        foreach (var item in this.ChannelPreferences ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Rules ?? [])
        {
            item.Validate();
        }
    }

    public NotificationPreferenceDetails() { }

    public NotificationPreferenceDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationPreferenceDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static NotificationPreferenceDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotificationPreferenceDetails(ApiEnum<string, PreferenceStatus> status)
        : this()
    {
        this.Status = status;
    }
}

class NotificationPreferenceDetailsFromRaw : IFromRaw<NotificationPreferenceDetails>
{
    public NotificationPreferenceDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationPreferenceDetails.FromRawUnchecked(rawData);
}
