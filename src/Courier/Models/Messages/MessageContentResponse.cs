using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Messages;

[JsonConverter(typeof(ModelConverter<MessageContentResponse, MessageContentResponseFromRaw>))]
public sealed record class MessageContentResponse : ModelBase
{
    /// <summary>
    /// An array of render output of a previously sent message.
    /// </summary>
    public required IReadOnlyList<Result> Results
    {
        get { return ModelBase.GetNotNullClass<List<Result>>(this.RawData, "results"); }
        init { ModelBase.Set(this._rawData, "results", value); }
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

class MessageContentResponseFromRaw : IFromRaw<MessageContentResponse>
{
    /// <inheritdoc/>
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
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "channel"); }
        init { ModelBase.Set(this._rawData, "channel", value); }
    }

    /// <summary>
    /// The ID of channel used for rendering the message.
    /// </summary>
    public required string ChannelID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "channel_id"); }
        init { ModelBase.Set(this._rawData, "channel_id", value); }
    }

    /// <summary>
    /// Content details of the rendered message.
    /// </summary>
    public required Content Content
    {
        get { return ModelBase.GetNotNullClass<Content>(this.RawData, "content"); }
        init { ModelBase.Set(this._rawData, "content", value); }
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ResultFromRaw : IFromRaw<Result>
{
    /// <inheritdoc/>
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
        get { return ModelBase.GetNotNullClass<List<Block>>(this.RawData, "blocks"); }
        init { ModelBase.Set(this._rawData, "blocks", value); }
    }

    /// <summary>
    /// The body of the rendered message.
    /// </summary>
    public required string Body
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "body"); }
        init { ModelBase.Set(this._rawData, "body", value); }
    }

    /// <summary>
    /// The html content of the rendered message.
    /// </summary>
    public required string HTML
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "html"); }
        init { ModelBase.Set(this._rawData, "html", value); }
    }

    /// <summary>
    /// The subject of the rendered message.
    /// </summary>
    public required string Subject
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "subject"); }
        init { ModelBase.Set(this._rawData, "subject", value); }
    }

    /// <summary>
    /// The text of the rendered message.
    /// </summary>
    public required string Text
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "text"); }
        init { ModelBase.Set(this._rawData, "text", value); }
    }

    /// <summary>
    /// The title of the rendered message.
    /// </summary>
    public required string Title
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "title"); }
        init { ModelBase.Set(this._rawData, "title", value); }
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="ContentFromRaw.FromRawUnchecked"/>
    public static Content FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContentFromRaw : IFromRaw<Content>
{
    /// <inheritdoc/>
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
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "text"); }
        init { ModelBase.Set(this._rawData, "text", value); }
    }

    /// <summary>
    /// The block type of the rendered message block.
    /// </summary>
    public required string Type
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="BlockFromRaw.FromRawUnchecked"/>
    public static Block FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BlockFromRaw : IFromRaw<Block>
{
    /// <inheritdoc/>
    public Block FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Block.FromRawUnchecked(rawData);
}
