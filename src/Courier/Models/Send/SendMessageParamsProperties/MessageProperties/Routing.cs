using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.RoutingProperties;

namespace Courier.Models.Send.SendMessageParamsProperties.MessageProperties;

/// <summary>
/// Customize which channels/providers Courier may deliver the message through.
/// </summary>
[JsonConverter(typeof(ModelConverter<Routing>))]
public sealed record class Routing : ModelBase, IFromRaw<Routing>
{
    /// <summary>
    /// A list of channels or providers (or nested routing rules).
    /// </summary>
    public required List<MessageRoutingChannel> Channels
    {
        get
        {
            if (!this.Properties.TryGetValue("channels", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channels' cannot be null",
                    new ArgumentOutOfRangeException("channels", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<MessageRoutingChannel>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'channels' cannot be null",
                    new ArgumentNullException("channels")
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

    public required ApiEnum<string, Method> Method
    {
        get
        {
            if (!this.Properties.TryGetValue("method", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'method' cannot be null",
                    new ArgumentOutOfRangeException("method", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Method>>(
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

    public override void Validate()
    {
        foreach (var item in this.Channels)
        {
            item.Validate();
        }
        this.Method.Validate();
    }

    public Routing() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Routing(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Routing FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
