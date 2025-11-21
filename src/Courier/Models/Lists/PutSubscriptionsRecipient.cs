using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Lists;

[JsonConverter(typeof(ModelConverter<PutSubscriptionsRecipient>))]
public sealed record class PutSubscriptionsRecipient
    : ModelBase,
        IFromRaw<PutSubscriptionsRecipient>
{
    public required string RecipientID
    {
        get
        {
            if (!this._rawData.TryGetValue("recipientId", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'recipientId' cannot be null",
                    new ArgumentOutOfRangeException("recipientId", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'recipientId' cannot be null",
                    new ArgumentNullException("recipientId")
                );
        }
        init
        {
            this._rawData["recipientId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public RecipientPreferences? Preferences
    {
        get
        {
            if (!this._rawData.TryGetValue("preferences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<RecipientPreferences?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["preferences"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.RecipientID;
        this.Preferences?.Validate();
    }

    public PutSubscriptionsRecipient() { }

    public PutSubscriptionsRecipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PutSubscriptionsRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PutSubscriptionsRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PutSubscriptionsRecipient(string recipientID)
        : this()
    {
        this.RecipientID = recipientID;
    }
}
