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
    public required string URL
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "url"); }
        init { JsonModel.Set(this._rawData, "url", value); }
    }

    /// <summary>
    /// Authentication configuration for the webhook request.
    /// </summary>
    public WebhookAuthentication? Authentication
    {
        get
        {
            return JsonModel.GetNullableClass<WebhookAuthentication>(
                this.RawData,
                "authentication"
            );
        }
        init { JsonModel.Set(this._rawData, "authentication", value); }
    }

    /// <summary>
    /// Custom headers to include in the webhook request.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, string>>(this.RawData, "headers");
        }
        init { JsonModel.Set(this._rawData, "headers", value); }
    }

    /// <summary>
    /// The HTTP method to use for the webhook request. Defaults to POST if not specified.
    /// </summary>
    public ApiEnum<string, WebhookMethod>? Method
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, WebhookMethod>>(
                this.RawData,
                "method"
            );
        }
        init { JsonModel.Set(this._rawData, "method", value); }
    }

    /// <summary>
    /// Specifies what profile information is included in the request payload. Defaults
    /// to 'limited' if not specified.
    /// </summary>
    public ApiEnum<string, WebhookProfileType>? Profile
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, WebhookProfileType>>(
                this.RawData,
                "profile"
            );
        }
        init { JsonModel.Set(this._rawData, "profile", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.URL;
        this.Authentication?.Validate();
        _ = this.Headers;
        this.Method?.Validate();
        this.Profile?.Validate();
    }

    public WebhookProfile() { }

    public WebhookProfile(WebhookProfile webhookProfile)
        : base(webhookProfile) { }

    public WebhookProfile(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookProfile(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
        this.URL = url;
    }
}

class WebhookProfileFromRaw : IFromRawJson<WebhookProfile>
{
    /// <inheritdoc/>
    public WebhookProfile FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebhookProfile.FromRawUnchecked(rawData);
}
