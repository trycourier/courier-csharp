using System.Collections.Frozen;
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
            if (!this._properties.TryGetValue("has_more", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'has_more' cannot be null",
                    new System::ArgumentOutOfRangeException("has_more", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["has_more"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Always set to `list`. Represents the type of this object.
    /// </summary>
    public required ApiEnum<string, TenantListUsersResponseType> Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, TenantListUsersResponseType>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("url", out JsonElement element))
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
        init
        {
            this._properties["url"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("cursor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["cursor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<TenantAssociation>? Items
    {
        get
        {
            if (!this._properties.TryGetValue("items", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<TenantAssociation>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["items"] = JsonSerializer.SerializeToElement(
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
            if (!this._properties.TryGetValue("next_url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["next_url"] = JsonSerializer.SerializeToElement(
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

    public TenantListUsersResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TenantListUsersResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static TenantListUsersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

/// <summary>
/// Always set to `list`. Represents the type of this object.
/// </summary>
[JsonConverter(typeof(TenantListUsersResponseTypeConverter))]
public enum TenantListUsersResponseType
{
    List,
}

sealed class TenantListUsersResponseTypeConverter : JsonConverter<TenantListUsersResponseType>
{
    public override TenantListUsersResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "list" => TenantListUsersResponseType.List,
            _ => (TenantListUsersResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TenantListUsersResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TenantListUsersResponseType.List => "list",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
