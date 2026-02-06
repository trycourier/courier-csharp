using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Tenants;

/// <summary>
/// Request body for publishing a tenant template version
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PostTenantTemplatePublishRequest,
        PostTenantTemplatePublishRequestFromRaw
    >)
)]
public sealed record class PostTenantTemplatePublishRequest : JsonModel
{
    /// <summary>
    /// The version of the template to publish (e.g., "v1", "v2", "latest"). If not
    /// provided, defaults to "latest".
    /// </summary>
    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Version;
    }

    public PostTenantTemplatePublishRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PostTenantTemplatePublishRequest(
        PostTenantTemplatePublishRequest postTenantTemplatePublishRequest
    )
        : base(postTenantTemplatePublishRequest) { }
#pragma warning restore CS8618

    public PostTenantTemplatePublishRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PostTenantTemplatePublishRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PostTenantTemplatePublishRequestFromRaw.FromRawUnchecked"/>
    public static PostTenantTemplatePublishRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PostTenantTemplatePublishRequestFromRaw : IFromRawJson<PostTenantTemplatePublishRequest>
{
    /// <inheritdoc/>
    public PostTenantTemplatePublishRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PostTenantTemplatePublishRequest.FromRawUnchecked(rawData);
}
