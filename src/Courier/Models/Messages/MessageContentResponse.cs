using System.Collections.Frozen;
using System.Collections.Generic;
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
        get { return JsonModel.GetNotNullClass<List<Result>>(this.RawData, "results"); }
        init { JsonModel.Set(this._rawData, "results", value); }
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

    public MessageContentResponse(MessageContentResponse messageContentResponse)
        : base(messageContentResponse) { }

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

    /// <inheritdoc cref="MessageContentResponseFromRaw.FromRawUnchecked"/>
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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "channel"); }
        init { JsonModel.Set(this._rawData, "channel", value); }
    }

    /// <summary>
    /// The ID of channel used for rendering the message.
    /// </summary>
    public required string ChannelID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "channel_id"); }
        init { JsonModel.Set(this._rawData, "channel_id", value); }
    }

    /// <summary>
    /// Content details of the rendered message.
    /// </summary>
    public required Content Content
    {
        get { return JsonModel.GetNotNullClass<Content>(this.RawData, "content"); }
        init { JsonModel.Set(this._rawData, "content", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channel;
        _ = this.ChannelID;
        this.Content.Validate();
    }

    public Result() { }

    public Result(Result result)
        : base(result) { }

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
        get { return JsonModel.GetNotNullClass<List<Block>>(this.RawData, "blocks"); }
        init { JsonModel.Set(this._rawData, "blocks", value); }
    }

    /// <summary>
    /// The body of the rendered message.
    /// </summary>
    public required string Body
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "body"); }
        init { JsonModel.Set(this._rawData, "body", value); }
    }

    /// <summary>
    /// The html content of the rendered message.
    /// </summary>
    public required string Html
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "html"); }
        init { JsonModel.Set(this._rawData, "html", value); }
    }

    /// <summary>
    /// The subject of the rendered message.
    /// </summary>
    public required string Subject
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "subject"); }
        init { JsonModel.Set(this._rawData, "subject", value); }
    }

    /// <summary>
    /// The text of the rendered message.
    /// </summary>
    public required string Text
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "text"); }
        init { JsonModel.Set(this._rawData, "text", value); }
    }

    /// <summary>
    /// The title of the rendered message.
    /// </summary>
    public required string Title
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "title"); }
        init { JsonModel.Set(this._rawData, "title", value); }
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

    public Content(Content content)
        : base(content) { }

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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "text"); }
        init { JsonModel.Set(this._rawData, "text", value); }
    }

    /// <summary>
    /// The block type of the rendered message block.
    /// </summary>
    public required string Type
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        _ = this.Type;
    }

    public Block() { }

    public Block(Block block)
        : base(block) { }

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
