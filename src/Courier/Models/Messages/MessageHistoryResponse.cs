using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Messages;

[JsonConverter(typeof(ModelConverter<MessageHistoryResponse, MessageHistoryResponseFromRaw>))]
public sealed record class MessageHistoryResponse : ModelBase
{
    public required List<Dictionary<string, JsonElement>> Results
    {
        get
        {
            if (!this._rawData.TryGetValue("results", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'results' cannot be null",
                    new ArgumentOutOfRangeException("results", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(
                    element,
                    ModelBase.SerializerOptions
                )
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
        _ = this.Results;
    }

    public MessageHistoryResponse() { }

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
    public MessageHistoryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MessageHistoryResponse.FromRawUnchecked(rawData);
}
