using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<ElementalTextNodeWithType, ElementalTextNodeWithTypeFromRaw>))]
public sealed record class ElementalTextNodeWithType : ModelBase
{
    public IReadOnlyList<string>? Channels
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "channels"); }
        init { ModelBase.Set(this._rawData, "channels", value); }
    }

    public string? If
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "if"); }
        init { ModelBase.Set(this._rawData, "if", value); }
    }

    public string? Loop
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "loop"); }
        init { ModelBase.Set(this._rawData, "loop", value); }
    }

    public string? Ref
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "ref"); }
        init { ModelBase.Set(this._rawData, "ref", value); }
    }

    public ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type>
            >(this.RawData, "type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "type", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalTextNodeWithType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class ElementalTextNodeWithTypeFromRaw : IFromRaw<ElementalTextNodeWithType>
{
    /// <inheritdoc/>
    public ElementalTextNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalTextNodeWithType.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        ElementalTextNodeWithTypeIntersectionMember1,
        ElementalTextNodeWithTypeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalTextNodeWithTypeIntersectionMember1 : ModelBase
{
    public ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type>
            >(this.RawData, "type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "type", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalTextNodeWithTypeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    : IFromRaw<ElementalTextNodeWithTypeIntersectionMember1>
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
