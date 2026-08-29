using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models;

/// <summary>
/// Used to embed an image into the notification.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ElementalImageNodeWithType, ElementalImageNodeWithTypeFromRaw>)
)]
public sealed record class ElementalImageNodeWithType : JsonModel
{
    public IReadOnlyList<string>? Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("channels");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "channels",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? If
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("if");
        }
        init { this._rawData.Set("if", value); }
    }

    public string? Loop
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("loop");
        }
        init { this._rawData.Set("loop", value); }
    }

    public string? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ref");
        }
        init { this._rawData.Set("ref", value); }
    }

    /// <summary>
    /// The source of the image.
    /// </summary>
    public required string Src
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("src");
        }
        init { this._rawData.Set("src", value); }
    }

    public ApiEnum<string, Alignment>? Align
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Alignment>>("align");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("align", value);
        }
    }

    /// <summary>
    /// Alternate text for the image.
    /// </summary>
    public string? AltText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("alt_text");
        }
        init { this._rawData.Set("alt_text", value); }
    }

    /// <summary>
    /// CSS border color applied to the image. For example, `#ccc`
    /// </summary>
    public string? BorderColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_color");
        }
        init { this._rawData.Set("border_color", value); }
    }

    /// <summary>
    /// CSS border width applied to the image. For example, `1px`
    /// </summary>
    public string? BorderSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border_size");
        }
        init { this._rawData.Set("border_size", value); }
    }

    /// <summary>
    /// A URL to link to when the image is clicked.
    /// </summary>
    public string? Href
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("href");
        }
        init { this._rawData.Set("href", value); }
    }

    /// <summary>
    /// CSS padding applied around the image. For example, `10px`
    /// </summary>
    public string? Padding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("padding");
        }
        init { this._rawData.Set("padding", value); }
    }

    /// <summary>
    /// CSS width properties to apply to the image. For example, 50px
    /// </summary>
    public string? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("width");
        }
        init { this._rawData.Set("width", value); }
    }

    public ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public static implicit operator ElementalImageNode(
        ElementalImageNodeWithType elementalImageNodeWithType
    ) =>
        new()
        {
            Channels = elementalImageNodeWithType.Channels,
            If = elementalImageNodeWithType.If,
            Loop = elementalImageNodeWithType.Loop,
            Ref = elementalImageNodeWithType.Ref,
            Src = elementalImageNodeWithType.Src,
            Align = elementalImageNodeWithType.Align,
            AltText = elementalImageNodeWithType.AltText,
            BorderColor = elementalImageNodeWithType.BorderColor,
            BorderSize = elementalImageNodeWithType.BorderSize,
            Href = elementalImageNodeWithType.Href,
            Padding = elementalImageNodeWithType.Padding,
            Width = elementalImageNodeWithType.Width,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        _ = this.Src;
        this.Align?.Validate();
        _ = this.AltText;
        _ = this.BorderColor;
        _ = this.BorderSize;
        _ = this.Href;
        _ = this.Padding;
        _ = this.Width;
        this.Type?.Validate();
    }

    public ElementalImageNodeWithType() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalImageNodeWithType(ElementalImageNodeWithType elementalImageNodeWithType)
        : base(elementalImageNodeWithType) { }
#pragma warning restore CS8618

    public ElementalImageNodeWithType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalImageNodeWithType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalImageNodeWithTypeFromRaw.FromRawUnchecked"/>
    public static ElementalImageNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ElementalImageNodeWithType(string src)
        : this()
    {
        this.Src = src;
    }
}

class ElementalImageNodeWithTypeFromRaw : IFromRawJson<ElementalImageNodeWithType>
{
    /// <inheritdoc/>
    public ElementalImageNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalImageNodeWithType.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ElementalImageNodeWithTypeIntersectionMember1,
        ElementalImageNodeWithTypeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalImageNodeWithTypeIntersectionMember1 : JsonModel
{
    public ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type?.Validate();
    }

    public ElementalImageNodeWithTypeIntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalImageNodeWithTypeIntersectionMember1(
        ElementalImageNodeWithTypeIntersectionMember1 elementalImageNodeWithTypeIntersectionMember1
    )
        : base(elementalImageNodeWithTypeIntersectionMember1) { }
#pragma warning restore CS8618

    public ElementalImageNodeWithTypeIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalImageNodeWithTypeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalImageNodeWithTypeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static ElementalImageNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalImageNodeWithTypeIntersectionMember1FromRaw
    : IFromRawJson<ElementalImageNodeWithTypeIntersectionMember1>
{
    /// <inheritdoc/>
    public ElementalImageNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalImageNodeWithTypeIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ElementalImageNodeWithTypeIntersectionMember1TypeConverter))]
public enum ElementalImageNodeWithTypeIntersectionMember1Type
{
    Image,
}

sealed class ElementalImageNodeWithTypeIntersectionMember1TypeConverter
    : JsonConverter<ElementalImageNodeWithTypeIntersectionMember1Type>
{
    public override ElementalImageNodeWithTypeIntersectionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "image" => ElementalImageNodeWithTypeIntersectionMember1Type.Image,
            _ => (ElementalImageNodeWithTypeIntersectionMember1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ElementalImageNodeWithTypeIntersectionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ElementalImageNodeWithTypeIntersectionMember1Type.Image => "image",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
