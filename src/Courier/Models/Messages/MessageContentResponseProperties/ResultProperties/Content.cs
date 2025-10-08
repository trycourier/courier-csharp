using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Messages.MessageContentResponseProperties.ResultProperties.ContentProperties;
using Generic = System.Collections.Generic;

namespace Courier.Models.Messages.MessageContentResponseProperties.ResultProperties;

/// <summary>
/// Content details of the rendered message.
/// </summary>
[JsonConverter(typeof(ModelConverter<Content>))]
public sealed record class Content : ModelBase, IFromRaw<Content>
{
    /// <summary>
    /// The blocks of the rendered message.
    /// </summary>
    public required Generic::List<Block> Blocks
    {
        get
        {
            if (!this.Properties.TryGetValue("blocks", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'blocks' cannot be null",
                    new ArgumentOutOfRangeException("blocks", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Generic::List<Block>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'blocks' cannot be null",
                    new ArgumentNullException("blocks")
                );
        }
        set
        {
            this.Properties["blocks"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The body of the rendered message.
    /// </summary>
    public required string Body
    {
        get
        {
            if (!this.Properties.TryGetValue("body", out JsonElement element))
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
        set
        {
            this.Properties["body"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The html content of the rendered message.
    /// </summary>
    public required string HTML
    {
        get
        {
            if (!this.Properties.TryGetValue("html", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'html' cannot be null",
                    new ArgumentOutOfRangeException("html", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'html' cannot be null",
                    new ArgumentNullException("html")
                );
        }
        set
        {
            this.Properties["html"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The subject of the rendered message.
    /// </summary>
    public required string Subject
    {
        get
        {
            if (!this.Properties.TryGetValue("subject", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'subject' cannot be null",
                    new ArgumentOutOfRangeException("subject", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'subject' cannot be null",
                    new ArgumentNullException("subject")
                );
        }
        set
        {
            this.Properties["subject"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The text of the rendered message.
    /// </summary>
    public required string Text
    {
        get
        {
            if (!this.Properties.TryGetValue("text", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'text' cannot be null",
                    new ArgumentOutOfRangeException("text", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'text' cannot be null",
                    new ArgumentNullException("text")
                );
        }
        set
        {
            this.Properties["text"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The title of the rendered message.
    /// </summary>
    public required string Title
    {
        get
        {
            if (!this.Properties.TryGetValue("title", out JsonElement element))
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
        set
        {
            this.Properties["title"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Blocks)
        {
            item.Validate();
        }
        _ = this.Body;
        _ = this.HTML;
        _ = this.Subject;
        _ = this.Text;
        _ = this.Title;
    }

    public Content() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Content(Generic::Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Content FromRawUnchecked(Generic::Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
