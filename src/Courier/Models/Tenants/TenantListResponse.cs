using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Tenants;

[JsonConverter(typeof(JsonModelConverter<TenantListResponse, TenantListResponseFromRaw>))]
public sealed record class TenantListResponse : JsonModel
{
    /// <summary>
    /// Set to true when there are more pages that can be retrieved.
    /// </summary>
    public required bool HasMore
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "has_more"); }
        init { JsonModel.Set(this._rawData, "has_more", value); }
    }

    /// <summary>
    /// An array of Tenants
    /// </summary>
    public required IReadOnlyList<Tenant> Items
    {
        get { return JsonModel.GetNotNullClass<List<Tenant>>(this.RawData, "items"); }
        init { JsonModel.Set(this._rawData, "items", value); }
    }

    /// <summary>
    /// Always set to "list". Represents the type of this object.
    /// </summary>
    public required ApiEnum<string, TenantListResponseType> Type
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, TenantListResponseType>>(
                this.RawData,
                "type"
            );
        }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// A url that may be used to generate these results.
    /// </summary>
    public required string Url
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "url"); }
        init { JsonModel.Set(this._rawData, "url", value); }
    }

    /// <summary>
    /// A pointer to the next page of results. Defined only when has_more is set
    /// to true.
    /// </summary>
    public string? Cursor
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "cursor"); }
        init { JsonModel.Set(this._rawData, "cursor", value); }
    }

    /// <summary>
    /// A url that may be used to generate fetch the next set of results.  Defined
    /// only when has_more is set to true
    /// </summary>
    public string? NextUrl
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "next_url"); }
        init { JsonModel.Set(this._rawData, "next_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasMore;
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        this.Type.Validate();
        _ = this.Url;
        _ = this.Cursor;
        _ = this.NextUrl;
    }

    public TenantListResponse() { }

    public TenantListResponse(TenantListResponse tenantListResponse)
        : base(tenantListResponse) { }

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

class TenantListResponseFromRaw : IFromRawJson<TenantListResponse>
{
    /// <inheritdoc/>
    public TenantListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TenantListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Always set to "list". Represents the type of this object.
/// </summary>
[JsonConverter(typeof(TenantListResponseTypeConverter))]
public enum TenantListResponseType
{
    List,
}

sealed class TenantListResponseTypeConverter : JsonConverter<TenantListResponseType>
{
    public override TenantListResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "list" => TenantListResponseType.List,
            _ => (TenantListResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TenantListResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TenantListResponseType.List => "list",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
