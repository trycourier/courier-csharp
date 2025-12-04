using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(
    typeof(ModelConverter<ElementalImageNodeWithType, ElementalImageNodeWithTypeFromRaw>)
)]
public sealed record class ElementalImageNodeWithType : ModelBase
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

    public ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type>
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

    public ElementalImageNodeWithType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalImageNodeWithType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class ElementalImageNodeWithTypeFromRaw : IFromRaw<ElementalImageNodeWithType>
{
    /// <inheritdoc/>
    public ElementalImageNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalImageNodeWithType.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        ElementalImageNodeWithTypeIntersectionMember1,
        ElementalImageNodeWithTypeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalImageNodeWithTypeIntersectionMember1 : ModelBase
{
    public ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type>
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

    public ElementalImageNodeWithTypeIntersectionMember1() { }

    public ElementalImageNodeWithTypeIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalImageNodeWithTypeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    : IFromRaw<ElementalImageNodeWithTypeIntersectionMember1>
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
