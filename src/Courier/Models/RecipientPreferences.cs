using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<RecipientPreferences>))]
public sealed record class RecipientPreferences : ModelBase, IFromRaw<RecipientPreferences>
{
    public Dictionary<string, NotificationPreferenceDetails>? Categories
    {
        get
        {
            if (!this._rawData.TryGetValue("categories", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, NotificationPreferenceDetails>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["categories"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, NotificationPreferenceDetails>? Notifications
    {
        get
        {
            if (!this._rawData.TryGetValue("notifications", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, NotificationPreferenceDetails>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["notifications"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static RecipientPreferences FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}
