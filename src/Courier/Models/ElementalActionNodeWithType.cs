using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Models.ElementalActionNodeWithTypeProperties.IntersectionMember1Properties;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<ElementalActionNodeWithType>))]
public sealed record class ElementalActionNodeWithType
    : ModelBase,
        IFromRaw<ElementalActionNodeWithType>
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

    public ApiEnum<string, Type>? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Type>?>(
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
        ElementalActionNodeWithType elementalActionNodeWithType
    ) =>
        new()
        {
            Channels = elementalActionNodeWithType.Channels,
            If = elementalActionNodeWithType.If,
            Loop = elementalActionNodeWithType.Loop,
            Ref = elementalActionNodeWithType.Ref,
        };

    public override void Validate()
    {
        foreach (var item in this.Channels ?? [])
        {
            _ = item;
        }
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        this.Type?.Validate();
    }

    public ElementalActionNodeWithType() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalActionNodeWithType(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ElementalActionNodeWithType FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
