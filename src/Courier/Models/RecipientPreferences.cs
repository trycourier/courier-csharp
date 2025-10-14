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
            if (!this.Properties.TryGetValue("categories", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, NotificationPreferenceDetails>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["categories"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, NotificationPreferenceDetails>? Notifications
    {
        get
        {
            if (!this.Properties.TryGetValue("notifications", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, NotificationPreferenceDetails>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["notifications"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecipientPreferences(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RecipientPreferences FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
