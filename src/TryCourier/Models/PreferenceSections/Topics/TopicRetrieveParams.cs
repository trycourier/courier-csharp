using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using TryCourier.Core;

namespace TryCourier.Models.PreferenceSections.Topics;

/// <summary>
/// Retrieve a topic within a section. Returns 404 if the section does not exist,
/// the topic does not exist, or the topic belongs to a different section.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TopicRetrieveParams : ParamsBase
{
    public required string SectionID { get; init; }

    public string? TopicID { get; init; }

    public TopicRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopicRetrieveParams(TopicRetrieveParams topicRetrieveParams)
        : base(topicRetrieveParams)
    {
        this.SectionID = topicRetrieveParams.SectionID;
        this.TopicID = topicRetrieveParams.TopicID;
    }
#pragma warning restore CS8618

    public TopicRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopicRetrieveParams(
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
    public static TopicRetrieveParams FromRawUnchecked(
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

    public virtual bool Equals(TopicRetrieveParams? other)
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
                    "/preferences/sections/{0}/topics/{1}",
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
