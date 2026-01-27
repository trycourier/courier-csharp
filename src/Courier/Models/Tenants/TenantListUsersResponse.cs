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

[JsonConverter(typeof(JsonModelConverter<TenantListUsersResponse, TenantListUsersResponseFromRaw>))]
public sealed record class TenantListUsersResponse : JsonModel
{
    /// <summary>
    /// Set to true when there are more pages that can be retrieved.
    /// </summary>
    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_more");
        }
        init { this._rawData.Set("has_more", value); }
    }

    /// <summary>
    /// Always set to `list`. Represents the type of this object.
    /// </summary>
    public required ApiEnum<string, TenantListUsersResponseType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TenantListUsersResponseType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// A url that may be used to generate these results.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// A pointer to the next page of results. Defined  only when `has_more` is set
    /// to true
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("cursor");
        }
        init { this._rawData.Set("cursor", value); }
    }

    public IReadOnlyList<TenantAssociation>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TenantAssociation>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TenantAssociation>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A url that may be used to generate fetch the next set of results.  Defined
    /// only when `has_more` is set to true
    /// </summary>
    public string? NextUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_url");
        }
        init { this._rawData.Set("next_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasMore;
        this.Type.Validate();
        _ = this.Url;
        _ = this.Cursor;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.NextUrl;
    }

    public TenantListUsersResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TenantListUsersResponse(TenantListUsersResponse tenantListUsersResponse)
        : base(tenantListUsersResponse) { }
#pragma warning restore CS8618

    public TenantListUsersResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TenantListUsersResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TenantListUsersResponseFromRaw.FromRawUnchecked"/>
    public static TenantListUsersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TenantListUsersResponseFromRaw : IFromRawJson<TenantListUsersResponse>
{
    /// <inheritdoc/>
    public TenantListUsersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TenantListUsersResponse.FromRawUnchecked(rawData);
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
