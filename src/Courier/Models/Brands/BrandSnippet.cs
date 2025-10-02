using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Brands.BrandSnippetProperties;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandSnippet>))]
public sealed record class BrandSnippet : ModelBase, IFromRaw<BrandSnippet>
{
    public required ApiEnum<string, Format> Format
    {
        get
        {
            if (!this.Properties.TryGetValue("format", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'format' cannot be null",
                    new ArgumentOutOfRangeException("format", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Format>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["format"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentNullException("name")
                );
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Value
    {
        get
        {
            if (!this.Properties.TryGetValue("value", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'value' cannot be null",
                    new ArgumentOutOfRangeException("value", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'value' cannot be null",
                    new ArgumentNullException("value")
                );
        }
        set
        {
            this.Properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Format.Validate();
        _ = this.Name;
        _ = this.Value;
    }

    public BrandSnippet() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSnippet(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BrandSnippet FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
