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
    typeof(JsonModelConverter<ElementalMetaNodeWithType, ElementalMetaNodeWithTypeFromRaw>)
)]
public sealed record class ElementalMetaNodeWithType : JsonModel
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

    public ApiEnum<string, ElementalMetaNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ElementalMetaNodeWithTypeIntersectionMember1Type>
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
        ElementalMetaNodeWithType elementalMetaNodeWithType
    ) =>
        new()
        {
            Channels = elementalMetaNodeWithType.Channels,
            If = elementalMetaNodeWithType.If,
            Loop = elementalMetaNodeWithType.Loop,
            Ref = elementalMetaNodeWithType.Ref,
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

    public ElementalMetaNodeWithType() { }

    public ElementalMetaNodeWithType(ElementalMetaNodeWithType elementalMetaNodeWithType)
        : base(elementalMetaNodeWithType) { }

    public ElementalMetaNodeWithType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalMetaNodeWithType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalMetaNodeWithTypeFromRaw.FromRawUnchecked"/>
    public static ElementalMetaNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalMetaNodeWithTypeFromRaw : IFromRawJson<ElementalMetaNodeWithType>
{
    /// <inheritdoc/>
    public ElementalMetaNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalMetaNodeWithType.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ElementalMetaNodeWithTypeIntersectionMember1,
        ElementalMetaNodeWithTypeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalMetaNodeWithTypeIntersectionMember1 : JsonModel
{
    public ApiEnum<string, ElementalMetaNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ElementalMetaNodeWithTypeIntersectionMember1Type>
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

    public ElementalMetaNodeWithTypeIntersectionMember1() { }

    public ElementalMetaNodeWithTypeIntersectionMember1(
        ElementalMetaNodeWithTypeIntersectionMember1 elementalMetaNodeWithTypeIntersectionMember1
    )
        : base(elementalMetaNodeWithTypeIntersectionMember1) { }

    public ElementalMetaNodeWithTypeIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalMetaNodeWithTypeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalMetaNodeWithTypeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static ElementalMetaNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalMetaNodeWithTypeIntersectionMember1FromRaw
    : IFromRawJson<ElementalMetaNodeWithTypeIntersectionMember1>
{
    /// <inheritdoc/>
    public ElementalMetaNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalMetaNodeWithTypeIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ElementalMetaNodeWithTypeIntersectionMember1TypeConverter))]
public enum ElementalMetaNodeWithTypeIntersectionMember1Type
{
    Meta,
}

sealed class ElementalMetaNodeWithTypeIntersectionMember1TypeConverter
    : JsonConverter<ElementalMetaNodeWithTypeIntersectionMember1Type>
{
    public override ElementalMetaNodeWithTypeIntersectionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "meta" => ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
            _ => (ElementalMetaNodeWithTypeIntersectionMember1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ElementalMetaNodeWithTypeIntersectionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ElementalMetaNodeWithTypeIntersectionMember1Type.Meta => "meta",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
