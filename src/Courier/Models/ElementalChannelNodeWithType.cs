using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

/// <summary>
/// The channel element allows a notification to be customized based on which channel
/// it is sent through.  For example, you may want to display a detailed message when
/// the notification is sent through email,  and a more concise message in a push
/// notification. Channel elements are only valid as top-level  elements; you cannot
/// nest channel elements. If there is a channel element specified at the top-level
///  of the document, all sibling elements must be channel elements. Note: As an alternative,
/// most elements support a `channel` property. Which allows you to selectively  display
/// an individual element on a per channel basis. See the  [control flow docs](https://www.courier.com/docs/platform/content/elemental/control-flow/)
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
            if (!this._rawData.TryGetValue("channels", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["channels"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? If
    {
        get
        {
            if (!this._rawData.TryGetValue("if", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["if"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Loop
    {
        get
        {
            if (!this._rawData.TryGetValue("loop", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["loop"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Ref
    {
        get
        {
            if (!this._rawData.TryGetValue("ref", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["ref"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("channel", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channel' cannot be null",
                    new System::ArgumentOutOfRangeException("channel", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'channel' cannot be null",
                    new System::ArgumentNullException("channel")
                );
        }
        init
        {
            this._rawData["channel"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("raw", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["raw"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, ElementalChannelNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                ElementalChannelNodeWithTypeIntersectionMember1Type
            >?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["type"] = JsonSerializer.SerializeToElement(
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

    public ElementalChannelNodeWithType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalChannelNodeWithType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ElementalChannelNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ElementalChannelNodeWithType(string channel)
        : this()
    {
        this.Channel = channel;
    }
}

[JsonConverter(typeof(ModelConverter<ElementalChannelNodeWithTypeIntersectionMember1>))]
public sealed record class ElementalChannelNodeWithTypeIntersectionMember1
    : ModelBase,
        IFromRaw<ElementalChannelNodeWithTypeIntersectionMember1>
{
    public ApiEnum<string, ElementalChannelNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                ElementalChannelNodeWithTypeIntersectionMember1Type
            >?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Type?.Validate();
    }

    public ElementalChannelNodeWithTypeIntersectionMember1() { }

    public ElementalChannelNodeWithTypeIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalChannelNodeWithTypeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ElementalChannelNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

[JsonConverter(typeof(ElementalChannelNodeWithTypeIntersectionMember1TypeConverter))]
public enum ElementalChannelNodeWithTypeIntersectionMember1Type
{
    Channel,
}

sealed class ElementalChannelNodeWithTypeIntersectionMember1TypeConverter
    : JsonConverter<ElementalChannelNodeWithTypeIntersectionMember1Type>
{
    public override ElementalChannelNodeWithTypeIntersectionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "channel" => ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
            _ => (ElementalChannelNodeWithTypeIntersectionMember1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ElementalChannelNodeWithTypeIntersectionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ElementalChannelNodeWithTypeIntersectionMember1Type.Channel => "channel",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
