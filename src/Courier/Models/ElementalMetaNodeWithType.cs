using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<ElementalMetaNodeWithType, ElementalMetaNodeWithTypeFromRaw>))]
public sealed record class ElementalMetaNodeWithType : ModelBase
{
    public IReadOnlyList<string>? Channels
    {
        get
        {
            if (!this._rawData.TryGetValue("channels", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["channels"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? If
    {
        get
        {
            if (!this._rawData.TryGetValue("if", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["if"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Loop
    {
        get
        {
            if (!this._rawData.TryGetValue("loop", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["loop"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Ref
    {
        get
        {
            if (!this._rawData.TryGetValue("ref", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["ref"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, ElementalMetaNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                ElementalMetaNodeWithTypeIntersectionMember1Type
            >?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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

    public override void Validate()
    {
        _ = this.Channels;
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        this.Type?.Validate();
    }

    public ElementalMetaNodeWithType() { }

    public ElementalMetaNodeWithType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalMetaNodeWithType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ElementalMetaNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalMetaNodeWithTypeFromRaw : IFromRaw<ElementalMetaNodeWithType>
{
    public ElementalMetaNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalMetaNodeWithType.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        ElementalMetaNodeWithTypeIntersectionMember1,
        ElementalMetaNodeWithTypeIntersectionMember1FromRaw
    >)
)]
public sealed record class ElementalMetaNodeWithTypeIntersectionMember1 : ModelBase
{
    public ApiEnum<string, ElementalMetaNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                ElementalMetaNodeWithTypeIntersectionMember1Type
            >?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Type?.Validate();
    }

    public ElementalMetaNodeWithTypeIntersectionMember1() { }

    public ElementalMetaNodeWithTypeIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalMetaNodeWithTypeIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ElementalMetaNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalMetaNodeWithTypeIntersectionMember1FromRaw
    : IFromRaw<ElementalMetaNodeWithTypeIntersectionMember1>
{
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
