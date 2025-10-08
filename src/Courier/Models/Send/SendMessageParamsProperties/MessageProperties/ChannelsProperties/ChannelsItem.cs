using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using ChannelsItemProperties = Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ChannelsProperties.ChannelsItemProperties;
using Generic = System.Collections.Generic;

namespace Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ChannelsProperties;

[JsonConverter(typeof(ModelConverter<ChannelsItem>))]
public sealed record class ChannelsItem : ModelBase, IFromRaw<ChannelsItem>
{
    /// <summary>
    /// Brand id used for rendering.
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
    /// JS conditional with access to data/profile.
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
    public Generic::Dictionary<string, JsonElement>? Override
    {
        get
        {
            if (!this.Properties.TryGetValue("override", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Generic::Dictionary<string, JsonElement>?>(
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
    /// Providers enabled for this channel.
    /// </summary>
    public Generic::List<string>? Providers
    {
        get
        {
            if (!this.Properties.TryGetValue("providers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Generic::List<string>?>(
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
    /// Defaults to `single`.
    /// </summary>
    public ApiEnum<string, ChannelsItemProperties::RoutingMethod>? RoutingMethod
    {
        get
        {
            if (!this.Properties.TryGetValue("routing_method", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                ChannelsItemProperties::RoutingMethod
            >?>(element, ModelBase.SerializerOptions);
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
    ChannelsItem(Generic::Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ChannelsItem FromRawUnchecked(Generic::Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
