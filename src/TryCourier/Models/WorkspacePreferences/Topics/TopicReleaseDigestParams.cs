using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using TryCourier.Core;

namespace TryCourier.Models.WorkspacePreferences.Topics;

/// <summary>
/// Send one recipient's held digest now, instead of waiting for its schedule. Use
/// it to preview what a digest will look like, or to let someone flush their own.
///
/// <para>Keyed on the topic because that is how a held digest is stored: one per
/// recipient per topic, with the schedule recorded on it rather than part of its
/// identity. To flush every recipient on a schedule instead, use `POST /digests/schedules/{schedule_id}/trigger`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TopicReleaseDigestParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string SectionID { get; init; }

    public string? TopicID { get; init; }

    /// <summary>
    /// The recipient whose digest to release. Required: there is no "release everyone
    /// on this topic" form, because a whole-schedule flush already has its own endpoint
    /// and a body-shaped difference between one recipient and all of them is too
    /// easy to get wrong.
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("user_id");
        }
        init { this._rawBodyData.Set("user_id", value); }
    }

    /// <summary>
    /// The recipient's tenant, when they were sent to as part of one -- the same
    /// value returned as `tenant_id` on a digest instance and sent as `message.context.tenant_id`.
    /// It is part of the held digest's key, so a tenanted recipient cannot be found
    /// without it. Omit for an ordinary recipient.
    /// </summary>
    public string? TenantID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("tenant_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("tenant_id", value);
        }
    }

    public TopicReleaseDigestParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopicReleaseDigestParams(TopicReleaseDigestParams topicReleaseDigestParams)
        : base(topicReleaseDigestParams)
    {
        this.SectionID = topicReleaseDigestParams.SectionID;
        this.TopicID = topicReleaseDigestParams.TopicID;

        this._rawBodyData = new(topicReleaseDigestParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TopicReleaseDigestParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopicReleaseDigestParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string sectionID,
        string topicID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.SectionID = sectionID;
        this.TopicID = topicID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TopicReleaseDigestParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string sectionID,
        string topicID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TopicReleaseDigestParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.SectionID.Equals(other.SectionID)
            && (this.TopicID?.Equals(other.TopicID) ?? other.TopicID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/preferences/sections/{0}/topics/{1}/digest/release",
                    this.SectionID,
                    this.TopicID
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
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

    public override int GetHashCode()
    {
        return 0;
    }
}
