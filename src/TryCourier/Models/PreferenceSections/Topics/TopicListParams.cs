using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using TryCourier.Core;

namespace TryCourier.Models.PreferenceSections.Topics;

/// <summary>
/// List the topics in a preference section.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TopicListParams : ParamsBase
{
    public string? SectionID { get; init; }

    public TopicListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopicListParams(TopicListParams topicListParams)
        : base(topicListParams)
    {
        this.SectionID = topicListParams.SectionID;
    }
#pragma warning restore CS8618

    public TopicListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopicListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string sectionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.SectionID = sectionID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TopicListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string sectionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            sectionID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["SectionID"] = JsonSerializer.SerializeToElement(this.SectionID),
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

    public virtual bool Equals(TopicListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.SectionID?.Equals(other.SectionID) ?? other.SectionID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/preferences/sections/{0}/topics", this.SectionID)
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
