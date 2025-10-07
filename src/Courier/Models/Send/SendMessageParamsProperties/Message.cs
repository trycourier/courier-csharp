using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ChannelsProperties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ProvidersProperties;

namespace Courier.Models.Send.SendMessageParamsProperties;

/// <summary>
/// The message property has the following primary top-level properties. They define
/// the destination and content of the message.
/// </summary>
[JsonConverter(typeof(ModelConverter<Message>))]
public sealed record class Message : ModelBase, IFromRaw<Message>
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
    /// Define run-time configuration for channels. Valid ChannelId's: email, sms,
    /// push, inbox, direct_message, banner, webhook.
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

    /// <summary>
    /// Describes content that will work for email, inbox, push, chat, or any channel id.
    /// </summary>
    public Content? Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Content?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["content"] = JsonSerializer.SerializeToElement(
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
    /// Customize which channels/providers Courier may deliver the message through.
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
    /// The recipient or a list of recipients of the message
    /// </summary>
    public To? To
    {
        get
        {
            if (!this.Properties.TryGetValue("to", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<To?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["to"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
        this.Content?.Validate();
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
        this.To?.Validate();
    }

    public Message() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Message(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Message FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
