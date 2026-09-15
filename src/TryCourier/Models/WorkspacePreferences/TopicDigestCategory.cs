using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.WorkspacePreferences;

/// <summary>
/// How events collected under a category key are retained when a digest holds more
/// than it will render.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TopicDigestCategory, TopicDigestCategoryFromRaw>))]
public sealed record class TopicDigestCategory : JsonModel
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
    /// How many collected events are carried into the rendered digest. Defaults to 10.
    ///
    /// <para>Events beyond the limit are discarded, not held back for the next digest:
    /// the release consumes everything collected so far and only `limit` of them
    /// appear. `retain` decides which ones those are.</para>
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("limit", value);
        }
    }

    /// <summary>
    /// Which collected events survive the `limit`. `FIRST` and `LOWEST` keep the
    /// earliest or smallest; `LAST` and `HIGHEST` keep the latest or largest. Accepted
    /// case-insensitively, returned uppercase.
    /// </summary>
    public ApiEnum<string, Retain>? Retain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Retain>>("retain");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("retain", value);
        }
    }

    /// <summary>
    /// The data key used to rank events. Required when `retain` is `HIGHEST` or `LOWEST`.
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
        _ = this.Limit;
        this.Retain?.Validate();
        _ = this.SortKey;
    }

    public TopicDigestCategory() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopicDigestCategory(TopicDigestCategory topicDigestCategory)
        : base(topicDigestCategory) { }
#pragma warning restore CS8618

    public TopicDigestCategory(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopicDigestCategory(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopicDigestCategoryFromRaw.FromRawUnchecked"/>
    public static TopicDigestCategory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopicDigestCategory(string categoryKey)
        : this()
    {
        this.CategoryKey = categoryKey;
    }
}

class TopicDigestCategoryFromRaw : IFromRawJson<TopicDigestCategory>
{
    /// <inheritdoc/>
    public TopicDigestCategory FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopicDigestCategory.FromRawUnchecked(rawData);
}

/// <summary>
/// Which collected events survive the `limit`. `FIRST` and `LOWEST` keep the earliest
/// or smallest; `LAST` and `HIGHEST` keep the latest or largest. Accepted case-insensitively,
/// returned uppercase.
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
            "FIRST" => Retain.First,
            "LAST" => Retain.Last,
            "HIGHEST" => Retain.Highest,
            "LOWEST" => Retain.Lowest,
            "NONE" => Retain.None,
            _ => (Retain)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Retain value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Retain.First => "FIRST",
                Retain.Last => "LAST",
                Retain.Highest => "HIGHEST",
                Retain.Lowest => "LOWEST",
                Retain.None => "NONE",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
