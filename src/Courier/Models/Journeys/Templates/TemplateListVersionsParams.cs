using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Courier.Core;

namespace Courier.Models.Journeys.Templates;

/// <summary>
/// List published versions of the journey-scoped notification template, ordered most
/// recent first.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TemplateListVersionsParams : ParamsBase
{
    public required string TemplateID { get; init; }

    public string? NotificationID { get; init; }

    public TemplateListVersionsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateListVersionsParams(TemplateListVersionsParams templateListVersionsParams)
        : base(templateListVersionsParams)
    {
        this.TemplateID = templateListVersionsParams.TemplateID;
        this.NotificationID = templateListVersionsParams.NotificationID;
    }
#pragma warning restore CS8618

    public TemplateListVersionsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateListVersionsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string templateID,
        string notificationID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.TemplateID = templateID;
        this.NotificationID = notificationID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TemplateListVersionsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string templateID,
        string notificationID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            templateID,
            notificationID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["TemplateID"] = JsonSerializer.SerializeToElement(this.TemplateID),
                    ["NotificationID"] = JsonSerializer.SerializeToElement(this.NotificationID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TemplateListVersionsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.TemplateID.Equals(other.TemplateID)
            && (this.NotificationID?.Equals(other.NotificationID) ?? other.NotificationID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/journeys/{0}/templates/{1}/versions",
                    this.TemplateID,
                    this.NotificationID
                )
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

    public override int GetHashCode()
    {
        return 0;
    }
}
