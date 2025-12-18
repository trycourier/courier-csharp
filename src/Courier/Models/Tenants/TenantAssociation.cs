using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Tenants;

[JsonConverter(typeof(JsonModelConverter<TenantAssociation, TenantAssociationFromRaw>))]
public sealed record class TenantAssociation : JsonModel
{
    /// <summary>
    /// Tenant ID for the association between tenant and user
    /// </summary>
    public required string TenantID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "tenant_id"); }
        init { JsonModel.Set(this._rawData, "tenant_id", value); }
    }

    /// <summary>
    /// Additional metadata to be applied to a user profile when used in a tenant context
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Profile
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "profile"
            );
        }
        init { JsonModel.Set(this._rawData, "profile", value); }
    }

    public ApiEnum<string, global::Courier.Models.Tenants.Type>? Type
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, global::Courier.Models.Tenants.Type>>(
                this.RawData,
                "type"
            );
        }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// User ID for the association between tenant and user
    /// </summary>
    public string? UserID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "user_id"); }
        init { JsonModel.Set(this._rawData, "user_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TenantID;
        _ = this.Profile;
        this.Type?.Validate();
        _ = this.UserID;
    }

    public TenantAssociation() { }

    public TenantAssociation(TenantAssociation tenantAssociation)
        : base(tenantAssociation) { }

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

    /// <inheritdoc cref="TenantAssociationFromRaw.FromRawUnchecked"/>
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

class TenantAssociationFromRaw : IFromRawJson<TenantAssociation>
{
    /// <inheritdoc/>
    public TenantAssociation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TenantAssociation.FromRawUnchecked(rawData);
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
