using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Send.RecipientProperties.WebhookRecipientProperties;

namespace Courier.Models.Send.RecipientProperties;

[JsonConverter(typeof(ModelConverter<WebhookRecipient>))]
public sealed record class WebhookRecipient : ModelBase, IFromRaw<WebhookRecipient>
{
    public required Webhook Webhook
    {
        get
        {
            if (!this.Properties.TryGetValue("webhook", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'webhook' cannot be null",
                    new ArgumentOutOfRangeException("webhook", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Webhook>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'webhook' cannot be null",
                    new ArgumentNullException("webhook")
                );
        }
        set
        {
            this.Properties["webhook"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Webhook.Validate();
    }

    public WebhookRecipient() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookRecipient(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static WebhookRecipient FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public WebhookRecipient(Webhook webhook)
        : this()
    {
        this.Webhook = webhook;
    }
}
