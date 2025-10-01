using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Send.BaseMessageProperties.RoutingProperties.ChannelProperties.RoutingStrategyChannelProperties.ProvidersProperties;

namespace Courier.Models.Send.BaseMessageProperties.RoutingProperties.ChannelProperties;

[JsonConverter(typeof(ModelConverter<RoutingStrategyChannel>))]
public sealed record class RoutingStrategyChannel : ModelBase, IFromRaw<RoutingStrategyChannel>
{
    public required string Channel
    {
        get
        {
            if (!this.Properties.TryGetValue("channel", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channel' cannot be null",
                    new ArgumentOutOfRangeException("channel", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'channel' cannot be null",
                    new ArgumentNullException("channel")
                );
        }
        set
        {
            this.Properties["channel"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Config
    {
        get
        {
            if (!this.Properties.TryGetValue("config", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["config"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public ApiEnum<string, RoutingMethod>? Method
    {
        get
        {
            if (!this.Properties.TryGetValue("method", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, RoutingMethod>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["method"] = JsonSerializer.SerializeToElement(
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

    public override void Validate()
    {
        _ = this.Channel;
        if (this.Config != null)
        {
            foreach (var item in this.Config.Values)
            {
                _ = item;
            }
        }
        _ = this.If;
        this.Method?.Validate();
        if (this.Providers != null)
        {
            foreach (var item in this.Providers.Values)
            {
                item.Validate();
            }
        }
    }

    public RoutingStrategyChannel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RoutingStrategyChannel(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RoutingStrategyChannel FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public RoutingStrategyChannel(string channel)
        : this()
    {
        this.Channel = channel;
    }
}
