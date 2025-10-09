using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Models.NotificationGetContentProperties;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<NotificationGetContent>))]
public sealed record class NotificationGetContent : ModelBase, IFromRaw<NotificationGetContent>
{
    public List<Block>? Blocks
    {
        get
        {
            if (!this.Properties.TryGetValue("blocks", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Block>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["blocks"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<Channel>? Channels
    {
        get
        {
            if (!this.Properties.TryGetValue("channels", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Channel>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["channels"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Checksum
    {
        get
        {
            if (!this.Properties.TryGetValue("checksum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["checksum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Blocks ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Channels ?? [])
        {
            item.Validate();
        }
        _ = this.Checksum;
    }

    public NotificationGetContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationGetContent(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static NotificationGetContent FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
