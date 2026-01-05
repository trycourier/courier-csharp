using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Courier.Core;

namespace Courier.Models.Users.Preferences;

/// <summary>
/// Fetch user preferences for a specific subscription topic.
/// </summary>
public sealed record class PreferenceRetrieveTopicParams : ParamsBase
{
    public required string UserID { get; init; }

    public string? TopicID { get; init; }

    /// <summary>
    /// Query the preferences of a user for this specific tenant context.
    /// </summary>
    public string? TenantID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "tenant_id"); }
        init { JsonModel.Set(this._rawQueryData, "tenant_id", value); }
    }

    public PreferenceRetrieveTopicParams() { }

    public PreferenceRetrieveTopicParams(
        PreferenceRetrieveTopicParams preferenceRetrieveTopicParams
    )
        : base(preferenceRetrieveTopicParams) { }

    public PreferenceRetrieveTopicParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceRetrieveTopicParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static PreferenceRetrieveTopicParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/users/{0}/preferences/{1}", this.UserID, this.TopicID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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
