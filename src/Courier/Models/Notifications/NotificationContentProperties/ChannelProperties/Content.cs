using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Notifications.NotificationContentProperties.ChannelProperties;

[JsonConverter(typeof(ModelConverter<Content>))]
public sealed record class Content : ModelBase, IFromRaw<Content>
{
    public string? Subject
    {
        get
        {
            if (!this.Properties.TryGetValue("subject", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["subject"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Title
    {
        get
        {
            if (!this.Properties.TryGetValue("title", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["title"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Subject;
        _ = this.Title;
    }

    public Content() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Content(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Content FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
