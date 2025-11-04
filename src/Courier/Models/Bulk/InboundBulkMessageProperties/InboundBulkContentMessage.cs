using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Bulk.InboundBulkMessageProperties.InboundBulkContentMessageProperties;

namespace Courier.Models.Bulk.InboundBulkMessageProperties;

[JsonConverter(typeof(ModelConverter<InboundBulkContentMessage>))]
public sealed record class InboundBulkContentMessage
    : ModelBase,
        IFromRaw<InboundBulkContentMessage>
{
    /// <summary>
    /// Syntactic sugar to provide a fast shorthand for Courier Elemental Blocks.
    /// </summary>
    public required Content Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'content' cannot be null",
                    new ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Content>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'content' cannot be null",
                    new ArgumentNullException("content")
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

    public string? Brand
    {
        get
        {
            if (!this.Properties.TryGetValue("brand", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["brand"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Event
    {
        get
        {
            if (!this.Properties.TryGetValue("event", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["event"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, Dictionary<string, JsonElement>>? Locale
    {
        get
        {
            if (!this.Properties.TryGetValue("locale", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, JsonElement>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["locale"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Override
    {
        get
        {
            if (!this.Properties.TryGetValue("override", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["override"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Content.Validate();
        _ = this.Brand;
        _ = this.Data;
        _ = this.Event;
        _ = this.Locale;
        _ = this.Override;
    }

    public InboundBulkContentMessage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundBulkContentMessage(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static InboundBulkContentMessage FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public InboundBulkContentMessage(Content content)
        : this()
    {
        this.Content = content;
    }
}
