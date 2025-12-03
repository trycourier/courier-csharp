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
    typeof(ModelConverter<ElementalQuoteNodeWithType, ElementalQuoteNodeWithTypeFromRaw>)
)]
public sealed record class ElementalQuoteNodeWithType : ModelBase
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

    public ApiEnum<string, ElementalQuoteNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, ElementalQuoteNodeWithTypeIntersectionMember1Type>
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
        ElementalQuoteNodeWithType elementalQuoteNodeWithType
    ) =>
        new()
        {
            Channels = elementalQuoteNodeWithType.Channels,
            If = elementalQuoteNodeWithType.If,
            Loop = elementalQuoteNodeWithType.Loop,
            Ref = elementalQuoteNodeWithType.Ref,
        };

    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        this.Type?.Validate();
    }

    public ElementalQuoteNodeWithType() { }

    public ElementalQuoteNodeWithType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalQuoteNodeWithType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ElementalQuoteNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalQuoteNodeWithTypeFromRaw : IFromRaw<ElementalQuoteNodeWithType>
{
    public ElementalQuoteNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalQuoteNodeWithType.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        ElementalQuoteNodeWithTypeIntersectionMember1,
        ElementalQuoteNodeWithTypeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalQuoteNodeWithTypeIntersectionMember1 : ModelBase
{
    public ApiEnum<string, ElementalQuoteNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, ElementalQuoteNodeWithTypeIntersectionMember1Type>
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

    public override void Validate()
    {
        this.Type?.Validate();
    }

    public ElementalQuoteNodeWithTypeIntersectionMember1() { }

    public ElementalQuoteNodeWithTypeIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalQuoteNodeWithTypeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ElementalQuoteNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalQuoteNodeWithTypeIntersectionMember1FromRaw
    : IFromRaw<ElementalQuoteNodeWithTypeIntersectionMember1>
{
    public ElementalQuoteNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalQuoteNodeWithTypeIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ElementalQuoteNodeWithTypeIntersectionMember1TypeConverter))]
public enum ElementalQuoteNodeWithTypeIntersectionMember1Type
{
    Quote,
}

sealed class ElementalQuoteNodeWithTypeIntersectionMember1TypeConverter
    : JsonConverter<ElementalQuoteNodeWithTypeIntersectionMember1Type>
{
    public override ElementalQuoteNodeWithTypeIntersectionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "quote" => ElementalQuoteNodeWithTypeIntersectionMember1Type.Quote,
            _ => (ElementalQuoteNodeWithTypeIntersectionMember1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ElementalQuoteNodeWithTypeIntersectionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ElementalQuoteNodeWithTypeIntersectionMember1Type.Quote => "quote",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
