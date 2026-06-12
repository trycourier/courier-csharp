using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Digests;

[JsonConverter(
    typeof(JsonModelConverter<DigestInstanceListResponse, DigestInstanceListResponseFromRaw>)
)]
public sealed record class DigestInstanceListResponse : JsonModel
{
    /// <summary>
    /// Whether there are more digest instances to fetch using the cursor.
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
    /// The digest instances for this page of results.
    /// </summary>
    public required IReadOnlyList<DigestInstance> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DigestInstance>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DigestInstance>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Always `list` for a paginated list response.
    /// </summary>
    public required ApiEnum<string, global::Courier.Models.Digests.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Courier.Models.Digests.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// A cursor token for fetching the next page of results, or null when there
    /// are none.
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

    /// <summary>
    /// The path to fetch the next page of results, or null when there are none.
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

    /// <summary>
    /// The path of the current request.
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
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
        _ = this.Cursor;
        _ = this.NextUrl;
        _ = this.Url;
    }

    public DigestInstanceListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigestInstanceListResponse(DigestInstanceListResponse digestInstanceListResponse)
        : base(digestInstanceListResponse) { }
#pragma warning restore CS8618

    public DigestInstanceListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigestInstanceListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigestInstanceListResponseFromRaw.FromRawUnchecked"/>
    public static DigestInstanceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigestInstanceListResponseFromRaw : IFromRawJson<DigestInstanceListResponse>
{
    /// <inheritdoc/>
    public DigestInstanceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigestInstanceListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Always `list` for a paginated list response.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    List,
}

sealed class TypeConverter : JsonConverter<global::Courier.Models.Digests.Type>
{
    public override global::Courier.Models.Digests.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "list" => global::Courier.Models.Digests.Type.List,
            _ => (global::Courier.Models.Digests.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Courier.Models.Digests.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Courier.Models.Digests.Type.List => "list",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
