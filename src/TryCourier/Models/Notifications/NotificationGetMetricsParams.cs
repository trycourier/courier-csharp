using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Notifications;

/// <summary>
/// Fetch the delivery funnel for one Notification Template as a time series — sent,
/// delivered, opened, clicked, errors, and undeliverable — broken out per provider
/// and channel inside each bucket. Sum the entries in a bucket for its totals; there
/// is no bucket-level total.
///
/// <para>Choose the window absolutely with `start` and `end`, or relatively with
/// `lookback` (an ISO 8601 duration). `start` and `end` take precedence when both
/// are supplied, and a request carrying neither defaults to `lookback=P30D`. The
/// window is snapped outwards onto the `granularity` grid so every bucket it overlaps
/// is returned whole, and the snapped boundaries come back as `start` and `end`
/// — align a chart on those rather than on what was requested. Every boundary is
/// UTC; there is no timezone support.</para>
///
/// <para>Every bucket in the window is returned, including the quiet ones, whose
/// `data` array is empty, so a series is directly plottable with no gap filling
/// client-side. An unknown template id returns `200` with an all-empty series rather
/// than `404`, and messages sent without a Notification Template never appear here.</para>
///
/// <para>Available in the US region only.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class NotificationGetMetricsParams : ParamsBase
{
    public string? ID { get; init; }

    /// <summary>
    /// The end of the window, as an ISO 8601 timestamp with an offset. Must be supplied
    /// together with `start`. An `end` in the future is accepted and not clamped
    /// — the trailing buckets come back empty.
    /// </summary>
    public System::DateTimeOffset? End
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("end");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("end", value);
        }
    }

    /// <summary>
    /// The size of each bucket in the series. Defaults to `DAY`. `WEEK` buckets start
    /// on Sunday. A fine granularity caps the window it can cover: `HOUR` spans at
    /// most 7 days and `DAY` at most 90 days, and a wider window returns `400` —
    /// request a coarser granularity instead. `WEEK` and `MONTH` are uncapped, subject
    /// to the 1000-bucket limit on a single response.
    /// </summary>
    public ApiEnum<string, Granularity>? Granularity
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Granularity>>("granularity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("granularity", value);
        }
    }

    /// <summary>
    /// The length of the window, counted back from now, as an ISO 8601 duration
    /// (`P30D`, `P12W`, `PT12H`). Defaults to `P30D`, and is ignored when `start`
    /// and `end` are supplied. A malformed or non-positive duration returns `400`.
    /// </summary>
    public string? Lookback
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("lookback");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("lookback", value);
        }
    }

    /// <summary>
    /// The inclusive start of the window, as an ISO 8601 timestamp with an offset
    /// (`2026-04-01T00:00:00Z`). Must be supplied together with `end` and be earlier
    /// than it; either one alone returns `400`.
    /// </summary>
    public System::DateTimeOffset? Start
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>("start");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("start", value);
        }
    }

    public NotificationGetMetricsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationGetMetricsParams(NotificationGetMetricsParams notificationGetMetricsParams)
        : base(notificationGetMetricsParams)
    {
        this.ID = notificationGetMetricsParams.ID;
    }
#pragma warning restore CS8618

    public NotificationGetMetricsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationGetMetricsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ID = id;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static NotificationGetMetricsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            id
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(NotificationGetMetricsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/notifications/{0}/metrics", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// The size of each bucket in the series. Defaults to `DAY`. `WEEK` buckets start
/// on Sunday. A fine granularity caps the window it can cover: `HOUR` spans at most
/// 7 days and `DAY` at most 90 days, and a wider window returns `400` — request a
/// coarser granularity instead. `WEEK` and `MONTH` are uncapped, subject to the 1000-bucket
/// limit on a single response.
/// </summary>
[JsonConverter(typeof(GranularityConverter))]
public enum Granularity
{
    Hour,
    Day,
    Week,
    Month,
}

sealed class GranularityConverter : JsonConverter<Granularity>
{
    public override Granularity Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "HOUR" => Granularity.Hour,
            "DAY" => Granularity.Day,
            "WEEK" => Granularity.Week,
            "MONTH" => Granularity.Month,
            _ => (Granularity)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Granularity value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Granularity.Hour => "HOUR",
                Granularity.Day => "DAY",
                Granularity.Week => "WEEK",
                Granularity.Month => "MONTH",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
