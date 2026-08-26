using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Notifications;

[JsonConverter(
    typeof(JsonModelConverter<NotificationMetricsResponse, NotificationMetricsResponseFromRaw>)
)]
public sealed record class NotificationMetricsResponse : JsonModel
{
    /// <summary>
    /// End of the window actually queried, ceiled onto the granularity grid. Second-precision UTC.
    /// </summary>
    public required System::DateTimeOffset End
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("end");
        }
        init { this._rawData.Set("end", value); }
    }

    /// <summary>
    /// Bucket size the series was built at.
    /// </summary>
    public required ApiEnum<string, NotificationMetricsResponseGranularity> Granularity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NotificationMetricsResponseGranularity>
            >("granularity");
        }
        init { this._rawData.Set("granularity", value); }
    }

    /// <summary>
    /// The template the series describes, echoed from the request.
    /// </summary>
    public required string NotificationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("notificationId");
        }
        init { this._rawData.Set("notificationId", value); }
    }

    /// <summary>
    /// One entry per bucket between `start` and `end`, oldest first, including buckets
    /// with no activity.
    /// </summary>
    public required IReadOnlyList<Series> Series
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Series>>("series");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Series>>(
                "series",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Inclusive start of the window actually queried, floored onto the granularity
    /// grid. Second-precision UTC.
    /// </summary>
    public required System::DateTimeOffset Start
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("start");
        }
        init { this._rawData.Set("start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.End;
        this.Granularity.Validate();
        _ = this.NotificationID;
        foreach (var item in this.Series)
        {
            item.Validate();
        }
        _ = this.Start;
    }

    public NotificationMetricsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationMetricsResponse(NotificationMetricsResponse notificationMetricsResponse)
        : base(notificationMetricsResponse) { }
#pragma warning restore CS8618

    public NotificationMetricsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationMetricsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationMetricsResponseFromRaw.FromRawUnchecked"/>
    public static NotificationMetricsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationMetricsResponseFromRaw : IFromRawJson<NotificationMetricsResponse>
{
    /// <inheritdoc/>
    public NotificationMetricsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationMetricsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Bucket size the series was built at.
/// </summary>
[JsonConverter(typeof(NotificationMetricsResponseGranularityConverter))]
public enum NotificationMetricsResponseGranularity
{
    Hour,
    Day,
    Week,
    Month,
}

sealed class NotificationMetricsResponseGranularityConverter
    : JsonConverter<NotificationMetricsResponseGranularity>
{
    public override NotificationMetricsResponseGranularity Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "HOUR" => NotificationMetricsResponseGranularity.Hour,
            "DAY" => NotificationMetricsResponseGranularity.Day,
            "WEEK" => NotificationMetricsResponseGranularity.Week,
            "MONTH" => NotificationMetricsResponseGranularity.Month,
            _ => (NotificationMetricsResponseGranularity)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NotificationMetricsResponseGranularity value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NotificationMetricsResponseGranularity.Hour => "HOUR",
                NotificationMetricsResponseGranularity.Day => "DAY",
                NotificationMetricsResponseGranularity.Week => "WEEK",
                NotificationMetricsResponseGranularity.Month => "MONTH",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Series, SeriesFromRaw>))]
public sealed record class Series : JsonModel
{
    /// <summary>
    /// One entry per provider and channel that handled a message in this bucket.
    /// Empty when nothing was sent.
    /// </summary>
    public required IReadOnlyList<Data> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Data>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Data>>("data", ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Start of the bucket, second-precision UTC.
    /// </summary>
    public required System::DateTimeOffset Period
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("period");
        }
        init { this._rawData.Set("period", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.Period;
    }

    public Series() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Series(Series series)
        : base(series) { }
#pragma warning restore CS8618

    public Series(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Series(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SeriesFromRaw.FromRawUnchecked"/>
    public static Series FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SeriesFromRaw : IFromRawJson<Series>
{
    /// <inheritdoc/>
    public Series FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Series.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Channel the provider delivered on, e.g. `email`.
    /// </summary>
    public required string Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <summary>
    /// Messages with at least one tracked link click.
    /// </summary>
    public required long Clicked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("clicked");
        }
        init { this._rawData.Set("clicked", value); }
    }

    /// <summary>
    /// Messages the provider confirmed as delivered.
    /// </summary>
    public required long Delivered
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("delivered");
        }
        init { this._rawData.Set("delivered", value); }
    }

    /// <summary>
    /// Messages the provider rejected or failed on, including ones a later provider
    /// then delivered.
    /// </summary>
    public required long Errors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("errors");
        }
        init { this._rawData.Set("errors", value); }
    }

    /// <summary>
    /// Messages opened at least once. Always `0` on channels with no open tracking.
    /// </summary>
    public required long Opened
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("opened");
        }
        init { this._rawData.Set("opened", value); }
    }

    /// <summary>
    /// Provider that handled the messages, e.g. `sendgrid`.
    /// </summary>
    public required string Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("provider");
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// Messages handed to the provider.
    /// </summary>
    public required long Sent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("sent");
        }
        init { this._rawData.Set("sent", value); }
    }

    /// <summary>
    /// Messages Courier could not deliver on any provider for the channel.
    /// </summary>
    public required long Undeliverable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("undeliverable");
        }
        init { this._rawData.Set("undeliverable", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channel;
        _ = this.Clicked;
        _ = this.Delivered;
        _ = this.Errors;
        _ = this.Opened;
        _ = this.Provider;
        _ = this.Sent;
        _ = this.Undeliverable;
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}
