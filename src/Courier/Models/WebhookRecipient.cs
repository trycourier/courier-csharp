using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

/// <summary>
/// Send via webhook
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookRecipient, WebhookRecipientFromRaw>))]
public sealed record class WebhookRecipient : JsonModel
{
    public required WebhookProfile Webhook
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<WebhookProfile>("webhook");
        }
        init { this._rawData.Set("webhook", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Webhook.Validate();
    }

    public WebhookRecipient() { }

    public WebhookRecipient(WebhookRecipient webhookRecipient)
        : base(webhookRecipient) { }

    public WebhookRecipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookRecipientFromRaw.FromRawUnchecked"/>
    public static WebhookRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebhookRecipient(WebhookProfile webhook)
        : this()
    {
        this.Webhook = webhook;
    }
}

class WebhookRecipientFromRaw : IFromRawJson<WebhookRecipient>
{
    /// <inheritdoc/>
    public WebhookRecipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookRecipient.FromRawUnchecked(rawData);
}
