using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Tenants;

/// <summary>
/// Response from creating or updating a tenant notification template
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PutTenantTemplateResponse, PutTenantTemplateResponseFromRaw>)
)]
public sealed record class PutTenantTemplateResponse : JsonModel
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
    /// The version of the saved template
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

    /// <summary>
    /// The timestamp when the template was published. Only present if the template
    /// was published as part of this request.
    /// </summary>
    public string? PublishedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("published_at");
        }
        init { this._rawData.Set("published_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Version;
        _ = this.PublishedAt;
    }

    public PutTenantTemplateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PutTenantTemplateResponse(PutTenantTemplateResponse putTenantTemplateResponse)
        : base(putTenantTemplateResponse) { }
#pragma warning restore CS8618

    public PutTenantTemplateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PutTenantTemplateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PutTenantTemplateResponseFromRaw.FromRawUnchecked"/>
    public static PutTenantTemplateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PutTenantTemplateResponseFromRaw : IFromRawJson<PutTenantTemplateResponse>
{
    /// <inheritdoc/>
    public PutTenantTemplateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PutTenantTemplateResponse.FromRawUnchecked(rawData);
}
