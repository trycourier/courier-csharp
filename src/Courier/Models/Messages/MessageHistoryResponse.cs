using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Messages;

[JsonConverter(typeof(ModelConverter<MessageHistoryResponse>))]
public sealed record class MessageHistoryResponse : ModelBase, IFromRaw<MessageHistoryResponse>
{
    public required List<Dictionary<string, JsonElement>> Results
    {
        get
        {
            if (!this._properties.TryGetValue("results", out JsonElement element))
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
            this._properties["results"] = JsonSerializer.SerializeToElement(
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

    public MessageHistoryResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageHistoryResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MessageHistoryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public MessageHistoryResponse(List<Dictionary<string, JsonElement>> results)
        : this()
    {
        this.Results = results;
    }
}
