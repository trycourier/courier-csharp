using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using RoutingStrategyProviderProperties = Courier.Models.Send.BaseMessageProperties.RoutingProperties.ChannelProperties.RoutingStrategyProviderProperties;

namespace Courier.Models.Send.BaseMessageProperties.RoutingProperties.ChannelProperties;

[JsonConverter(typeof(ModelConverter<RoutingStrategyProvider>))]
public sealed record class RoutingStrategyProvider : ModelBase, IFromRaw<RoutingStrategyProvider>
{
    public required RoutingStrategyProviderProperties::Metadata Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentOutOfRangeException("metadata", "Missing required argument")
                );

            return JsonSerializer.Deserialize<RoutingStrategyProviderProperties::Metadata>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'metadata' cannot be null",
                    new ArgumentNullException("metadata")
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

    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentNullException("name")
                );
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
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

    public override void Validate()
    {
        this.Metadata.Validate();
        _ = this.Name;
        if (this.Config != null)
        {
            foreach (var item in this.Config.Values)
            {
                _ = item;
            }
        }
        _ = this.If;
    }

    public RoutingStrategyProvider() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RoutingStrategyProvider(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RoutingStrategyProvider FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
