using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Models.Digests;

namespace TryCourier.Models.WorkspacePreferences;

/// <summary>
/// One delivery cadence for a topic's digest. Supply `schedule_id` to update an
/// existing schedule in place; omit it and one is assigned and returned. The `schedules`
/// array is a full replacement, so a stored schedule absent from it is deleted along
/// with its delivery rule.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TopicDigestScheduleRequest, TopicDigestScheduleRequestFromRaw>)
)]
public sealed record class TopicDigestScheduleRequest : JsonModel
{
    /// <summary>
    /// How often a digest is delivered. `instant` delivers immediately without batching,
    /// and is the one value that takes no `time`.
    /// </summary>
    public required ApiEnum<string, DigestFrequency> Frequency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DigestFrequency>>("frequency");
        }
        init { this._rawData.Set("frequency", value); }
    }

    /// <summary>
    /// Required when `frequency` is `monthly`.
    /// </summary>
    public long? DayOfMonth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("day_of_month");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("day_of_month", value);
        }
    }

    /// <summary>
    /// Required when `frequency` is `weekly`.
    /// </summary>
    public ApiEnum<string, DigestDayOfWeek>? DayOfWeek
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DigestDayOfWeek>>("day_of_week");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("day_of_week", value);
        }
    }

    /// <summary>
    /// Required when `frequency` is `custom_days`.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, DigestDayOfWeek>>? DaysOfWeek
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, DigestDayOfWeek>>
            >("days_of_week");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, DigestDayOfWeek>>?>(
                "days_of_week",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether the schedule is disabled.
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
    /// The schedule recipients are placed on when they have not chosen one. Set this
    /// explicitly rather than relying on array position.
    /// </summary>
    public bool? IsDefault
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_default");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_default", value);
        }
    }

    /// <summary>
    /// Identifier of an existing schedule to update. Omit when creating a new one.
    /// </summary>
    public string? ScheduleID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("schedule_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("schedule_id", value);
        }
    }

    /// <summary>
    /// 24-hour local delivery time, `HH:MM`. Required for every frequency except `instant`.
    /// </summary>
    public string? Time
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("time");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("time", value);
        }
    }

    /// <summary>
    /// IANA timezone the `time` and day fields are expressed in, e.g. `America/New_York`.
    /// Absent means UTC. Delivery follows the same local wall-clock across daylight-saving changes.
    /// </summary>
    public string? Timezone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("timezone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timezone", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Frequency.Validate();
        _ = this.DayOfMonth;
        this.DayOfWeek?.Validate();
        foreach (var item in this.DaysOfWeek ?? [])
        {
            item.Validate();
        }
        _ = this.Disabled;
        _ = this.IsDefault;
        _ = this.ScheduleID;
        _ = this.Time;
        _ = this.Timezone;
    }

    public TopicDigestScheduleRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopicDigestScheduleRequest(TopicDigestScheduleRequest topicDigestScheduleRequest)
        : base(topicDigestScheduleRequest) { }
#pragma warning restore CS8618

    public TopicDigestScheduleRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopicDigestScheduleRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopicDigestScheduleRequestFromRaw.FromRawUnchecked"/>
    public static TopicDigestScheduleRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopicDigestScheduleRequest(ApiEnum<string, DigestFrequency> frequency)
        : this()
    {
        this.Frequency = frequency;
    }
}

class TopicDigestScheduleRequestFromRaw : IFromRawJson<TopicDigestScheduleRequest>
{
    /// <inheritdoc/>
    public TopicDigestScheduleRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopicDigestScheduleRequest.FromRawUnchecked(rawData);
}
