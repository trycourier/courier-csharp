using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Generic = System.Collections.Generic;
using TenantListResponseProperties = Courier.Models.Tenants.TenantListResponseProperties;

namespace Courier.Models.Tenants;

[JsonConverter(typeof(ModelConverter<TenantListResponse>))]
public sealed record class TenantListResponse : ModelBase, IFromRaw<TenantListResponse>
{
    /// <summary>
    /// Set to true when there are more pages that can be retrieved.
    /// </summary>
    public required bool HasMore
    {
        get
        {
            if (!this.Properties.TryGetValue("has_more", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'has_more' cannot be null",
                    new ArgumentOutOfRangeException("has_more", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["has_more"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An array of Tenants
    /// </summary>
    public required Generic::List<Tenant> Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentOutOfRangeException("items", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Generic::List<Tenant>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentNullException("items")
                );
        }
        set
        {
            this.Properties["items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Always set to "list". Represents the type of this object.
    /// </summary>
    public required ApiEnum<string, TenantListResponseProperties::Type> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TenantListResponseProperties::Type>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A url that may be used to generate these results.
    /// </summary>
    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'url' cannot be null",
                    new ArgumentOutOfRangeException("url", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'url' cannot be null",
                    new ArgumentNullException("url")
                );
        }
        set
        {
            this.Properties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A pointer to the next page of results. Defined only when has_more is set to true.
    /// </summary>
    public string? Cursor
    {
        get
        {
            if (!this.Properties.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["cursor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A url that may be used to generate fetch the next set of results.  Defined
    /// only when has_more is set to true
    /// </summary>
    public string? NextURL
    {
        get
        {
            if (!this.Properties.TryGetValue("next_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["next_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.HasMore;
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        this.Type.Validate();
        _ = this.URL;
        _ = this.Cursor;
        _ = this.NextURL;
    }

    public TenantListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TenantListResponse(Generic::Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TenantListResponse FromRawUnchecked(
        Generic::Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
