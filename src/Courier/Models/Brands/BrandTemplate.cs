using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandTemplate>))]
public sealed record class BrandTemplate : ModelBase, IFromRaw<BrandTemplate>
{
    public required bool Enabled
    {
        get
        {
            if (!this._rawData.TryGetValue("enabled", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'enabled' cannot be null",
                    new ArgumentOutOfRangeException("enabled", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["enabled"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? BackgroundColor
    {
        get
        {
            if (!this._rawData.TryGetValue("backgroundColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["backgroundColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? BlocksBackgroundColor
    {
        get
        {
            if (!this._rawData.TryGetValue("blocksBackgroundColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["blocksBackgroundColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Footer
    {
        get
        {
            if (!this._rawData.TryGetValue("footer", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["footer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Head
    {
        get
        {
            if (!this._rawData.TryGetValue("head", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["head"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Header
    {
        get
        {
            if (!this._rawData.TryGetValue("header", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["header"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Width
    {
        get
        {
            if (!this._rawData.TryGetValue("width", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["width"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Enabled;
        _ = this.BackgroundColor;
        _ = this.BlocksBackgroundColor;
        _ = this.Footer;
        _ = this.Head;
        _ = this.Header;
        _ = this.Width;
    }

    public BrandTemplate() { }

    public BrandTemplate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandTemplate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BrandTemplate FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrandTemplate(bool enabled)
        : this()
    {
        this.Enabled = enabled;
    }
}
