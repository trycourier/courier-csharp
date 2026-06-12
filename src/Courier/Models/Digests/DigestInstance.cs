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

[JsonConverter(typeof(JsonModelConverter<DigestInstance, DigestInstanceFromRaw>))]
public sealed record class DigestInstance : JsonModel
{
    /// <summary>
    /// A unique identifier for the digest instance.
    /// </summary>
    public required string DigestInstanceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("digest_instance_id");
        }
        init { this._rawData.Set("digest_instance_id", value); }
    }

    /// <summary>
    /// The total number of events received for this instance.
    /// </summary>
    public required long EventCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("event_count");
        }
        init { this._rawData.Set("event_count", value); }
    }

    /// <summary>
    /// The status of the digest instance. `IN_PROGRESS` instances are still accumulating
    /// events; `COMPLETED` instances have been released.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The ID of the user this digest instance belongs to.
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <summary>
    /// The categories configured for the digest.
    /// </summary>
    public IReadOnlyList<DigestCategory>? Categories
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DigestCategory>>("categories");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DigestCategory>?>(
                "categories",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A map of category key to the number of events received for that category.
    /// </summary>
    public IReadOnlyDictionary<string, long>? CategoryKeyCounts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, long>>(
                "category_key_counts"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, long>?>(
                "category_key_counts",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// An ISO 8601 timestamp of when the digest instance was created.
    /// </summary>
    public string? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Whether the digest instance has been disabled.
    /// </summary>
    public bool? Disabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("disabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("disabled", value);
        }
    }

    /// <summary>
    /// The ID of the tenant this digest instance belongs to, if any.
    /// </summary>
    public string? TenantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tenant_id");
        }
        init { this._rawData.Set("tenant_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DigestInstanceID;
        _ = this.EventCount;
        this.Status.Validate();
        _ = this.UserID;
        foreach (var item in this.Categories ?? [])
        {
            item.Validate();
        }
        _ = this.CategoryKeyCounts;
        _ = this.CreatedAt;
        _ = this.Disabled;
        _ = this.TenantID;
    }

    public DigestInstance() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigestInstance(DigestInstance digestInstance)
        : base(digestInstance) { }
#pragma warning restore CS8618

    public DigestInstance(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigestInstance(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigestInstanceFromRaw.FromRawUnchecked"/>
    public static DigestInstance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigestInstanceFromRaw : IFromRawJson<DigestInstance>
{
    /// <inheritdoc/>
    public DigestInstance FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DigestInstance.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the digest instance. `IN_PROGRESS` instances are still accumulating
/// events; `COMPLETED` instances have been released.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    InProgress,
    Completed,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "IN_PROGRESS" => Status.InProgress,
            "COMPLETED" => Status.Completed,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.InProgress => "IN_PROGRESS",
                Status.Completed => "COMPLETED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
