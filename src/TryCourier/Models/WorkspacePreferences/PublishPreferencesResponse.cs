using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.WorkspacePreferences;

/// <summary>
/// Result of publishing the workspace's preferences page.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PublishPreferencesResponse, PublishPreferencesResponseFromRaw>)
)]
public sealed record class PublishPreferencesResponse : JsonModel
{
    /// <summary>
    /// Id of the published page snapshot.
    /// </summary>
    public required string PageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("page_id");
        }
        init { this._rawData.Set("page_id", value); }
    }

    /// <summary>
    /// ISO-8601 timestamp of the publish.
    /// </summary>
    public required string PublishedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("published_at");
        }
        init { this._rawData.Set("published_at", value); }
    }

    /// <summary>
    /// Monotonic published version (epoch milliseconds).
    /// </summary>
    public required double PublishedVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("published_version");
        }
        init { this._rawData.Set("published_version", value); }
    }

    /// <summary>
    /// Draft-mode hosted preferences page URL for previewing.
    /// </summary>
    public string? PreviewUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("preview_url");
        }
        init { this._rawData.Set("preview_url", value); }
    }

    /// <summary>
    /// Id of the publisher.
    /// </summary>
    public string? PublishedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("published_by");
        }
        init { this._rawData.Set("published_by", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PageID;
        _ = this.PublishedAt;
        _ = this.PublishedVersion;
        _ = this.PreviewUrl;
        _ = this.PublishedBy;
    }

    public PublishPreferencesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PublishPreferencesResponse(PublishPreferencesResponse publishPreferencesResponse)
        : base(publishPreferencesResponse) { }
#pragma warning restore CS8618

    public PublishPreferencesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PublishPreferencesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PublishPreferencesResponseFromRaw.FromRawUnchecked"/>
    public static PublishPreferencesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PublishPreferencesResponseFromRaw : IFromRawJson<PublishPreferencesResponse>
{
    /// <inheritdoc/>
    public PublishPreferencesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PublishPreferencesResponse.FromRawUnchecked(rawData);
}
