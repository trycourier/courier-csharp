using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        get { return this._rawData.GetNotNullStruct<bool>("has_more"); }
        init { this._rawData.Set("has_more", value); }
    }

    /// <summary>
    /// An array of Tenants
    /// </summary>
    public required IReadOnlyList<Tenant> Items
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<Tenant>>("items"); }
        init
        {
            this._rawData.Set<ImmutableArray<Tenant>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Always set to "list". Represents the type of this object.
    /// </summary>
    public required ApiEnum<string, TenantListResponseType> Type
    {
        get
        {
            return this._rawData.GetNotNullClass<ApiEnum<string, TenantListResponseType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// A url that may be used to generate these results.
    /// </summary>
    public required string Url
    {
        get { return this._rawData.GetNotNullClass<string>("url"); }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// A pointer to the next page of results. Defined only when has_more is set
    /// to true.
    /// </summary>
    public string? Cursor
    {
        get { return this._rawData.GetNullableClass<string>("cursor"); }
        init { this._rawData.Set("cursor", value); }
    }

    /// <summary>
    /// A url that may be used to generate fetch the next set of results.  Defined
    /// only when has_more is set to true
    /// </summary>
    public string? NextUrl
    {
        get { return this._rawData.GetNullableClass<string>("next_url"); }
        init { this._rawData.Set("next_url", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TenantListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
