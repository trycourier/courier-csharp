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
    typeof(JsonModelConverter<ElementalDividerNodeWithType, ElementalDividerNodeWithTypeFromRaw>)
)]
public sealed record class ElementalDividerNodeWithType : JsonModel
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

    public ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type>
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

    public ElementalDividerNodeWithType(ElementalDividerNodeWithType elementalDividerNodeWithType)
        : base(elementalDividerNodeWithType) { }

    public ElementalDividerNodeWithType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalDividerNodeWithType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class ElementalDividerNodeWithTypeFromRaw : IFromRawJson<ElementalDividerNodeWithType>
{
    /// <inheritdoc/>
    public ElementalDividerNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalDividerNodeWithType.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ElementalDividerNodeWithTypeIntersectionMember1,
        ElementalDividerNodeWithTypeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalDividerNodeWithTypeIntersectionMember1 : JsonModel
{
    public ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type>
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

    public ElementalDividerNodeWithTypeIntersectionMember1() { }

    public ElementalDividerNodeWithTypeIntersectionMember1(
        ElementalDividerNodeWithTypeIntersectionMember1 elementalDividerNodeWithTypeIntersectionMember1
    )
        : base(elementalDividerNodeWithTypeIntersectionMember1) { }

    public ElementalDividerNodeWithTypeIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalDividerNodeWithTypeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
    : IFromRawJson<ElementalDividerNodeWithTypeIntersectionMember1>
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
