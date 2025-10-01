using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<Brand>))]
public sealed record class Brand : ModelBase, IFromRaw<Brand>
{
    /// <summary>
    /// The date/time of when the brand was created. Represented in milliseconds
    /// since Unix epoch.
    /// </summary>
    public required long Created
    {
        get
        {
            if (!this.Properties.TryGetValue("created", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'created' cannot be null",
                    new ArgumentOutOfRangeException("created", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Brand name
    /// </summary>
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

    /// <summary>
    /// The date/time of when the brand was published. Represented in milliseconds
    /// since Unix epoch.
    /// </summary>
    public required long Published
    {
        get
        {
            if (!this.Properties.TryGetValue("published", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'published' cannot be null",
                    new ArgumentOutOfRangeException("published", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["published"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required BrandSettings Settings
    {
        get
        {
            if (!this.Properties.TryGetValue("settings", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'settings' cannot be null",
                    new ArgumentOutOfRangeException("settings", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BrandSettings>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'settings' cannot be null",
                    new ArgumentNullException("settings")
                );
        }
        set
        {
            this.Properties["settings"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The date/time of when the brand was updated. Represented in milliseconds
    /// since Unix epoch.
    /// </summary>
    public required long Updated
    {
        get
        {
            if (!this.Properties.TryGetValue("updated", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'updated' cannot be null",
                    new ArgumentOutOfRangeException("updated", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["updated"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The version identifier for the brand
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

    /// <summary>
    /// Brand Identifier
    /// </summary>
    public string? ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BrandSnippets? Snippets
    {
        get
        {
            if (!this.Properties.TryGetValue("snippets", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BrandSnippets?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["snippets"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Created;
        _ = this.Name;
        _ = this.Published;
        this.Settings.Validate();
        _ = this.Updated;
        _ = this.Version;
        _ = this.ID;
        this.Snippets?.Validate();
    }

    public Brand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Brand(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Brand FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
