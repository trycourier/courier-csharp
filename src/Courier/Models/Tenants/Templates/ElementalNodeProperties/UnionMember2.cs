using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using IntersectionMember1Properties = Courier.Models.Tenants.Templates.ElementalNodeProperties.UnionMember2Properties.IntersectionMember1Properties;

namespace Courier.Models.Tenants.Templates.ElementalNodeProperties;

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
[JsonConverter(typeof(ModelConverter<UnionMember2>))]
public sealed record class UnionMember2 : ModelBase, IFromRaw<UnionMember2>
{
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

    /// <summary>
    /// An array of elements to apply to the channel. If `raw` has not been  specified,
    /// `elements` is `required`.
    /// </summary>
    public List<ElementalNode>? Elements
    {
        get
        {
            if (!this.Properties.TryGetValue("elements", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ElementalNode>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["elements"] = JsonSerializer.SerializeToElement(
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

    /// <summary>
    /// Raw data to apply to the channel. If `elements` has not been specified, `raw`
    /// is `required`.
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

    public static implicit operator ElementalChannelNode(UnionMember2 unionMember2) =>
        new()
        {
            Channel = unionMember2.Channel,
            Channels = unionMember2.Channels,
            Elements = unionMember2.Elements,
            If = unionMember2.If,
            Loop = unionMember2.Loop,
            Raw = unionMember2.Raw,
            Ref = unionMember2.Ref,
        };

    public override void Validate()
    {
        _ = this.Channel;
        foreach (var item in this.Channels ?? [])
        {
            _ = item;
        }
        foreach (var item in this.Elements ?? [])
        {
            item.Validate();
        }
        _ = this.If;
        _ = this.Loop;
        if (this.Raw != null)
        {
            foreach (var item in this.Raw.Values)
            {
                _ = item;
            }
        }
        _ = this.Ref;
        this.Type?.Validate();
    }

    public UnionMember2() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember2(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UnionMember2 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public UnionMember2(string channel)
        : this()
    {
        this.Channel = channel;
    }
}
