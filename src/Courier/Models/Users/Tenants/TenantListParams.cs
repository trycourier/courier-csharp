using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Courier.Core;

namespace Courier.Models.Users.Tenants;

/// <summary>
/// Returns a paginated list of user tenant associations.
/// </summary>
public sealed record class TenantListParams : ParamsBase
{
    public string? UserID { get; init; }

    /// <summary>
    /// Continue the pagination with the next cursor
    /// </summary>
    public string? Cursor
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "cursor"); }
        init { ModelBase.Set(this._rawQueryData, "cursor", value); }
    }

    /// <summary>
    /// The number of accounts to return  (defaults to 20, maximum value of 100)
    /// </summary>
    public long? Limit
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "limit"); }
        init { ModelBase.Set(this._rawQueryData, "limit", value); }
    }

    public TenantListParams() { }

    public TenantListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TenantListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static TenantListParams FromRawUnchecked(
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
                + string.Format("/users/{0}/tenants", this.UserID)
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
