using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Auth;

/// <summary>
/// Returns a new access token.
/// </summary>
public sealed record class AuthIssueTokenParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    /// <summary>
    /// Duration for token expiration. Accepts various time formats: - "2 hours" -
    /// 2 hours from now - "1d" - 1 day - "10h" - 10 hours - "2.5 hrs" - 2.5 hours
    /// - "1m" - 1 minute - "5s" - 5 seconds - "1y" - 1 year
    /// </summary>
    public required string ExpiresIn
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("expires_in", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'expires_in' cannot be null",
                    new ArgumentOutOfRangeException("expires_in", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'expires_in' cannot be null",
                    new ArgumentNullException("expires_in")
                );
        }
        init
        {
            this._bodyProperties["expires_in"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Space-separated list of scopes that define what the token can access. Common
    /// scopes include: Inbox Auth: - user_id:<user-id> - Access to a specific user
    /// (multiple can be listed) - read:messages - Read messages (requires user_id
    /// scope) - inbox:read:messages - Read inbox messages - inbox:write:events -
    /// Write inbox events (mark as read, etc.) Preferences Auth: - read:preferences
    /// - Read user preferences - write:preferences - Write user preferences Brands
    /// Auth: - read:brands[:<brand_id>] - Read brands (optionally specific brand)
    /// - write:brands[:<brand_id>] - Write brands (optionally specific brand) Example:
    /// "user_id:user123 inbox:read:messages inbox:write:events"
    /// </summary>
    public required string Scope
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("scope", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'scope' cannot be null",
                    new ArgumentOutOfRangeException("scope", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'scope' cannot be null",
                    new ArgumentNullException("scope")
                );
        }
        init
        {
            this._bodyProperties["scope"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public AuthIssueTokenParams() { }

    public AuthIssueTokenParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthIssueTokenParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static AuthIssueTokenParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/auth/issue-token")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
