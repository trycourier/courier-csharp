using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;

namespace Courier.Models.Tenants;

/// <summary>
/// Create or Replace a Tenant
/// </summary>
public sealed record class TenantUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? TenantID { get; init; }

    /// <summary>
    /// Name of the tenant.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawBodyData, "name"); }
        init { JsonModel.Set(this._rawBodyData, "name", value); }
    }

    /// <summary>
    /// Brand to be used for the account when one is not specified by the send call.
    /// </summary>
    public string? BrandID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "brand_id"); }
        init { JsonModel.Set(this._rawBodyData, "brand_id", value); }
    }

    /// <summary>
    /// Defines the preferences used for the tenant when the user hasn't specified
    /// their own.
    /// </summary>
    public DefaultPreferences? DefaultPreferences
    {
        get
        {
            return JsonModel.GetNullableClass<DefaultPreferences>(
                this.RawBodyData,
                "default_preferences"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "default_preferences", value); }
    }

    /// <summary>
    /// Tenant's parent id (if any).
    /// </summary>
    public string? ParentTenantID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "parent_tenant_id"); }
        init { JsonModel.Set(this._rawBodyData, "parent_tenant_id", value); }
    }

    /// <summary>
    /// Arbitrary properties accessible to a template.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Properties
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawBodyData,
                "properties"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "properties", value); }
    }

    /// <summary>
    /// A user profile object merged with user profile on send.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? UserProfile
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawBodyData,
                "user_profile"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "user_profile", value); }
    }

    public TenantUpdateParams() { }

    public TenantUpdateParams(TenantUpdateParams tenantUpdateParams)
        : base(tenantUpdateParams)
    {
        this._rawBodyData = [.. tenantUpdateParams._rawBodyData];
    }

    public TenantUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TenantUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static TenantUpdateParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/tenants/{0}", this.TenantID)
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
