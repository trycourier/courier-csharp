using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(
    typeof(JsonModelConverter<NotificationPreferenceDetails, NotificationPreferenceDetailsFromRaw>)
)]
public sealed record class NotificationPreferenceDetails : JsonModel
{
    public required ApiEnum<string, PreferenceStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PreferenceStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public IReadOnlyList<ChannelPreference>? ChannelPreferences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ChannelPreference>>(
                "channel_preferences"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ChannelPreference>?>(
                "channel_preferences",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<Rule>? Rules
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Rule>>("rules");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Rule>?>(
                "rules",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
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

    public NotificationPreferenceDetails(
        NotificationPreferenceDetails notificationPreferenceDetails
    )
        : base(notificationPreferenceDetails) { }

    public NotificationPreferenceDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationPreferenceDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationPreferenceDetailsFromRaw.FromRawUnchecked"/>
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

class NotificationPreferenceDetailsFromRaw : IFromRawJson<NotificationPreferenceDetails>
{
    /// <inheritdoc/>
    public NotificationPreferenceDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationPreferenceDetails.FromRawUnchecked(rawData);
}
