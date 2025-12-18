using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Users.Tokens;

/// <summary>
/// Apply a JSON Patch (RFC 6902) to the specified token.
/// </summary>
public sealed record class TokenUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string UserID { get; init; }

    public string? Token { get; init; }

    public required IReadOnlyList<Patch> Patch
    {
        get { return JsonModel.GetNotNullClass<List<Patch>>(this.RawBodyData, "patch"); }
        init { JsonModel.Set(this._rawBodyData, "patch", value); }
    }

    public TokenUpdateParams() { }

    public TokenUpdateParams(TokenUpdateParams tokenUpdateParams)
        : base(tokenUpdateParams)
    {
        this._rawBodyData = [.. tokenUpdateParams._rawBodyData];
    }

    public TokenUpdateParams(
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
    TokenUpdateParams(
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
    public static TokenUpdateParams FromRawUnchecked(
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
                + string.Format("/users/{0}/tokens/{1}", this.UserID, this.Token)
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

[JsonConverter(typeof(JsonModelConverter<Patch, PatchFromRaw>))]
public sealed record class Patch : JsonModel
{
    /// <summary>
    /// The operation to perform.
    /// </summary>
    public required string Op
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "op"); }
        init { JsonModel.Set(this._rawData, "op", value); }
    }

    /// <summary>
    /// The JSON path specifying the part of the profile to operate on.
    /// </summary>
    public required string Path
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "path"); }
        init { JsonModel.Set(this._rawData, "path", value); }
    }

    /// <summary>
    /// The value for the operation.
    /// </summary>
    public string? Value
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "value"); }
        init { JsonModel.Set(this._rawData, "value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Op;
        _ = this.Path;
        _ = this.Value;
    }

    public Patch() { }

    public Patch(Patch patch)
        : base(patch) { }

    public Patch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Patch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PatchFromRaw.FromRawUnchecked"/>
    public static Patch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PatchFromRaw : IFromRawJson<Patch>
{
    /// <inheritdoc/>
    public Patch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Patch.FromRawUnchecked(rawData);
}
