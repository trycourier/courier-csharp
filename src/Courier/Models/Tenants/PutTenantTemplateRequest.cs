using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Tenants;

/// <summary>
/// Request body for creating or updating a tenant notification template
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PutTenantTemplateRequest, PutTenantTemplateRequestFromRaw>)
)]
public sealed record class PutTenantTemplateRequest : JsonModel
{
    /// <summary>
    /// Template configuration for creating or updating a tenant notification template
    /// </summary>
    public required TenantTemplateInput Template
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TenantTemplateInput>("template");
        }
        init { this._rawData.Set("template", value); }
    }

    /// <summary>
    /// Whether to publish the template immediately after saving. When true, the template
    /// becomes the active/published version. When false (default), the template is
    /// saved as a draft.
    /// </summary>
    public bool? Published
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("published");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("published", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Template.Validate();
        _ = this.Published;
    }

    public PutTenantTemplateRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PutTenantTemplateRequest(PutTenantTemplateRequest putTenantTemplateRequest)
        : base(putTenantTemplateRequest) { }
#pragma warning restore CS8618

    public PutTenantTemplateRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PutTenantTemplateRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PutTenantTemplateRequestFromRaw.FromRawUnchecked"/>
    public static PutTenantTemplateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PutTenantTemplateRequest(TenantTemplateInput template)
        : this()
    {
        this.Template = template;
    }
}

class PutTenantTemplateRequestFromRaw : IFromRawJson<PutTenantTemplateRequest>
{
    /// <inheritdoc/>
    public PutTenantTemplateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PutTenantTemplateRequest.FromRawUnchecked(rawData);
}
