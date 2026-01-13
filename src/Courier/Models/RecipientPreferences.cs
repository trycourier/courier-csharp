using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<RecipientPreferences, RecipientPreferencesFromRaw>))]
public sealed record class RecipientPreferences : JsonModel
{
    public IReadOnlyDictionary<string, NotificationPreferenceDetails>? Categories
    {
        get
        {
            return this._rawData.GetNullableClass<
                FrozenDictionary<string, NotificationPreferenceDetails>
            >("categories");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, NotificationPreferenceDetails>?>(
                "categories",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyDictionary<string, NotificationPreferenceDetails>? Notifications
    {
        get
        {
            return this._rawData.GetNullableClass<
                FrozenDictionary<string, NotificationPreferenceDetails>
            >("notifications");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, NotificationPreferenceDetails>?>(
                "notifications",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (this.Categories != null)
        {
            foreach (var item in this.Categories.Values)
            {
                item.Validate();
            }
        }
        if (this.Notifications != null)
        {
            foreach (var item in this.Notifications.Values)
            {
                item.Validate();
            }
        }
    }

    public RecipientPreferences() { }

    public RecipientPreferences(RecipientPreferences recipientPreferences)
        : base(recipientPreferences) { }

    public RecipientPreferences(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecipientPreferences(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecipientPreferencesFromRaw.FromRawUnchecked"/>
    public static RecipientPreferences FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecipientPreferencesFromRaw : IFromRawJson<RecipientPreferences>
{
    /// <inheritdoc/>
    public RecipientPreferences FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RecipientPreferences.FromRawUnchecked(rawData);
}
