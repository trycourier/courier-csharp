using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Tenants;

[JsonConverter(typeof(ModelConverter<TenantListUsersResponse>))]
public sealed record class TenantListUsersResponse : ModelBase, IFromRaw<TenantListUsersResponse>
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
                    new System::ArgumentOutOfRangeException("has_more", "Missing required argument")
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
    /// Always set to `list`. Represents the type of this object.
    /// </summary>
    public required ApiEnum<string, global::Courier.Models.Tenants.Type1> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Courier.Models.Tenants.Type1>
            >(element, ModelBase.SerializerOptions);
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
                    new System::ArgumentOutOfRangeException("url", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'url' cannot be null",
                    new System::ArgumentNullException("url")
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
    /// A pointer to the next page of results. Defined  only when `has_more` is set
    /// to true
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

    public List<TenantAssociation>? Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<TenantAssociation>?>(
                element,
                ModelBase.SerializerOptions
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
    /// A url that may be used to generate fetch the next set of results.  Defined
    /// only when `has_more` is set to true
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
        this.Type.Validate();
        _ = this.URL;
        _ = this.Cursor;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.NextURL;
    }

    public TenantListUsersResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TenantListUsersResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TenantListUsersResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

/// <summary>
/// Always set to `list`. Represents the type of this object.
/// </summary>
[JsonConverter(typeof(global::Courier.Models.Tenants.Type1Converter))]
public enum Type1
{
    List,
}

sealed class Type1Converter : JsonConverter<global::Courier.Models.Tenants.Type1>
{
    public override global::Courier.Models.Tenants.Type1 Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "list" => global::Courier.Models.Tenants.Type1.List,
            _ => (global::Courier.Models.Tenants.Type1)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Courier.Models.Tenants.Type1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Courier.Models.Tenants.Type1.List => "list",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
