using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<ElementalQuoteNodeWithType>))]
public sealed record class ElementalQuoteNodeWithType
    : ModelBase,
        IFromRaw<ElementalQuoteNodeWithType>
{
    public List<string>? Channels
    {
        get
        {
            if (!this.Properties.TryGetValue("channels", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["channels"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? If
    {
        get
        {
            if (!this.Properties.TryGetValue("if", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["if"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Loop
    {
        get
        {
            if (!this.Properties.TryGetValue("loop", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["loop"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Ref
    {
        get
        {
            if (!this.Properties.TryGetValue("ref", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ref"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, Type4>? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Type4>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalQuoteNodeWithType(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ElementalQuoteNodeWithType FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<IntersectionMember15>))]
public sealed record class IntersectionMember15 : ModelBase, IFromRaw<IntersectionMember15>
{
    public ApiEnum<string, Type4>? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Type4>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Type?.Validate();
    }

    public IntersectionMember15() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember15(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static IntersectionMember15 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(Type4Converter))]
public enum Type4
{
    Quote,
}

sealed class Type4Converter : JsonConverter<Type4>
{
    public override Type4 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "quote" => Type4.Quote,
            _ => (Type4)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type4 value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Type4.Quote => "quote",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
