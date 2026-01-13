using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;

namespace Courier.Models.Auth;

/// <summary>
/// Returns a new access token.
/// </summary>
public sealed record class AuthIssueTokenParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Duration for token expiration. Accepts various time formats: - "2 hours" -
    /// 2 hours from now - "1d" - 1 day - "3 days" - 3 days - "10h" - 10 hours - "2.5
    /// hrs" - 2.5 hours - "1m" - 1 minute - "5s" - 5 seconds - "1y" - 1 year
    /// </summary>
    public required string ExpiresIn
    {
        get { return this._rawBodyData.GetNotNullClass<string>("expires_in"); }
        init { this._rawBodyData.Set("expires_in", value); }
    }

    /// <summary>
    /// Available scopes: - `user_id:<user-id>` - Defines which user the token will
    /// be scoped to. Multiple can be listed if needed. Ex `user_id:pigeon user_id:bluebird`.
    /// - `read:messages` - Read messages. - `read:user-tokens` - Read user push
    /// tokens. - `write:user-tokens` - Write user push tokens. - `read:brands[:<brand_id>]`
    /// - Read brands, optionally restricted to a specific brand_id. Examples `read:brands`,
    /// `read:brands:my_brand`. - `write:brands[:<brand_id>]` - Write brands, optionally
    /// restricted to a specific brand_id. Examples `write:brands`, `write:brands:my_brand`.
    /// - `inbox:read:messages` - Read inbox messages. - `inbox:write:events` - Write
    /// inbox events, such as mark message as read. - `read:preferences` - Read user
    /// preferences. - `write:preferences` - Write user preferences. Example: `user_id:user123
    /// write:user-tokens inbox:read:messages inbox:write:events read:preferences
    /// write:preferences read:brands`
    /// </summary>
    public required string Scope
    {
        get { return this._rawBodyData.GetNotNullClass<string>("scope"); }
        init { this._rawBodyData.Set("scope", value); }
    }

    public AuthIssueTokenParams() { }

    public AuthIssueTokenParams(AuthIssueTokenParams authIssueTokenParams)
        : base(authIssueTokenParams)
    {
        this._rawBodyData = new(authIssueTokenParams._rawBodyData);
    }

    public AuthIssueTokenParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthIssueTokenParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static AuthIssueTokenParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/auth/issue-token")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
