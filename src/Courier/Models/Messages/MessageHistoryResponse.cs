using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageHistoryResponse, MessageHistoryResponseFromRaw>))]
public sealed record class MessageHistoryResponse : JsonModel
{
    public required IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "results",
                ImmutableArray.ToImmutableArray(
                    Enumerable.Select(value, (item) => FrozenDictionary.ToFrozenDictionary(item))
                )
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Results;
    }

    public MessageHistoryResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageHistoryResponse(MessageHistoryResponse messageHistoryResponse)
        : base(messageHistoryResponse) { }
#pragma warning restore CS8618

    public MessageHistoryResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageHistoryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageHistoryResponseFromRaw.FromRawUnchecked"/>
    public static MessageHistoryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MessageHistoryResponse(IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> results)
        : this()
    {
        this.Results = results;
    }
}

class MessageHistoryResponseFromRaw : IFromRawJson<MessageHistoryResponse>
{
    /// <inheritdoc/>
    public MessageHistoryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageHistoryResponse.FromRawUnchecked(rawData);
}
