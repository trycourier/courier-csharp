using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Digests;

/// <summary>
/// A delivery cadence for a topic's digest, with its assigned id.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<TopicDigestScheduleResponse, TopicDigestScheduleResponseFromRaw>)
)]
public sealed record class TopicDigestScheduleResponse : JsonModel
{
    /// <summary>
    /// The schedule's identifier, assigned by the server. This is the value the
    /// `/digests/schedules/{schedule_id}` endpoints are keyed by.
    ///
    /// <para>Two formats are in circulation and only one is safe to drop into a
    /// URL. Schedules created through the API are `sch_01m26xfcn3endt3nxy4e2kx2rh`
    /// and need no encoding. Schedules created in the Preferences Editor before that
    /// format are `sch/{uuid}` and contain a literal `/`, so they must be URL-encoded
    /// as `sch%2F{uuid}` — unencoded, the path does not match the route and the
    /// response is a bare `404` that reads like a broken endpoint. Existing ids are
    /// never migrated.</para>
    /// </summary>
    public required string ScheduleID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("schedule_id");
        }
        init { this._rawData.Set("schedule_id", value); }
    }

    /// <summary>
    /// ISO-8601 timestamp of when the schedule was created.
    /// </summary>
    public string? Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("created", value);
        }
    }

    /// <summary>
    /// Day of the month, 1-31.
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
    /// A day of the week. Accepted case-insensitively, returned lowercase.
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
    /// Omitted for a stored schedule this enum cannot express. Those schedules never
    /// fire, but their `schedule_id` is still returned so the `/digests/*` endpoints
    /// remain reachable for them.
    /// </summary>
    public ApiEnum<string, DigestFrequency>? Frequency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DigestFrequency>>("frequency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("frequency", value);
        }
    }

    /// <summary>
    /// Whether this is the schedule recipients are placed on by default.
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
    /// 24-hour local delivery time, `HH:MM`.
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
    /// IANA timezone the schedule is expressed in. Absent means UTC.
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

    /// <summary>
    /// ISO-8601 timestamp of the last update.
    /// </summary>
    public string? Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ScheduleID;
        _ = this.Created;
        _ = this.DayOfMonth;
        this.DayOfWeek?.Validate();
        foreach (var item in this.DaysOfWeek ?? [])
        {
            item.Validate();
        }
        _ = this.Disabled;
        this.Frequency?.Validate();
        _ = this.IsDefault;
        _ = this.Time;
        _ = this.Timezone;
        _ = this.Updated;
    }

    public TopicDigestScheduleResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopicDigestScheduleResponse(TopicDigestScheduleResponse topicDigestScheduleResponse)
        : base(topicDigestScheduleResponse) { }
#pragma warning restore CS8618

    public TopicDigestScheduleResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopicDigestScheduleResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopicDigestScheduleResponseFromRaw.FromRawUnchecked"/>
    public static TopicDigestScheduleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopicDigestScheduleResponse(string scheduleID)
        : this()
    {
        this.ScheduleID = scheduleID;
    }
}

class TopicDigestScheduleResponseFromRaw : IFromRawJson<TopicDigestScheduleResponse>
{
    /// <inheritdoc/>
    public TopicDigestScheduleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopicDigestScheduleResponse.FromRawUnchecked(rawData);
}
