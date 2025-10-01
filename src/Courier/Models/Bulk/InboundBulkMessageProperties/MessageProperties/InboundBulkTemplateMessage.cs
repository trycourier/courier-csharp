using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Send;
using Courier.Models.Send.BaseMessageProperties;
using Courier.Models.Send.BaseMessageProperties.ChannelsProperties;
using Courier.Models.Send.BaseMessageProperties.ProvidersProperties;

namespace Courier.Models.Bulk.InboundBulkMessageProperties.MessageProperties;

/// <summary>
/// Describes the content of the message in a way that will  work for email, push,
/// chat, or any channel.
/// </summary>
[JsonConverter(typeof(ModelConverter<InboundBulkTemplateMessage>))]
public sealed record class InboundBulkTemplateMessage
    : ModelBase,
        IFromRaw<InboundBulkTemplateMessage>
{
    public string? BrandID
    {
        get
        {
            if (!this.Properties.TryGetValue("brand_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["brand_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// "Define run-time configuration for one or more channels. If you don't specify
    /// channels, the default configuration for each channel will be used. Valid
    /// ChannelId's are: email, sms, push, inbox, direct_message, banner, and webhook."
    /// </summary>
    public Dictionary<string, ChannelsItem>? Channels
    {
        get
        {
            if (!this.Properties.TryGetValue("channels", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, ChannelsItem>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["channels"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public MessageContext? Context
    {
        get
        {
            if (!this.Properties.TryGetValue("context", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<MessageContext?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["context"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An arbitrary object that includes any data you want to pass to the message.
    /// The data will populate the corresponding template or elements variables.
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

    /// <summary>
    /// Defines the time to wait before delivering the message. You can specify one
    /// of the following options. Duration with the number of milliseconds to delay.
    /// Until with an ISO 8601 timestamp that specifies when it should be delivered.
    /// Until with an OpenStreetMap opening_hours-like format that specifies the
    /// [Delivery Window](https://www.courier.com/docs/platform/sending/failover/#delivery-window)
    /// (e.g., 'Mo-Fr 08:00-18:00pm')
    /// </summary>
    public Delay? Delay
    {
        get
        {
            if (!this.Properties.TryGetValue("delay", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Delay?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["delay"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// "Expiry allows you to set an absolute or relative time in which a message
    /// expires.  Note: This is only valid for the Courier Inbox channel as of 12-08-2022."
    /// </summary>
    public Expiry? Expiry
    {
        get
        {
            if (!this.Properties.TryGetValue("expiry", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Expiry?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["expiry"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Metadata such as utm tracking attached with the notification through this channel.
    /// </summary>
    public Metadata? Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Metadata?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Preferences? Preferences
    {
        get
        {
            if (!this.Properties.TryGetValue("preferences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Preferences?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["preferences"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An object whose keys are valid provider identifiers which map to an object.
    /// </summary>
    public Dictionary<string, ProvidersItem>? Providers
    {
        get
        {
            if (!this.Properties.TryGetValue("providers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, ProvidersItem>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["providers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Allows you to customize which channel(s) Courier will potentially deliver
    /// the message.  If no routing key is specified, Courier will use the default
    /// routing configuration or  routing defined by the template.
    /// </summary>
    public Routing? Routing
    {
        get
        {
            if (!this.Properties.TryGetValue("routing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Routing?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["routing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Time in ms to attempt the channel before failing over to the next available channel.
    /// </summary>
    public Timeout? Timeout
    {
        get
        {
            if (!this.Properties.TryGetValue("timeout", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Timeout?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["timeout"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The id of the notification template to be rendered and sent to the recipient(s).
    ///  This field or the content field must be supplied.
    /// </summary>
    public required string Template
    {
        get
        {
            if (!this.Properties.TryGetValue("template", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'template' cannot be null",
                    new ArgumentOutOfRangeException("template", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'template' cannot be null",
                    new ArgumentNullException("template")
                );
        }
        set
        {
            this.Properties["template"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator BaseMessage(
        InboundBulkTemplateMessage inboundBulkTemplateMessage
    ) =>
        new()
        {
            BrandID = inboundBulkTemplateMessage.BrandID,
            Channels = inboundBulkTemplateMessage.Channels,
            Context = inboundBulkTemplateMessage.Context,
            Data = inboundBulkTemplateMessage.Data,
            Delay = inboundBulkTemplateMessage.Delay,
            Expiry = inboundBulkTemplateMessage.Expiry,
            Metadata = inboundBulkTemplateMessage.Metadata,
            Preferences = inboundBulkTemplateMessage.Preferences,
            Providers = inboundBulkTemplateMessage.Providers,
            Routing = inboundBulkTemplateMessage.Routing,
            Timeout = inboundBulkTemplateMessage.Timeout,
        };

    public override void Validate()
    {
        _ = this.BrandID;
        if (this.Channels != null)
        {
            foreach (var item in this.Channels.Values)
            {
                item.Validate();
            }
        }
        this.Context?.Validate();
        if (this.Data != null)
        {
            foreach (var item in this.Data.Values)
            {
                _ = item;
            }
        }
        this.Delay?.Validate();
        this.Expiry?.Validate();
        this.Metadata?.Validate();
        this.Preferences?.Validate();
        if (this.Providers != null)
        {
            foreach (var item in this.Providers.Values)
            {
                item.Validate();
            }
        }
        this.Routing?.Validate();
        this.Timeout?.Validate();
        _ = this.Template;
    }

    public InboundBulkTemplateMessage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundBulkTemplateMessage(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static InboundBulkTemplateMessage FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public InboundBulkTemplateMessage(string template)
        : this()
    {
        this.Template = template;
    }
}
