using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Tenants.Templates;

[JsonConverter(typeof(ModelConverter<ElementalContent>))]
public sealed record class ElementalContent : ModelBase, IFromRaw<ElementalContent>
{
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

    /// <summary>
    /// For example, "2022-01-01"
    /// </summary>
    public required string Version
    {
        get
        {
            if (!this.Properties.TryGetValue("version", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'version' cannot be null",
                    new ArgumentOutOfRangeException("version", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'version' cannot be null",
                    new ArgumentNullException("version")
                );
        }
        set
        {
            this.Properties["version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement? Brand
    {
        get
        {
            if (!this.Properties.TryGetValue("brand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<JsonElement?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["brand"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Elements)
        {
            item.Validate();
        }
        _ = this.Version;
        _ = this.Brand;
    }

    public ElementalContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalContent(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ElementalContent FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
