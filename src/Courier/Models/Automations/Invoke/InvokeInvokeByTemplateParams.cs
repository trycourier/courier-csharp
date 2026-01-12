using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Courier.Core;

namespace Courier.Models.Automations.Invoke;

/// <summary>
/// Invoke an automation run from an automation template.
/// </summary>
public sealed record class InvokeInvokeByTemplateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? TemplateID { get; init; }

    public required string? Recipient
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "recipient"); }
        init { JsonModel.Set(this._rawBodyData, "recipient", value); }
    }

    public string? Brand
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "brand"); }
        init { JsonModel.Set(this._rawBodyData, "brand", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawBodyData,
                "data"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "data", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Profile
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawBodyData,
                "profile"
            );
        }
        init { JsonModel.Set(this._rawBodyData, "profile", value); }
    }

    public string? Template
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "template"); }
        init { JsonModel.Set(this._rawBodyData, "template", value); }
    }

    public InvokeInvokeByTemplateParams() { }

    public InvokeInvokeByTemplateParams(InvokeInvokeByTemplateParams invokeInvokeByTemplateParams)
        : base(invokeInvokeByTemplateParams)
    {
        this.TemplateID = invokeInvokeByTemplateParams.TemplateID;

        this._rawBodyData = [.. invokeInvokeByTemplateParams._rawBodyData];
    }

    public InvokeInvokeByTemplateParams(
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
    InvokeInvokeByTemplateParams(
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
    public static InvokeInvokeByTemplateParams FromRawUnchecked(
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
                + string.Format("/automations/{0}/invoke", this.TemplateID)
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
