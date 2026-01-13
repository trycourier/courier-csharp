using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Automations;

/// <summary>
/// Get the list of automations.
/// </summary>
public sealed record class AutomationListParams : ParamsBase
{
    /// <summary>
    /// A cursor token for pagination. Use the cursor from the previous response
    /// to fetch the next page of results.
    /// </summary>
    public string? Cursor
    {
        get { return this._rawQueryData.GetNullableClass<string>("cursor"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    /// <summary>
    /// The version of templates to retrieve. Accepted values are published (for published
    /// templates) or draft (for draft templates). Defaults to published.
    /// </summary>
    public ApiEnum<string, Version>? Version
    {
        get { return this._rawQueryData.GetNullableClass<ApiEnum<string, Version>>("version"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("version", value);
        }
    }

    public AutomationListParams() { }

    public AutomationListParams(AutomationListParams automationListParams)
        : base(automationListParams) { }

    public AutomationListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static AutomationListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/automations")
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

/// <summary>
/// The version of templates to retrieve. Accepted values are published (for published
/// templates) or draft (for draft templates). Defaults to published.
/// </summary>
[JsonConverter(typeof(VersionConverter))]
public enum Version
{
    Published,
    Draft,
}

sealed class VersionConverter : JsonConverter<Version>
{
    public override Version Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "published" => Version.Published,
            "draft" => Version.Draft,
            _ => (Version)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Version value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Version.Published => "published",
                Version.Draft => "draft",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
