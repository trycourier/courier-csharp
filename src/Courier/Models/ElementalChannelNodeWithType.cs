using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using IntersectionMember1Properties = Courier.Models.ElementalChannelNodeWithTypeProperties.IntersectionMember1Properties;

namespace Courier.Models;

/// <summary>
/// The channel element allows a notification to be customized based on which channel
/// it is sent through.  For example, you may want to display a detailed message
/// when the notification is sent through email,  and a more concise message in a
/// push notification. Channel elements are only valid as top-level  elements; you
/// cannot nest channel elements. If there is a channel element specified at the
/// top-level  of the document, all sibling elements must be channel elements. Note:
/// As an alternative, most elements support a `channel` property. Which allows you
/// to selectively  display an individual element on a per channel basis. See the
///  [control flow docs](https://www.courier.com/docs/platform/content/elemental/control-flow/)
/// for more details.
/// </summary>
[JsonConverter(typeof(ModelConverter<ElementalChannelNodeWithType>))]
public sealed record class ElementalChannelNodeWithType
    : ModelBase,
        IFromRaw<ElementalChannelNodeWithType>
{
    public List<string>? Channels
    {
        get
        {
            if (!this.Properties.TryGetValue("channels", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["channels"] = JsonSerializer.SerializeToElement(
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

    public string? Loop
    {
        get
        {
            if (!this.Properties.TryGetValue("loop", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["loop"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Ref
    {
        get
        {
            if (!this.Properties.TryGetValue("ref", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ref"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The channel the contents of this element should be applied to. Can be `email`,
    /// `push`, `direct_message`, `sms` or a provider such as slack
    /// </summary>
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

    /// <summary>
    /// Raw data to apply to the channel. If `elements` has not been specified, `raw`
    /// is required.
    /// </summary>
    public Dictionary<string, JsonElement>? Raw
    {
        get
        {
            if (!this.Properties.TryGetValue("raw", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["raw"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, IntersectionMember1Properties::Type>? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                IntersectionMember1Properties::Type
            >?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator ElementalChannelNode(
        ElementalChannelNodeWithType elementalChannelNodeWithType
    ) =>
        new()
        {
            Channels = elementalChannelNodeWithType.Channels,
            If = elementalChannelNodeWithType.If,
            Loop = elementalChannelNodeWithType.Loop,
            Ref = elementalChannelNodeWithType.Ref,
            Channel = elementalChannelNodeWithType.Channel,
            Raw = elementalChannelNodeWithType.Raw,
        };

    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        _ = this.Channel;
        _ = this.Raw;
        this.Type?.Validate();
    }

    public ElementalChannelNodeWithType() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalChannelNodeWithType(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ElementalChannelNodeWithType FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public ElementalChannelNodeWithType(string channel)
        : this()
    {
        this.Channel = channel;
    }
}
