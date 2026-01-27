using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageContentResponse, MessageContentResponseFromRaw>))]
public sealed record class MessageContentResponse : JsonModel
{
    /// <summary>
    /// An array of render output of a previously sent message.
    /// </summary>
    public required IReadOnlyList<Result> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Result>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Result>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
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
    public MessageContentResponse(MessageContentResponse messageContentResponse)
        : base(messageContentResponse) { }
#pragma warning restore CS8618

    public MessageContentResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageContentResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageContentResponseFromRaw.FromRawUnchecked"/>
    public static MessageContentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MessageContentResponse(IReadOnlyList<Result> results)
        : this()
    {
        this.Results = results;
    }
}

class MessageContentResponseFromRaw : IFromRawJson<MessageContentResponse>
{
    /// <inheritdoc/>
    public MessageContentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageContentResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// The channel used for rendering the message.
    /// </summary>
    public required string Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <summary>
    /// The ID of channel used for rendering the message.
    /// </summary>
    public required string ChannelID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("channel_id");
        }
        init { this._rawData.Set("channel_id", value); }
    }

    /// <summary>
    /// Content details of the rendered message.
    /// </summary>
    public required Content Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Content>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channel;
        _ = this.ChannelID;
        this.Content.Validate();
    }

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result(Result result)
        : base(result) { }
#pragma warning restore CS8618

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}

/// <summary>
/// Content details of the rendered message.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Content, ContentFromRaw>))]
public sealed record class Content : JsonModel
{
    /// <summary>
    /// The blocks of the rendered message.
    /// </summary>
    public required IReadOnlyList<Block> Blocks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Block>>("blocks");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Block>>(
                "blocks",
                ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("body");
        }
        init { this._rawData.Set("body", value); }
    }

    /// <summary>
    /// The html content of the rendered message.
    /// </summary>
    public required string Html
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("html");
        }
        init { this._rawData.Set("html", value); }
    }

    /// <summary>
    /// The subject of the rendered message.
    /// </summary>
    public required string Subject
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("subject");
        }
        init { this._rawData.Set("subject", value); }
    }

    /// <summary>
    /// The text of the rendered message.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// The title of the rendered message.
    /// </summary>
    public required string Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Blocks)
        {
            item.Validate();
        }
        _ = this.Body;
        _ = this.Html;
        _ = this.Subject;
        _ = this.Text;
        _ = this.Title;
    }

    public Content() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Content(Content content)
        : base(content) { }
#pragma warning restore CS8618

    public Content(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Content(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContentFromRaw.FromRawUnchecked"/>
    public static Content FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContentFromRaw : IFromRawJson<Content>
{
    /// <inheritdoc/>
    public Content FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Content.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Block, BlockFromRaw>))]
public sealed record class Block : JsonModel
{
    /// <summary>
    /// The block text of the rendered message block.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// The block type of the rendered message block.
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        _ = this.Type;
    }

    public Block() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Block(Block block)
        : base(block) { }
#pragma warning restore CS8618

    public Block(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Block(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BlockFromRaw.FromRawUnchecked"/>
    public static Block FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BlockFromRaw : IFromRawJson<Block>
{
    /// <inheritdoc/>
    public Block FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Block.FromRawUnchecked(rawData);
}
