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
    typeof(ModelConverter<ElementalDividerNodeWithType, ElementalDividerNodeWithTypeFromRaw>)
)]
public sealed record class ElementalDividerNodeWithType : ModelBase
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

    public ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type>
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
        ElementalDividerNodeWithType elementalDividerNodeWithType
    ) =>
        new()
        {
            Channels = elementalDividerNodeWithType.Channels,
            If = elementalDividerNodeWithType.If,
            Loop = elementalDividerNodeWithType.Loop,
            Ref = elementalDividerNodeWithType.Ref,
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

    public ElementalDividerNodeWithType() { }

    public ElementalDividerNodeWithType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalDividerNodeWithType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalDividerNodeWithTypeFromRaw.FromRawUnchecked"/>
    public static ElementalDividerNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalDividerNodeWithTypeFromRaw : IFromRaw<ElementalDividerNodeWithType>
{
    /// <inheritdoc/>
    public ElementalDividerNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalDividerNodeWithType.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        ElementalDividerNodeWithTypeIntersectionMember1,
        ElementalDividerNodeWithTypeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalDividerNodeWithTypeIntersectionMember1 : ModelBase
{
    public ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<
                ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type>
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

    public ElementalDividerNodeWithTypeIntersectionMember1() { }

    public ElementalDividerNodeWithTypeIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalDividerNodeWithTypeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalDividerNodeWithTypeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static ElementalDividerNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalDividerNodeWithTypeIntersectionMember1FromRaw
    : IFromRaw<ElementalDividerNodeWithTypeIntersectionMember1>
{
    /// <inheritdoc/>
    public ElementalDividerNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalDividerNodeWithTypeIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ElementalDividerNodeWithTypeIntersectionMember1TypeConverter))]
public enum ElementalDividerNodeWithTypeIntersectionMember1Type
{
    Divider,
}

sealed class ElementalDividerNodeWithTypeIntersectionMember1TypeConverter
    : JsonConverter<ElementalDividerNodeWithTypeIntersectionMember1Type>
{
    public override ElementalDividerNodeWithTypeIntersectionMember1Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "divider" => ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
            _ => (ElementalDividerNodeWithTypeIntersectionMember1Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ElementalDividerNodeWithTypeIntersectionMember1Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ElementalDividerNodeWithTypeIntersectionMember1Type.Divider => "divider",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
