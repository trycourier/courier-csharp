using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Notifications.NotificationContentProperties.BlockProperties.LocalesProperties.LocaleProperties;

[JsonConverter(typeof(ModelConverter<NotificationContentHierarchy>))]
public sealed record class NotificationContentHierarchy
    : ModelBase,
        IFromRaw<NotificationContentHierarchy>
{
    public string? Children
    {
        get
        {
            if (!this.Properties.TryGetValue("children", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["children"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Parent
    {
        get
        {
            if (!this.Properties.TryGetValue("parent", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["parent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Children;
        _ = this.Parent;
    }

    public NotificationContentHierarchy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationContentHierarchy(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NotificationContentHierarchy FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
