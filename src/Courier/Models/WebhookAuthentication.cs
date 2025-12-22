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
            return JsonModel.GetNotNullClass<ApiEnum<string, WebhookAuthMode>>(
                this.RawData,
                "mode"
            );
        }
        init { JsonModel.Set(this._rawData, "mode", value); }
    }

    /// <summary>
    /// Token for bearer authentication.
    /// </summary>
    public string? Token
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "token"); }
        init { JsonModel.Set(this._rawData, "token", value); }
    }

    /// <summary>
    /// Password for basic authentication.
    /// </summary>
    public string? Password
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "password"); }
        init { JsonModel.Set(this._rawData, "password", value); }
    }

    /// <summary>
    /// Username for basic authentication.
    /// </summary>
    public string? Username
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "username"); }
        init { JsonModel.Set(this._rawData, "username", value); }
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

    public WebhookAuthentication(WebhookAuthentication webhookAuthentication)
        : base(webhookAuthentication) { }

    public WebhookAuthentication(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookAuthentication(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
