using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<WebhookProfile, WebhookProfileFromRaw>))]
public sealed record class WebhookProfile : JsonModel
{
    /// <summary>
    /// The URL to send the webhook request to.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Authentication configuration for the webhook request.
    /// </summary>
    public WebhookAuthentication? Authentication
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WebhookAuthentication>("authentication");
        }
        init { this._rawData.Set("authentication", value); }
    }

    /// <summary>
    /// Custom headers to include in the webhook request.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The HTTP method to use for the webhook request. Defaults to POST if not specified.
    /// </summary>
    public ApiEnum<string, WebhookMethod>? Method
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WebhookMethod>>("method");
        }
        init { this._rawData.Set("method", value); }
    }

    /// <summary>
    /// Specifies what profile information is included in the request payload. Defaults
    /// to 'limited' if not specified.
    /// </summary>
    public ApiEnum<string, WebhookProfileType>? Profile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WebhookProfileType>>("profile");
        }
        init { this._rawData.Set("profile", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
        this.Authentication?.Validate();
        _ = this.Headers;
        this.Method?.Validate();
        this.Profile?.Validate();
    }

    public WebhookProfile() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookProfile(WebhookProfile webhookProfile)
        : base(webhookProfile) { }
#pragma warning restore CS8618

    public WebhookProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookProfileFromRaw.FromRawUnchecked"/>
    public static WebhookProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebhookProfile(string url)
        : this()
    {
        this.Url = url;
    }
}

class WebhookProfileFromRaw : IFromRawJson<WebhookProfile>
{
    /// <inheritdoc/>
    public WebhookProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookProfile.FromRawUnchecked(rawData);
}
