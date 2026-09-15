using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using TryCourier.Core;

namespace TryCourier.Models.WorkspacePreferences.Topics;

/// <summary>
/// Turn off a topic's digest, leaving the topic itself in place. The template is
/// unlinked and the digest's schedules are removed along with their delivery rules.
/// Equivalent to sending `digest: null` on a topic replace.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TopicDeleteDigestParams : ParamsBase
{
    public required string SectionID { get; init; }

    public string? TopicID { get; init; }

    public TopicDeleteDigestParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopicDeleteDigestParams(TopicDeleteDigestParams topicDeleteDigestParams)
        : base(topicDeleteDigestParams)
    {
        this.SectionID = topicDeleteDigestParams.SectionID;
        this.TopicID = topicDeleteDigestParams.TopicID;
    }
#pragma warning restore CS8618

    public TopicDeleteDigestParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopicDeleteDigestParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string sectionID,
        string topicID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.SectionID = sectionID;
        this.TopicID = topicID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TopicDeleteDigestParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string sectionID,
        string topicID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            sectionID,
            topicID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["SectionID"] = JsonSerializer.SerializeToElement(this.SectionID),
                    ["TopicID"] = JsonSerializer.SerializeToElement(this.TopicID),
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

    public virtual bool Equals(TopicDeleteDigestParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.SectionID.Equals(other.SectionID)
            && (this.TopicID?.Equals(other.TopicID) ?? other.TopicID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/preferences/sections/{0}/topics/{1}/digest",
                    this.SectionID,
                    this.TopicID
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
