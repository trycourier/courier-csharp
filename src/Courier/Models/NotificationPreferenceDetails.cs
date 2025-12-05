using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

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
            return ModelBase.GetNotNullClass<ApiEnum<string, PreferenceStatus>>(
                this.RawData,
                "status"
            );
        }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    public IReadOnlyList<ChannelPreference>? ChannelPreferences
    {
        get
        {
            return ModelBase.GetNullableClass<List<ChannelPreference>>(
                this.RawData,
                "channel_preferences"
            );
        }
        init { ModelBase.Set(this._rawData, "channel_preferences", value); }
    }

    public IReadOnlyList<Rule>? Rules
    {
        get { return ModelBase.GetNullableClass<List<Rule>>(this.RawData, "rules"); }
        init { ModelBase.Set(this._rawData, "rules", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationPreferenceDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class NotificationPreferenceDetailsFromRaw : IFromRaw<NotificationPreferenceDetails>
{
    /// <inheritdoc/>
    public NotificationPreferenceDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationPreferenceDetails.FromRawUnchecked(rawData);
}
