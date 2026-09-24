using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.WorkspacePreferences;

[JsonConverter(
    typeof(JsonModelConverter<PreferenceChangeLogEntry, PreferenceChangeLogEntryFromRaw>)
)]
public sealed record class PreferenceChangeLogEntry : JsonModel
{
    /// <summary>
    /// Unique identifier for this change.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The channels chosen for this topic, present only when has_custom_routing
    /// is true. Empty otherwise.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, ChannelClassification>> CustomRouting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<ApiEnum<string, ChannelClassification>>
            >("custom_routing");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, ChannelClassification>>>(
                "custom_routing",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether specific delivery channels were chosen for this topic rather than
    /// the topic's default routing.
    /// </summary>
    public required bool HasCustomRouting
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_custom_routing");
        }
        init { this._rawData.Set("has_custom_routing", value); }
    }

    /// <summary>
    /// The subscription status the change set.
    /// </summary>
    public required ApiEnum<string, PreferenceStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PreferenceStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// When the change was made, as an ISO-8601 date-time in UTC.
    /// </summary>
    public required string Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    /// <summary>
    /// The subscription topic the change applies to.
    /// </summary>
    public required string TopicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("topic_id");
        }
        init { this._rawData.Set("topic_id", value); }
    }

    /// <summary>
    /// The display name of that topic when the change was made.
    /// </summary>
    public required string TopicName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("topic_name");
        }
        init { this._rawData.Set("topic_name", value); }
    }

    /// <summary>
    /// The user whose preference changed.
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
    /// The value before this change, where it was recorded.
    /// </summary>
    public PreferenceChangeLogValue? Previous
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PreferenceChangeLogValue>("previous");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("previous", value);
        }
    }

    /// <summary>
    /// The tenant context the change was made in. Absent when the user set the preference
    /// outside any tenant.
    /// </summary>
    public string? TenantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tenant_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tenant_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.CustomRouting)
        {
            item.Validate();
        }
        _ = this.HasCustomRouting;
        this.Status.Validate();
        _ = this.Timestamp;
        _ = this.TopicID;
        _ = this.TopicName;
        _ = this.UserID;
        this.Previous?.Validate();
        _ = this.TenantID;
    }

    public PreferenceChangeLogEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceChangeLogEntry(PreferenceChangeLogEntry preferenceChangeLogEntry)
        : base(preferenceChangeLogEntry) { }
#pragma warning restore CS8618

    public PreferenceChangeLogEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceChangeLogEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceChangeLogEntryFromRaw.FromRawUnchecked"/>
    public static PreferenceChangeLogEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreferenceChangeLogEntryFromRaw : IFromRawJson<PreferenceChangeLogEntry>
{
    /// <inheritdoc/>
    public PreferenceChangeLogEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceChangeLogEntry.FromRawUnchecked(rawData);
}
