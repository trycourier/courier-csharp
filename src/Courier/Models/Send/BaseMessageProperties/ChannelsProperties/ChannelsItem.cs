using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using ChannelsItemProperties = Courier.Models.Send.BaseMessageProperties.ChannelsProperties.ChannelsItemProperties;

namespace Courier.Models.Send.BaseMessageProperties.ChannelsProperties;

[JsonConverter(typeof(ModelConverter<ChannelsItem>))]
public sealed record class ChannelsItem : ModelBase, IFromRaw<ChannelsItem>
{
    /// <summary>
    /// Id of the brand that should be used for rendering the message.  If not specified,
    /// the brand configured as default brand will be used.
    /// </summary>
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
    /// A JavaScript conditional expression to determine if the message should  be
    /// sent through the channel. Has access to the data and profile object.  For
    /// example, `data.name === profile.name`
    /// </summary>
    public string? If
    {
        get
        {
            if (!this.Properties.TryGetValue("if", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["if"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ChannelsItemProperties::Metadata? Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ChannelsItemProperties::Metadata?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Channel specific overrides.
    /// </summary>
    public Dictionary<string, JsonElement>? Override
    {
        get
        {
            if (!this.Properties.TryGetValue("override", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["override"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A list of providers enabled for this channel. Courier will select  one provider
    /// to send through unless routing_method is set to all.
    /// </summary>
    public List<string>? Providers
    {
        get
        {
            if (!this.Properties.TryGetValue("providers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
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
    /// The method for selecting the providers to send the message with.  Single will
    /// send to one of the available providers for this channel,  all will send the
    /// message through all channels. Defaults to `single`.
    /// </summary>
    public ApiEnum<string, RoutingMethod>? RoutingMethod
    {
        get
        {
            if (!this.Properties.TryGetValue("routing_method", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, RoutingMethod>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["routing_method"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ChannelsItemProperties::Timeouts? Timeouts
    {
        get
        {
            if (!this.Properties.TryGetValue("timeouts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ChannelsItemProperties::Timeouts?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["timeouts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.If;
        this.Metadata?.Validate();
        if (this.Override != null)
        {
            foreach (var item in this.Override.Values)
            {
                _ = item;
            }
        }
        foreach (var item in this.Providers ?? [])
        {
            _ = item;
        }
        this.RoutingMethod?.Validate();
        this.Timeouts?.Validate();
    }

    public ChannelsItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChannelsItem(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ChannelsItem FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
