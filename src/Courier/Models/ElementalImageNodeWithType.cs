using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(
    typeof(JsonModelConverter<ElementalImageNodeWithType, ElementalImageNodeWithTypeFromRaw>)
)]
public sealed record class ElementalImageNodeWithType : JsonModel
{
    public IReadOnlyList<string>? Channels
    {
        get { return this._rawData.GetNullableStruct<ImmutableArray<string>>("channels"); }
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
        get { return this._rawData.GetNullableClass<string>("if"); }
        init { this._rawData.Set("if", value); }
    }

    public string? Loop
    {
        get { return this._rawData.GetNullableClass<string>("loop"); }
        init { this._rawData.Set("loop", value); }
    }

    public string? Ref
    {
        get { return this._rawData.GetNullableClass<string>("ref"); }
        init { this._rawData.Set("ref", value); }
    }

    public ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
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

    public static implicit operator ElementalBaseNode(
        ElementalImageNodeWithType elementalImageNodeWithType
    ) =>
        new()
        {
            Channels = elementalImageNodeWithType.Channels,
            If = elementalImageNodeWithType.If,
            Loop = elementalImageNodeWithType.Loop,
            Ref = elementalImageNodeWithType.Ref,
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

    public ElementalImageNodeWithType() { }

    public ElementalImageNodeWithType(ElementalImageNodeWithType elementalImageNodeWithType)
        : base(elementalImageNodeWithType) { }

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

    public ElementalImageNodeWithTypeIntersectionMember1(
        ElementalImageNodeWithTypeIntersectionMember1 elementalImageNodeWithTypeIntersectionMember1
    )
        : base(elementalImageNodeWithTypeIntersectionMember1) { }

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
