using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;

namespace Courier.Models.Profiles;

/// <summary>
/// When using `PUT`, be sure to include all the key-value pairs required by the
/// recipient's profile.  Any key-value pairs that exist in the profile but fail
/// to be included in the `PUT` request will be  removed from the profile. Remember,
/// a `PUT` update is a full replacement of the data. For partial updates,  use the
/// [Patch](https://www.courier.com/docs/reference/profiles/patch/) request.
/// </summary>
public sealed record class ProfileReplaceParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? UserID { get; init; }

    public required IReadOnlyDictionary<string, JsonElement> Profile
    {
        get
        {
            return this._rawBodyData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "profile"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>>(
                "profile",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public ProfileReplaceParams() { }

    public ProfileReplaceParams(ProfileReplaceParams profileReplaceParams)
        : base(profileReplaceParams)
    {
        this.UserID = profileReplaceParams.UserID;

        this._rawBodyData = new(profileReplaceParams._rawBodyData);
    }

    public ProfileReplaceParams(
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
    ProfileReplaceParams(
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
    public static ProfileReplaceParams FromRawUnchecked(
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/profiles/{0}", this.UserID)
        )
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
