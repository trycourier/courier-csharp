using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<RecipientPreferences, RecipientPreferencesFromRaw>))]
public sealed record class RecipientPreferences : ModelBase
{
    public IReadOnlyDictionary<string, NotificationPreferenceDetails>? Categories
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, NotificationPreferenceDetails>>(
                this.RawData,
                "categories"
            );
        }
        init { ModelBase.Set(this._rawData, "categories", value); }
    }

    public IReadOnlyDictionary<string, NotificationPreferenceDetails>? Notifications
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, NotificationPreferenceDetails>>(
                this.RawData,
                "notifications"
            );
        }
        init { ModelBase.Set(this._rawData, "notifications", value); }
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

    public RecipientPreferences(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecipientPreferences(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class RecipientPreferencesFromRaw : IFromRaw<RecipientPreferences>
{
    /// <inheritdoc/>
    public RecipientPreferences FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RecipientPreferences.FromRawUnchecked(rawData);
}
