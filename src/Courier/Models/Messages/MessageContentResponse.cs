using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Messages;

[JsonConverter(typeof(ModelConverter<MessageContentResponse, MessageContentResponseFromRaw>))]
public sealed record class MessageContentResponse : ModelBase
{
    /// <summary>
    /// An array of render output of a previously sent message.
    /// </summary>
    public required IReadOnlyList<Result> Results
    {
        get
        {
            if (!this._rawData.TryGetValue("results", out JsonElement element))
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
        init
        {
            this._rawData["results"] = JsonSerializer.SerializeToElement(
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

    public MessageContentResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageContentResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static MessageContentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MessageContentResponse(List<Result> results)
        : this()
    {
        this.Results = results;
    }
}

class MessageContentResponseFromRaw : IFromRaw<MessageContentResponse>
{
    public MessageContentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageContentResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : ModelBase
{
    /// <summary>
    /// The channel used for rendering the message.
    /// </summary>
    public required string Channel
    {
        get
        {
            if (!this._rawData.TryGetValue("channel", out JsonElement element))
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
        init
        {
            this._rawData["channel"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("channel_id", out JsonElement element))
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
        init
        {
            this._rawData["channel_id"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("content", out JsonElement element))
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
        init
        {
            this._rawData["content"] = JsonSerializer.SerializeToElement(
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

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRaw<Result>
{
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}

/// <summary>
/// Content details of the rendered message.
/// </summary>
[JsonConverter(typeof(ModelConverter<Content, ContentFromRaw>))]
public sealed record class Content : ModelBase
{
    /// <summary>
    /// The blocks of the rendered message.
    /// </summary>
    public required IReadOnlyList<Block> Blocks
    {
        get
        {
            if (!this._rawData.TryGetValue("blocks", out JsonElement element))
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
        init
        {
            this._rawData["blocks"] = JsonSerializer.SerializeToElement(
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
    /// The html content of the rendered message.
    /// </summary>
    public required string HTML
    {
        get
        {
            if (!this._rawData.TryGetValue("html", out JsonElement element))
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
        init
        {
            this._rawData["html"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("subject", out JsonElement element))
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
        init
        {
            this._rawData["subject"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("text", out JsonElement element))
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
        init
        {
            this._rawData["text"] = JsonSerializer.SerializeToElement(
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

    public Content(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Content(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Content FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContentFromRaw : IFromRaw<Content>
{
    public Content FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Content.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Block, BlockFromRaw>))]
public sealed record class Block : ModelBase
{
    /// <summary>
    /// The block text of the rendered message block.
    /// </summary>
    public required string Text
    {
        get
        {
            if (!this._rawData.TryGetValue("text", out JsonElement element))
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
        init
        {
            this._rawData["text"] = JsonSerializer.SerializeToElement(
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
            if (!this._rawData.TryGetValue("type", out JsonElement element))
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
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
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

    public Block(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Block(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Block FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BlockFromRaw : IFromRaw<Block>
{
    public Block FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Block.FromRawUnchecked(rawData);
}
