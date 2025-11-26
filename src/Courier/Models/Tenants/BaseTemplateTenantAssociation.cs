using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Tenants;

[JsonConverter(
    typeof(ModelConverter<BaseTemplateTenantAssociation, BaseTemplateTenantAssociationFromRaw>)
)]
public sealed record class BaseTemplateTenantAssociation : ModelBase
{
    /// <summary>
    /// The template's id
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp at which the template was created
    /// </summary>
    public required string CreatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("created_at", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentNullException("created_at")
                );
        }
        init
        {
            this._rawData["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp at which the template was published
    /// </summary>
    public required string PublishedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("published_at", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'published_at' cannot be null",
                    new ArgumentOutOfRangeException("published_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'published_at' cannot be null",
                    new ArgumentNullException("published_at")
                );
        }
        init
        {
            this._rawData["published_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The timestamp at which the template was last updated
    /// </summary>
    public required string UpdatedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("updated_at", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'updated_at' cannot be null",
                    new ArgumentOutOfRangeException("updated_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'updated_at' cannot be null",
                    new ArgumentNullException("updated_at")
                );
        }
        init
        {
            this._rawData["updated_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The version of the template
    /// </summary>
    public required string Version
    {
        get
        {
            if (!this._rawData.TryGetValue("version", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'version' cannot be null",
                    new ArgumentOutOfRangeException("version", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'version' cannot be null",
                    new ArgumentNullException("version")
                );
        }
        init
        {
            this._rawData["version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.PublishedAt;
        _ = this.UpdatedAt;
        _ = this.Version;
    }

    public BaseTemplateTenantAssociation() { }

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

    public static BaseTemplateTenantAssociation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BaseTemplateTenantAssociationFromRaw : IFromRaw<BaseTemplateTenantAssociation>
{
    public BaseTemplateTenantAssociation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BaseTemplateTenantAssociation.FromRawUnchecked(rawData);
}
