using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Tenants;

[JsonConverter(typeof(ModelConverter<TenantAssociation>))]
public sealed record class TenantAssociation : ModelBase, IFromRaw<TenantAssociation>
{
    /// <summary>
    /// Tenant ID for the association between tenant and user
    /// </summary>
    public required string TenantID
    {
        get
        {
            if (!this._rawData.TryGetValue("tenant_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'tenant_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tenant_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'tenant_id' cannot be null",
                    new System::ArgumentNullException("tenant_id")
                );
        }
        init
        {
            this._rawData["tenant_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional metadata to be applied to a user profile when used in a tenant context
    /// </summary>
    public Dictionary<string, JsonElement>? Profile
    {
        get
        {
            if (!this._rawData.TryGetValue("profile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["profile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, global::Courier.Models.Tenants.Type>? Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                global::Courier.Models.Tenants.Type
            >?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// User ID for the association between tenant and user
    /// </summary>
    public string? UserID
    {
        get
        {
            if (!this._rawData.TryGetValue("user_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["user_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.TenantID;
        _ = this.Profile;
        this.Type?.Validate();
        _ = this.UserID;
    }

    public TenantAssociation() { }

    public TenantAssociation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TenantAssociation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static TenantAssociation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TenantAssociation(string tenantID)
        : this()
    {
        this.TenantID = tenantID;
    }
}

[JsonConverter(typeof(global::Courier.Models.Tenants.TypeConverter))]
public enum Type
{
    User,
}

sealed class TypeConverter : JsonConverter<global::Courier.Models.Tenants.Type>
{
    public override global::Courier.Models.Tenants.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => global::Courier.Models.Tenants.Type.User,
            _ => (global::Courier.Models.Tenants.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Courier.Models.Tenants.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Courier.Models.Tenants.Type.User => "user",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
