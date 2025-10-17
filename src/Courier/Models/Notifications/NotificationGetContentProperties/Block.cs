using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Notifications.NotificationGetContentProperties.BlockProperties.LocalesProperties;
using BlockProperties = Courier.Models.Notifications.NotificationGetContentProperties.BlockProperties;

namespace Courier.Models.Notifications.NotificationGetContentProperties;

[JsonConverter(typeof(ModelConverter<Block>))]
public sealed record class Block : ModelBase, IFromRaw<Block>
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

    public required ApiEnum<string, BlockProperties::Type> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, BlockProperties::Type>>(
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

    public string? Alias
    {
        get
        {
            if (!this.Properties.TryGetValue("alias", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["alias"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Checksum
    {
        get
        {
            if (!this.Properties.TryGetValue("checksum", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["checksum"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public BlockProperties::Content? Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BlockProperties::Content?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Context
    {
        get
        {
            if (!this.Properties.TryGetValue("context", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["context"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, Locale>? Locales
    {
        get
        {
            if (!this.Properties.TryGetValue("locales", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, Locale>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["locales"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
        _ = this.Alias;
        _ = this.Checksum;
        this.Content?.Validate();
        _ = this.Context;
        if (this.Locales != null)
        {
            foreach (var item in this.Locales.Values)
            {
                item.Validate();
            }
        }
    }

    public Block() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Block(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Block FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
