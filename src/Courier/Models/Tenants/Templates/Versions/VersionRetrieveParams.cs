using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Courier.Core;

namespace Courier.Models.Tenants.Templates.Versions;

/// <summary>
/// Fetches a specific version of a tenant template.
///
/// <para>Supports the following version formats: - `latest` - The most recent version
/// of the template - `published` - The currently published version - `v{version}`
/// - A specific version (e.g., "v1", "v2", "v1.0.0")</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VersionRetrieveParams : ParamsBase
{
    public required string TenantID { get; init; }

    public required string TemplateID { get; init; }

    public string? Version { get; init; }

    public VersionRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionRetrieveParams(VersionRetrieveParams versionRetrieveParams)
        : base(versionRetrieveParams)
    {
        this.TenantID = versionRetrieveParams.TenantID;
        this.TemplateID = versionRetrieveParams.TemplateID;
        this.Version = versionRetrieveParams.Version;
    }
#pragma warning restore CS8618

    public VersionRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static VersionRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["TenantID"] = this.TenantID,
                ["TemplateID"] = this.TemplateID,
                ["Version"] = this.Version,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(VersionRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.TenantID.Equals(other.TenantID)
            && this.TemplateID.Equals(other.TemplateID)
            && (this.Version?.Equals(other.Version) ?? other.Version == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/tenants/{0}/templates/{1}/versions/{2}",
                    this.TenantID,
                    this.TemplateID,
                    this.Version
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
