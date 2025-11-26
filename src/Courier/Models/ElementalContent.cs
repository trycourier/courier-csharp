using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<ElementalContent, ElementalContentFromRaw>))]
public sealed record class ElementalContent : ModelBase
{
    public required List<ElementalNode> Elements
    {
        get
        {
            if (!this._rawData.TryGetValue("elements", out JsonElement element))
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
        init
        {
            this._rawData["elements"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("version", out JsonElement element))
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
        init
        {
            this._rawData["version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Brand
    {
        get
        {
            if (!this._rawData.TryGetValue("brand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["brand"] = JsonSerializer.SerializeToElement(
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

    public ElementalContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ElementalContent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalContentFromRaw : IFromRaw<ElementalContent>
{
    public ElementalContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ElementalContent.FromRawUnchecked(rawData);
}
