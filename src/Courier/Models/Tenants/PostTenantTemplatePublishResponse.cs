using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Tenants;

/// <summary>
/// Response from publishing a tenant template
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PostTenantTemplatePublishResponse,
        PostTenantTemplatePublishResponseFromRaw
    >)
)]
public sealed record class PostTenantTemplatePublishResponse : JsonModel
{
    /// <summary>
    /// The template ID
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The timestamp when the template was published
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
    /// The published version of the template
    /// </summary>
    public required string Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.PublishedAt;
        _ = this.Version;
    }

    public PostTenantTemplatePublishResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostTenantTemplatePublishResponse(
        PostTenantTemplatePublishResponse postTenantTemplatePublishResponse
    )
        : base(postTenantTemplatePublishResponse) { }
#pragma warning restore CS8618

    public PostTenantTemplatePublishResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PostTenantTemplatePublishResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PostTenantTemplatePublishResponseFromRaw.FromRawUnchecked"/>
    public static PostTenantTemplatePublishResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PostTenantTemplatePublishResponseFromRaw : IFromRawJson<PostTenantTemplatePublishResponse>
{
    /// <inheritdoc/>
    public PostTenantTemplatePublishResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PostTenantTemplatePublishResponse.FromRawUnchecked(rawData);
}
