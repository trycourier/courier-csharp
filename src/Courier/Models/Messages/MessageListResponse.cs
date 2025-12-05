using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Messages;

[JsonConverter(typeof(ModelConverter<MessageListResponse, MessageListResponseFromRaw>))]
public sealed record class MessageListResponse : ModelBase
{
    /// <summary>
    /// Paging information for the result set.
    /// </summary>
    public required Paging Paging
    {
        get { return ModelBase.GetNotNullClass<Paging>(this.RawData, "paging"); }
        init { ModelBase.Set(this._rawData, "paging", value); }
    }

    /// <summary>
    /// An array of messages with their details.
    /// </summary>
    public required IReadOnlyList<MessageDetails> Results
    {
        get { return ModelBase.GetNotNullClass<List<MessageDetails>>(this.RawData, "results"); }
        init { ModelBase.Set(this._rawData, "results", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Paging.Validate();
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public MessageListResponse() { }

    public MessageListResponse(MessageListResponse messageListResponse)
        : base(messageListResponse) { }

    public MessageListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageListResponseFromRaw.FromRawUnchecked"/>
    public static MessageListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageListResponseFromRaw : IFromRaw<MessageListResponse>
{
    /// <inheritdoc/>
    public MessageListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageListResponse.FromRawUnchecked(rawData);
}
