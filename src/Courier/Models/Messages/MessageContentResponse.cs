using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Messages;

[JsonConverter(typeof(ModelConverter<MessageContentResponse>))]
public sealed record class MessageContentResponse : ModelBase, IFromRaw<MessageContentResponse>
{
    /// <summary>
    /// An array of render output of a previously sent message.
    /// </summary>
    public required List<Result> Results
    {
        get
        {
            if (!this.Properties.TryGetValue("results", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'results' cannot be null",
                    new ArgumentOutOfRangeException("results", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Result>>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'results' cannot be null",
                    new ArgumentNullException("results")
                );
        }
        set
        {
            this.Properties["results"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public MessageContentResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageContentResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageContentResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public MessageContentResponse(List<Result> results)
        : this()
    {
        this.Results = results;
    }
}

[JsonConverter(typeof(ModelConverter<Result>))]
public sealed record class Result : ModelBase, IFromRaw<Result>
{
    /// <summary>
    /// The channel used for rendering the message.
    /// </summary>
    public required string Channel
    {
        get
        {
            if (!this.Properties.TryGetValue("channel", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channel' cannot be null",
                    new ArgumentOutOfRangeException("channel", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'channel' cannot be null",
                    new ArgumentNullException("channel")
                );
        }
        set
        {
            this.Properties["channel"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The ID of channel used for rendering the message.
    /// </summary>
    public required string ChannelID
    {
        get
        {
            if (!this.Properties.TryGetValue("channel_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channel_id' cannot be null",
                    new ArgumentOutOfRangeException("channel_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'channel_id' cannot be null",
                    new ArgumentNullException("channel_id")
                );
        }
        set
        {
            this.Properties["channel_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Content details of the rendered message.
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

    public override void Validate()
    {
        _ = this.Channel;
        _ = this.ChannelID;
        this.Content.Validate();
    }

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Result FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

/// <summary>
/// Content details of the rendered message.
/// </summary>
[JsonConverter(typeof(ModelConverter<Content>))]
public sealed record class Content : ModelBase, IFromRaw<Content>
{
    /// <summary>
    /// The blocks of the rendered message.
    /// </summary>
    public required List<Block> Blocks
    {
        get
        {
            if (!this.Properties.TryGetValue("blocks", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'blocks' cannot be null",
                    new ArgumentOutOfRangeException("blocks", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Block>>(element, ModelBase.SerializerOptions)
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
    Content(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Content FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<Block>))]
public sealed record class Block : ModelBase, IFromRaw<Block>
{
    /// <summary>
    /// The block text of the rendered message block.
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
    /// The block type of the rendered message block.
    /// </summary>
    public required string Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentNullException("type")
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

    public override void Validate()
    {
        _ = this.Text;
        _ = this.Type;
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
