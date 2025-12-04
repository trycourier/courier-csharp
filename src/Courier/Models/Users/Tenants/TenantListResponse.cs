using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;
using Tenants = Courier.Models.Tenants;

namespace Courier.Models.Users.Tenants;

[JsonConverter(typeof(ModelConverter<TenantListResponse, TenantListResponseFromRaw>))]
public sealed record class TenantListResponse : ModelBase
{
    /// <summary>
    /// Set to true when there are more pages that can be retrieved.
    /// </summary>
    public required bool HasMore
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "has_more"); }
        init { ModelBase.Set(this._rawData, "has_more", value); }
    }

    /// <summary>
    /// Always set to `list`. Represents the type of this object.
    /// </summary>
    public required ApiEnum<string, global::Courier.Models.Users.Tenants.Type> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::Courier.Models.Users.Tenants.Type>
            >(this.RawData, "type");
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// A url that may be used to generate these results.
    /// </summary>
    public required string URL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "url"); }
        init { ModelBase.Set(this._rawData, "url", value); }
    }

    /// <summary>
    /// A pointer to the next page of results. Defined  only when `has_more` is set
    /// to true
    /// </summary>
    public string? Cursor
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "cursor"); }
        init { ModelBase.Set(this._rawData, "cursor", value); }
    }

    public IReadOnlyList<Tenants::TenantAssociation>? Items
    {
        get
        {
            return ModelBase.GetNullableClass<List<Tenants::TenantAssociation>>(
                this.RawData,
                "items"
            );
        }
        init { ModelBase.Set(this._rawData, "items", value); }
    }

    /// <summary>
    /// A url that may be used to generate fetch the next set of results.  Defined
    /// only when `has_more` is set to true
    /// </summary>
    public string? NextURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "next_url"); }
        init { ModelBase.Set(this._rawData, "next_url", value); }
    }

    /// <inheritdoc/>
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

    public TenantListResponse() { }

    public TenantListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TenantListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TenantListResponseFromRaw.FromRawUnchecked"/>
    public static TenantListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TenantListResponseFromRaw : IFromRaw<TenantListResponse>
{
    /// <inheritdoc/>
    public TenantListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TenantListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Always set to `list`. Represents the type of this object.
/// </summary>
[JsonConverter(typeof(global::Courier.Models.Users.Tenants.TypeConverter))]
public enum Type
{
    List,
}

sealed class TypeConverter : JsonConverter<global::Courier.Models.Users.Tenants.Type>
{
    public override global::Courier.Models.Users.Tenants.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "list" => global::Courier.Models.Users.Tenants.Type.List,
            _ => (global::Courier.Models.Users.Tenants.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Courier.Models.Users.Tenants.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Courier.Models.Users.Tenants.Type.List => "list",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
