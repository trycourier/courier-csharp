using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;

namespace Courier.Models.Audiences;

/// <summary>
/// Creates or updates audience.
/// </summary>
public sealed record class AudienceUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? AudienceID { get; init; }

    /// <summary>
    /// A description of the audience
    /// </summary>
    public string? Description
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "description"); }
        init { JsonModel.Set(this._rawBodyData, "description", value); }
    }

    /// <summary>
    /// A single filter to use for filtering
    /// </summary>
    public Filter? Filter
    {
        get { return JsonModel.GetNullableClass<Filter>(this.RawBodyData, "filter"); }
        init { JsonModel.Set(this._rawBodyData, "filter", value); }
    }

    /// <summary>
    /// The name of the audience
    /// </summary>
    public string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "name"); }
        init { JsonModel.Set(this._rawBodyData, "name", value); }
    }

    public AudienceUpdateParams() { }

    public AudienceUpdateParams(AudienceUpdateParams audienceUpdateParams)
        : base(audienceUpdateParams)
    {
        this._rawBodyData = [.. audienceUpdateParams._rawBodyData];
    }

    public AudienceUpdateParams(
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
    AudienceUpdateParams(
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
    public static AudienceUpdateParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/audiences/{0}", this.AudienceID)
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
