using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Tenants;

[JsonConverter(
    typeof(JsonModelConverter<BaseTemplateTenantAssociation, BaseTemplateTenantAssociationFromRaw>)
)]
public sealed record class BaseTemplateTenantAssociation : JsonModel
{
    /// <summary>
    /// The template's id
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The timestamp at which the template was created
    /// </summary>
    public required string CreatedAt
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "created_at"); }
        init { JsonModel.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// The timestamp at which the template was published
    /// </summary>
    public required string PublishedAt
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "published_at"); }
        init { JsonModel.Set(this._rawData, "published_at", value); }
    }

    /// <summary>
    /// The timestamp at which the template was last updated
    /// </summary>
    public required string UpdatedAt
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "updated_at"); }
        init { JsonModel.Set(this._rawData, "updated_at", value); }
    }

    /// <summary>
    /// The version of the template
    /// </summary>
    public required string Version
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "version"); }
        init { JsonModel.Set(this._rawData, "version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.PublishedAt;
        _ = this.UpdatedAt;
        _ = this.Version;
    }

    public BaseTemplateTenantAssociation() { }

    public BaseTemplateTenantAssociation(
        BaseTemplateTenantAssociation baseTemplateTenantAssociation
    )
        : base(baseTemplateTenantAssociation) { }

    public BaseTemplateTenantAssociation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BaseTemplateTenantAssociation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BaseTemplateTenantAssociationFromRaw.FromRawUnchecked"/>
    public static BaseTemplateTenantAssociation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BaseTemplateTenantAssociationFromRaw : IFromRawJson<BaseTemplateTenantAssociation>
{
    /// <inheritdoc/>
    public BaseTemplateTenantAssociation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BaseTemplateTenantAssociation.FromRawUnchecked(rawData);
}
