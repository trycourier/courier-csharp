using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Generic = System.Collections.Generic;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<PutSubscriptionsRecipient>))]
public sealed record class PutSubscriptionsRecipient
    : ModelBase,
        IFromRaw<PutSubscriptionsRecipient>
{
    public required string RecipientID
    {
        get
        {
            if (!this.Properties.TryGetValue("recipientId", out JsonElement element))
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
        set
        {
            this.Properties["recipientId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public RecipientPreferences? Preferences
    {
        get
        {
            if (!this.Properties.TryGetValue("preferences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<RecipientPreferences?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["preferences"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PutSubscriptionsRecipient(Generic::Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PutSubscriptionsRecipient FromRawUnchecked(
        Generic::Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public PutSubscriptionsRecipient(string recipientID)
        : this()
    {
        this.RecipientID = recipientID;
    }
}
