using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Messages;

[JsonConverter(typeof(ModelConverter<MessageHistoryResponse, MessageHistoryResponseFromRaw>))]
public sealed record class MessageHistoryResponse : ModelBase
{
    public required IReadOnlyList<Dictionary<string, JsonElement>> Results
    {
        get
        {
            return ModelBase.GetNotNullClass<List<Dictionary<string, JsonElement>>>(
                this.RawData,
                "results"
            );
        }
        init { ModelBase.Set(this._rawData, "results", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Results;
    }

    public MessageHistoryResponse() { }

    public MessageHistoryResponse(MessageHistoryResponse messageHistoryResponse)
        : base(messageHistoryResponse) { }

    public MessageHistoryResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageHistoryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    public MessageHistoryResponse(List<Dictionary<string, JsonElement>> results)
        : this()
    {
        this.Results = results;
    }
}

class MessageHistoryResponseFromRaw : IFromRaw<MessageHistoryResponse>
{
    /// <inheritdoc/>
    public MessageHistoryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageHistoryResponse.FromRawUnchecked(rawData);
}
