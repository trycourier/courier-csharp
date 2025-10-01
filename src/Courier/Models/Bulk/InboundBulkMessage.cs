using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Models.Bulk.InboundBulkMessageProperties;

namespace Courier.Models.Bulk;

[JsonConverter(typeof(ModelConverter<InboundBulkMessage>))]
public sealed record class InboundBulkMessage : ModelBase, IFromRaw<InboundBulkMessage>
{
    /// <summary>
    /// A unique identifier that represents the brand that should be used  for rendering
    /// the notification.
    /// </summary>
    public string? Brand
    {
        get
        {
            if (!this.Properties.TryGetValue("brand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["brand"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// JSON that includes any data you want to pass to a message template.  The data
    /// will populate the corresponding template variables.
    /// </summary>
    public Dictionary<string, JsonElement>? Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Event
    {
        get
        {
            if (!this.Properties.TryGetValue("event", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["event"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Locale
    {
        get
        {
            if (!this.Properties.TryGetValue("locale", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["locale"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Describes the content of the message in a way that will  work for email, push,
    /// chat, or any channel.
    /// </summary>
    public Message? Message
    {
        get
        {
            if (!this.Properties.TryGetValue("message", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Message?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["message"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// JSON that is merged into the request sent by Courier to the provider  to override
    /// properties or to gain access to features in the provider  API that are not
    /// natively supported by Courier.
    /// </summary>
    public JsonElement? Override
    {
        get
        {
            if (!this.Properties.TryGetValue("override", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["override"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Brand;
        if (this.Data != null)
        {
            foreach (var item in this.Data.Values)
            {
                _ = item;
            }
        }
        _ = this.Event;
        if (this.Locale != null)
        {
            foreach (var item in this.Locale.Values)
            {
                _ = item;
            }
        }
        this.Message?.Validate();
        _ = this.Override;
    }

    public InboundBulkMessage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundBulkMessage(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static InboundBulkMessage FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
