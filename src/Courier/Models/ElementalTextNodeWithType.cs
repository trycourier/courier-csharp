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
    typeof(JsonModelConverter<ElementalTextNodeWithType, ElementalTextNodeWithTypeFromRaw>)
)]
public sealed record class ElementalTextNodeWithType : JsonModel
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

    public ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type>
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
        ElementalTextNodeWithType elementalTextNodeWithType
    ) =>
        new()
        {
            Channels = elementalTextNodeWithType.Channels,
            If = elementalTextNodeWithType.If,
            Loop = elementalTextNodeWithType.Loop,
            Ref = elementalTextNodeWithType.Ref,
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

    public ElementalTextNodeWithType() { }

    public ElementalTextNodeWithType(ElementalTextNodeWithType elementalTextNodeWithType)
        : base(elementalTextNodeWithType) { }

    public ElementalTextNodeWithType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalTextNodeWithType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalTextNodeWithTypeFromRaw.FromRawUnchecked"/>
    public static ElementalTextNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalTextNodeWithTypeFromRaw : IFromRawJson<ElementalTextNodeWithType>
{
    /// <inheritdoc/>
    public ElementalTextNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalTextNodeWithType.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ElementalTextNodeWithTypeIntersectionMember1,
        ElementalTextNodeWithTypeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalTextNodeWithTypeIntersectionMember1 : JsonModel
{
    public ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type>
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

    public ElementalTextNodeWithTypeIntersectionMember1() { }

    public ElementalTextNodeWithTypeIntersectionMember1(
        ElementalTextNodeWithTypeIntersectionMember1 elementalTextNodeWithTypeIntersectionMember1
    )
        : base(elementalTextNodeWithTypeIntersectionMember1) { }

    public ElementalTextNodeWithTypeIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalTextNodeWithTypeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalTextNodeWithTypeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static ElementalTextNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalTextNodeWithTypeIntersectionMember1FromRaw
    : IFromRawJson<ElementalTextNodeWithTypeIntersectionMember1>
{
    /// <inheritdoc/>
    public ElementalTextNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalTextNodeWithTypeIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ElementalTextNodeWithTypeIntersectionMember1TypeConverter))]
public enum ElementalTextNodeWithTypeIntersectionMember1Type
{
    Text,
}

sealed class ElementalTextNodeWithTypeIntersectionMember1TypeConverter
    : JsonConverter<ElementalTextNodeWithTypeIntersectionMember1Type>
{
    public override ElementalTextNodeWithTypeIntersectionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => ElementalTextNodeWithTypeIntersectionMember1Type.Text,
            _ => (ElementalTextNodeWithTypeIntersectionMember1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ElementalTextNodeWithTypeIntersectionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ElementalTextNodeWithTypeIntersectionMember1Type.Text => "text",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
