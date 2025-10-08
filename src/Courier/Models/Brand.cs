using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Generic = System.Collections.Generic;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<Brand>))]
public sealed record class Brand : ModelBase, IFromRaw<Brand>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public long? Published
    {
        get
        {
            if (!this.Properties.TryGetValue("published", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["published"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BrandSettings? Settings
    {
        get
        {
            if (!this.Properties.TryGetValue("settings", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BrandSettings?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["settings"] = JsonSerializer.SerializeToElement(
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

    public string? Version
    {
        get
        {
            if (!this.Properties.TryGetValue("version", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Created;
        _ = this.Name;
        _ = this.Updated;
        _ = this.Published;
        this.Settings?.Validate();
        this.Snippets?.Validate();
        _ = this.Version;
    }

    public Brand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Brand(Generic::Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Brand FromRawUnchecked(Generic::Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
