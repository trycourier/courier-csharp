using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Digests;

[JsonConverter(typeof(JsonModelConverter<DigestCategory, DigestCategoryFromRaw>))]
public sealed record class DigestCategory : JsonModel
{
    /// <summary>
    /// The key that identifies the category within the digest.
    /// </summary>
    public required string CategoryKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("category_key");
        }
        init { this._rawData.Set("category_key", value); }
    }

    /// <summary>
    /// Which events to keep when the number of events exceeds the retention limit
    /// for the category.
    /// </summary>
    public required ApiEnum<string, Retain> Retain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Retain>>("retain");
        }
        init { this._rawData.Set("retain", value); }
    }

    /// <summary>
    /// The data key used to order events when `retain` is `highest` or `lowest`.
    /// </summary>
    public string? SortKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sort_key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sort_key", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CategoryKey;
        this.Retain.Validate();
        _ = this.SortKey;
    }

    public DigestCategory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigestCategory(DigestCategory digestCategory)
        : base(digestCategory) { }
#pragma warning restore CS8618

    public DigestCategory(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigestCategory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigestCategoryFromRaw.FromRawUnchecked"/>
    public static DigestCategory FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigestCategoryFromRaw : IFromRawJson<DigestCategory>
{
    /// <inheritdoc/>
    public DigestCategory FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DigestCategory.FromRawUnchecked(rawData);
}

/// <summary>
/// Which events to keep when the number of events exceeds the retention limit for
/// the category.
/// </summary>
[JsonConverter(typeof(RetainConverter))]
public enum Retain
{
    First,
    Last,
    Highest,
    Lowest,
    None,
}

sealed class RetainConverter : JsonConverter<Retain>
{
    public override Retain Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "first" => Retain.First,
            "last" => Retain.Last,
            "highest" => Retain.Highest,
            "lowest" => Retain.Lowest,
            "none" => Retain.None,
            _ => (Retain)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Retain value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Retain.First => "first",
                Retain.Last => "last",
                Retain.Highest => "highest",
                Retain.Lowest => "lowest",
                Retain.None => "none",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
