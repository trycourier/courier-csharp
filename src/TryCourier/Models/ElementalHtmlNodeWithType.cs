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

[JsonConverter(
    typeof(JsonModelConverter<ElementalHtmlNodeWithType, ElementalHtmlNodeWithTypeFromRaw>)
)]
public sealed record class ElementalHtmlNodeWithType : JsonModel
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

    public ApiEnum<string, ElementalHtmlNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ElementalHtmlNodeWithTypeIntersectionMember1Type>
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

    public static implicit operator ElementalBaseNode(
        ElementalHtmlNodeWithType elementalHtmlNodeWithType
    ) =>
        new()
        {
            Channels = elementalHtmlNodeWithType.Channels,
            If = elementalHtmlNodeWithType.If,
            Loop = elementalHtmlNodeWithType.Loop,
            Ref = elementalHtmlNodeWithType.Ref,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        this.Type?.Validate();
    }

    public ElementalHtmlNodeWithType() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalHtmlNodeWithType(ElementalHtmlNodeWithType elementalHtmlNodeWithType)
        : base(elementalHtmlNodeWithType) { }
#pragma warning restore CS8618

    public ElementalHtmlNodeWithType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalHtmlNodeWithType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalHtmlNodeWithTypeFromRaw.FromRawUnchecked"/>
    public static ElementalHtmlNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalHtmlNodeWithTypeFromRaw : IFromRawJson<ElementalHtmlNodeWithType>
{
    /// <inheritdoc/>
    public ElementalHtmlNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalHtmlNodeWithType.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ElementalHtmlNodeWithTypeIntersectionMember1,
        ElementalHtmlNodeWithTypeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalHtmlNodeWithTypeIntersectionMember1 : JsonModel
{
    public ApiEnum<string, ElementalHtmlNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ElementalHtmlNodeWithTypeIntersectionMember1Type>
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

    public ElementalHtmlNodeWithTypeIntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalHtmlNodeWithTypeIntersectionMember1(
        ElementalHtmlNodeWithTypeIntersectionMember1 elementalHtmlNodeWithTypeIntersectionMember1
    )
        : base(elementalHtmlNodeWithTypeIntersectionMember1) { }
#pragma warning restore CS8618

    public ElementalHtmlNodeWithTypeIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalHtmlNodeWithTypeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalHtmlNodeWithTypeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static ElementalHtmlNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalHtmlNodeWithTypeIntersectionMember1FromRaw
    : IFromRawJson<ElementalHtmlNodeWithTypeIntersectionMember1>
{
    /// <inheritdoc/>
    public ElementalHtmlNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalHtmlNodeWithTypeIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ElementalHtmlNodeWithTypeIntersectionMember1TypeConverter))]
public enum ElementalHtmlNodeWithTypeIntersectionMember1Type
{
    Html,
}

sealed class ElementalHtmlNodeWithTypeIntersectionMember1TypeConverter
    : JsonConverter<ElementalHtmlNodeWithTypeIntersectionMember1Type>
{
    public override ElementalHtmlNodeWithTypeIntersectionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "html" => ElementalHtmlNodeWithTypeIntersectionMember1Type.Html,
            _ => (ElementalHtmlNodeWithTypeIntersectionMember1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ElementalHtmlNodeWithTypeIntersectionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ElementalHtmlNodeWithTypeIntersectionMember1Type.Html => "html",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
