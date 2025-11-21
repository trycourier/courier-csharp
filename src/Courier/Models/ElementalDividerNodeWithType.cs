using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<ElementalDividerNodeWithType>))]
public sealed record class ElementalDividerNodeWithType
    : ModelBase,
        IFromRaw<ElementalDividerNodeWithType>
{
    public List<string>? Channels
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

    public ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                ElementalDividerNodeWithTypeIntersectionMember1Type
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
        ElementalDividerNodeWithType elementalDividerNodeWithType
    ) =>
        new()
        {
            Channels = elementalDividerNodeWithType.Channels,
            If = elementalDividerNodeWithType.If,
            Loop = elementalDividerNodeWithType.Loop,
            Ref = elementalDividerNodeWithType.Ref,
        };

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

    public static ElementalDividerNodeWithType FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

[JsonConverter(typeof(ModelConverter<ElementalDividerNodeWithTypeIntersectionMember1>))]
public sealed record class ElementalDividerNodeWithTypeIntersectionMember1
    : ModelBase,
        IFromRaw<ElementalDividerNodeWithTypeIntersectionMember1>
{
    public ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type>? Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                ElementalDividerNodeWithTypeIntersectionMember1Type
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

    public static ElementalDividerNodeWithTypeIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
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
