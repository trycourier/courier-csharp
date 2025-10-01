using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Send.RecipientProperties.WebhookRecipientProperties.WebhookProperties;

namespace Courier.Models.Send.RecipientProperties.WebhookRecipientProperties;

[JsonConverter(typeof(ModelConverter<Webhook>))]
public sealed record class Webhook : ModelBase, IFromRaw<Webhook>
{
    /// <summary>
    /// The URL to send the webhook request to.
    /// </summary>
    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'url' cannot be null",
                    new ArgumentOutOfRangeException("url", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'url' cannot be null",
                    new ArgumentNullException("url")
                );
        }
        set
        {
            this.Properties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Authentication configuration for the webhook request.
    /// </summary>
    public Authentication? Authentication
    {
        get
        {
            if (!this.Properties.TryGetValue("authentication", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Authentication?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["authentication"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Custom headers to include in the webhook request.
    /// </summary>
    public Dictionary<string, string>? Headers
    {
        get
        {
            if (!this.Properties.TryGetValue("headers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["headers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The HTTP method to use for the webhook request. Defaults to POST if not specified.
    /// </summary>
    public ApiEnum<string, Method>? Method
    {
        get
        {
            if (!this.Properties.TryGetValue("method", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Method>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["method"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies what profile information is included in the request payload. Defaults
    /// to 'limited' if not specified.
    /// </summary>
    public ApiEnum<string, Profile>? Profile
    {
        get
        {
            if (!this.Properties.TryGetValue("profile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Profile>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["profile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.URL;
        this.Authentication?.Validate();
        if (this.Headers != null)
        {
            foreach (var item in this.Headers.Values)
            {
                _ = item;
            }
        }
        this.Method?.Validate();
        this.Profile?.Validate();
    }

    public Webhook() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Webhook(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Webhook FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Webhook(string url)
        : this()
    {
        this.URL = url;
    }
}
