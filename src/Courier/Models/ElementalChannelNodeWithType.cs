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
[JsonConverter(
    typeof(JsonModelConverter<ElementalChannelNodeWithType, ElementalChannelNodeWithTypeFromRaw>)
)]
public sealed record class ElementalChannelNodeWithType : JsonModel
{
    public IReadOnlyList<string>? Channels
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawData, "channels"); }
        init { JsonModel.Set(this._rawData, "channels", value); }
    }

    public string? If
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "if"); }
        init { JsonModel.Set(this._rawData, "if", value); }
    }

    public string? Loop
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "loop"); }
        init { JsonModel.Set(this._rawData, "loop", value); }
    }

    public string? Ref
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "ref"); }
        init { JsonModel.Set(this._rawData, "ref", value); }
    }

    /// <summary>
    /// The channel the contents of this element should be applied to. Can be `email`,
    /// `push`, `direct_message`, `sms` or a provider such as slack
    /// </summary>
    public required string Channel
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "channel"); }
        init { JsonModel.Set(this._rawData, "channel", value); }
    }

    /// <summary>
    /// Raw data to apply to the channel. If `elements` has not been specified, `raw`
    /// is required.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Raw
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, JsonElement>>(this.RawData, "raw");
        }
        init { JsonModel.Set(this._rawData, "raw", value); }
    }

    public ApiEnum<string, ElementalChannelNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            return JsonModel.GetNullableClass<
                ApiEnum<string, ElementalChannelNodeWithTypeIntersectionMember1Type>
            >(this.RawData, "type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "type", value);
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

    /// <inheritdoc/>
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

    public ElementalChannelNodeWithType(ElementalChannelNodeWithType elementalChannelNodeWithType)
        : base(elementalChannelNodeWithType) { }

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

    /// <inheritdoc cref="ElementalChannelNodeWithTypeFromRaw.FromRawUnchecked"/>
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

class ElementalChannelNodeWithTypeFromRaw : IFromRawJson<ElementalChannelNodeWithType>
{
    /// <inheritdoc/>
    public ElementalChannelNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalChannelNodeWithType.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ElementalChannelNodeWithTypeIntersectionMember1,
        ElementalChannelNodeWithTypeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalChannelNodeWithTypeIntersectionMember1 : JsonModel
{
    public ApiEnum<string, ElementalChannelNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            return JsonModel.GetNullableClass<
                ApiEnum<string, ElementalChannelNodeWithTypeIntersectionMember1Type>
            >(this.RawData, "type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type?.Validate();
    }

    public ElementalChannelNodeWithTypeIntersectionMember1() { }

    public ElementalChannelNodeWithTypeIntersectionMember1(
        ElementalChannelNodeWithTypeIntersectionMember1 elementalChannelNodeWithTypeIntersectionMember1
    )
        : base(elementalChannelNodeWithTypeIntersectionMember1) { }

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

    /// <inheritdoc cref="ElementalChannelNodeWithTypeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static ElementalChannelNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalChannelNodeWithTypeIntersectionMember1FromRaw
    : IFromRawJson<ElementalChannelNodeWithTypeIntersectionMember1>
{
    /// <inheritdoc/>
    public ElementalChannelNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalChannelNodeWithTypeIntersectionMember1.FromRawUnchecked(rawData);
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
