using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageListResponse, MessageListResponseFromRaw>))]
public sealed record class MessageListResponse : JsonModel
{
    /// <summary>
    /// Paging information for the result set.
    /// </summary>
    public required Paging Paging
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Paging>("paging");
        }
        init { this._rawData.Set("paging", value); }
    }

    /// <summary>
    /// An array of messages with their details.
    /// </summary>
    public required IReadOnlyList<MessageDetails> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MessageDetails>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MessageDetails>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageListResponse(MessageListResponse messageListResponse)
        : base(messageListResponse) { }
#pragma warning restore CS8618

    public MessageListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class MessageListResponseFromRaw : IFromRawJson<MessageListResponse>
{
    /// <inheritdoc/>
    public MessageListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageListResponse.FromRawUnchecked(rawData);
}
