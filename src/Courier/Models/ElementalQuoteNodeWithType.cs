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
    typeof(JsonModelConverter<ElementalQuoteNodeWithType, ElementalQuoteNodeWithTypeFromRaw>)
)]
public sealed record class ElementalQuoteNodeWithType : JsonModel
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

    public ApiEnum<string, ElementalQuoteNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ElementalQuoteNodeWithTypeIntersectionMember1Type>
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
        ElementalQuoteNodeWithType elementalQuoteNodeWithType
    ) =>
        new()
        {
            Channels = elementalQuoteNodeWithType.Channels,
            If = elementalQuoteNodeWithType.If,
            Loop = elementalQuoteNodeWithType.Loop,
            Ref = elementalQuoteNodeWithType.Ref,
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

    public ElementalQuoteNodeWithType() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalQuoteNodeWithType(ElementalQuoteNodeWithType elementalQuoteNodeWithType)
        : base(elementalQuoteNodeWithType) { }
#pragma warning restore CS8618

    public ElementalQuoteNodeWithType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalQuoteNodeWithType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalQuoteNodeWithTypeFromRaw.FromRawUnchecked"/>
    public static ElementalQuoteNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalQuoteNodeWithTypeFromRaw : IFromRawJson<ElementalQuoteNodeWithType>
{
    /// <inheritdoc/>
    public ElementalQuoteNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalQuoteNodeWithType.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        ElementalQuoteNodeWithTypeIntersectionMember1,
        ElementalQuoteNodeWithTypeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalQuoteNodeWithTypeIntersectionMember1 : JsonModel
{
    public ApiEnum<string, ElementalQuoteNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, ElementalQuoteNodeWithTypeIntersectionMember1Type>
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

    public ElementalQuoteNodeWithTypeIntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementalQuoteNodeWithTypeIntersectionMember1(
        ElementalQuoteNodeWithTypeIntersectionMember1 elementalQuoteNodeWithTypeIntersectionMember1
    )
        : base(elementalQuoteNodeWithTypeIntersectionMember1) { }
#pragma warning restore CS8618

    public ElementalQuoteNodeWithTypeIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalQuoteNodeWithTypeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementalQuoteNodeWithTypeIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static ElementalQuoteNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalQuoteNodeWithTypeIntersectionMember1FromRaw
    : IFromRawJson<ElementalQuoteNodeWithTypeIntersectionMember1>
{
    /// <inheritdoc/>
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
