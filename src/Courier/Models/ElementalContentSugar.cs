using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models;

/// <summary>
/// Syntactic sugar to provide a fast shorthand for Courier Elemental Blocks.
/// </summary>
[JsonConverter(typeof(ModelConverter<ElementalContentSugar, ElementalContentSugarFromRaw>))]
public sealed record class ElementalContentSugar : ModelBase
{
    /// <summary>
    /// The text content displayed in the notification.
    /// </summary>
    public required string Body
    {
        get
        {
            if (!this._rawData.TryGetValue("body", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'body' cannot be null",
                    new ArgumentOutOfRangeException("body", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'body' cannot be null",
                    new ArgumentNullException("body")
                );
        }
        init
        {
            this._rawData["body"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Title/subject displayed by supported channels.
    /// </summary>
    public required string Title
    {
        get
        {
            if (!this._rawData.TryGetValue("title", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'title' cannot be null",
                    new ArgumentOutOfRangeException("title", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'title' cannot be null",
                    new ArgumentNullException("title")
                );
        }
        init
        {
            this._rawData["title"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Body;
        _ = this.Title;
    }

    public ElementalContentSugar() { }

    public ElementalContentSugar(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalContentSugar(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ElementalContentSugar FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementalContentSugarFromRaw : IFromRaw<ElementalContentSugar>
{
    public ElementalContentSugar FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementalContentSugar.FromRawUnchecked(rawData);
}
