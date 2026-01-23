using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<WebhookAuthentication, WebhookAuthenticationFromRaw>))]
public sealed record class WebhookAuthentication : JsonModel
{
    /// <summary>
    /// The authentication mode to use. Defaults to 'none' if not specified.
    /// </summary>
    public required ApiEnum<string, WebhookAuthMode> Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WebhookAuthMode>>("mode");
        }
        init { this._rawData.Set("mode", value); }
    }

    /// <summary>
    /// Token for bearer authentication.
    /// </summary>
    public string? Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    /// <summary>
    /// Password for basic authentication.
    /// </summary>
    public string? Password
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("password");
        }
        init { this._rawData.Set("password", value); }
    }

    /// <summary>
    /// Username for basic authentication.
    /// </summary>
    public string? Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("username");
        }
        init { this._rawData.Set("username", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Mode.Validate();
        _ = this.Token;
        _ = this.Password;
        _ = this.Username;
    }

    public WebhookAuthentication() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookAuthentication(WebhookAuthentication webhookAuthentication)
        : base(webhookAuthentication) { }
#pragma warning restore CS8618

    public WebhookAuthentication(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookAuthentication(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookAuthenticationFromRaw.FromRawUnchecked"/>
    public static WebhookAuthentication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebhookAuthentication(ApiEnum<string, WebhookAuthMode> mode)
        : this()
    {
        this.Mode = mode;
    }
}

class WebhookAuthenticationFromRaw : IFromRawJson<WebhookAuthentication>
{
    /// <inheritdoc/>
    public WebhookAuthentication FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookAuthentication.FromRawUnchecked(rawData);
}
