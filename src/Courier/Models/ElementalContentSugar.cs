using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

/// <summary>
/// Syntactic sugar to provide a fast shorthand for Courier Elemental Blocks.
/// </summary>
[JsonConverter(typeof(ModelConverter<ElementalContentSugar>))]
public sealed record class ElementalContentSugar : ModelBase, IFromRaw<ElementalContentSugar>
{
    /// <summary>
    /// The text content displayed in the notification.
    /// </summary>
    public required string Body
    {
        get
        {
            if (!this._properties.TryGetValue("body", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'body' cannot be null",
                    new System::ArgumentOutOfRangeException("body", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'body' cannot be null",
                    new System::ArgumentNullException("body")
                );
        }
        init
        {
            this._properties["body"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("title", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'title' cannot be null",
                    new System::ArgumentOutOfRangeException("title", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'title' cannot be null",
                    new System::ArgumentNullException("title")
                );
        }
        init
        {
            this._properties["title"] = JsonSerializer.SerializeToElement(
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

    public ElementalContentSugar(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementalContentSugar(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ElementalContentSugar FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
