using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using IntersectionMember1Properties = Courier.Models.Tenants.Templates.ElementalNodeProperties.UnionMember6Properties.IntersectionMember1Properties;

namespace Courier.Models.Tenants.Templates.ElementalNodeProperties;

/// <summary>
/// Allows you to group elements together. This can be useful when used in combination
/// with "if" or "loop". See [control flow docs](https://www.courier.com/docs/platform/content/elemental/control-flow/)
/// for more details.
/// </summary>
[JsonConverter(typeof(ModelConverter<UnionMember6>))]
public sealed record class UnionMember6 : ModelBase, IFromRaw<UnionMember6>
{
    /// <summary>
    /// Sub elements to render.
    /// </summary>
    public required List<ElementalNode> Elements
    {
        get
        {
            if (!this.Properties.TryGetValue("elements", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'elements' cannot be null",
                    new ArgumentOutOfRangeException("elements", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<ElementalNode>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'elements' cannot be null",
                    new ArgumentNullException("elements")
                );
        }
        set
        {
            this.Properties["elements"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public ApiEnum<string, IntersectionMember1Properties::Type>? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                IntersectionMember1Properties::Type
            >?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator ElementalGroupNode(UnionMember6 unionMember6) =>
        new()
        {
            Elements = unionMember6.Elements,
            Channels = unionMember6.Channels,
            If = unionMember6.If,
            Loop = unionMember6.Loop,
            Ref = unionMember6.Ref,
        };

    public override void Validate()
    {
        foreach (var item in this.Elements)
        {
            item.Validate();
        }
        foreach (var item in this.Channels ?? [])
        {
            _ = item;
        }
        _ = this.If;
        _ = this.Loop;
        _ = this.Ref;
        this.Type?.Validate();
    }

    public UnionMember6() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember6(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UnionMember6 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public UnionMember6(List<ElementalNode> elements)
        : this()
    {
        this.Elements = elements;
    }
}
