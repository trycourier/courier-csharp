using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Bulk;

[JsonConverter(typeof(JsonModelConverter<BulkRetrieveJobResponse, BulkRetrieveJobResponseFromRaw>))]
public sealed record class BulkRetrieveJobResponse : JsonModel
{
    public required Job Job
    {
        get { return JsonModel.GetNotNullClass<Job>(this.RawData, "job"); }
        init { JsonModel.Set(this._rawData, "job", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Job.Validate();
    }

    public BulkRetrieveJobResponse() { }

    public BulkRetrieveJobResponse(BulkRetrieveJobResponse bulkRetrieveJobResponse)
        : base(bulkRetrieveJobResponse) { }

    public BulkRetrieveJobResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkRetrieveJobResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BulkRetrieveJobResponseFromRaw.FromRawUnchecked"/>
    public static BulkRetrieveJobResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BulkRetrieveJobResponse(Job job)
        : this()
    {
        this.Job = job;
    }
}

class BulkRetrieveJobResponseFromRaw : IFromRawJson<BulkRetrieveJobResponse>
{
    /// <inheritdoc/>
    public BulkRetrieveJobResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BulkRetrieveJobResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Job, JobFromRaw>))]
public sealed record class Job : JsonModel
{
    /// <summary>
    /// Bulk message definition. Supports two formats: - V1 format: Requires `event`
    /// field (event ID or notification ID) - V2 format: Optionally use `template`
    /// (notification ID) or `content` (Elemental content) in addition to `event`
    /// </summary>
    public required InboundBulkMessage Definition
    {
        get { return JsonModel.GetNotNullClass<InboundBulkMessage>(this.RawData, "definition"); }
        init { JsonModel.Set(this._rawData, "definition", value); }
    }

    public required long Enqueued
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "enqueued"); }
        init { JsonModel.Set(this._rawData, "enqueued", value); }
    }

    public required long Failures
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "failures"); }
        init { JsonModel.Set(this._rawData, "failures", value); }
    }

    public required long Received
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "received"); }
        init { JsonModel.Set(this._rawData, "received", value); }
    }

    public required ApiEnum<string, JobStatus> Status
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, JobStatus>>(this.RawData, "status");
        }
        init { JsonModel.Set(this._rawData, "status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Definition.Validate();
        _ = this.Enqueued;
        _ = this.Failures;
        _ = this.Received;
        this.Status.Validate();
    }

    public Job() { }

    public Job(Job job)
        : base(job) { }

    public Job(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Job(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JobFromRaw.FromRawUnchecked"/>
    public static Job FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JobFromRaw : IFromRawJson<Job>
{
    /// <inheritdoc/>
    public Job FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Job.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JobStatusConverter))]
public enum JobStatus
{
    Created,
    Processing,
    Completed,
    Error,
}

sealed class JobStatusConverter : JsonConverter<JobStatus>
{
    public override JobStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CREATED" => JobStatus.Created,
            "PROCESSING" => JobStatus.Processing,
            "COMPLETED" => JobStatus.Completed,
            "ERROR" => JobStatus.Error,
            _ => (JobStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JobStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JobStatus.Created => "CREATED",
                JobStatus.Processing => "PROCESSING",
                JobStatus.Completed => "COMPLETED",
                JobStatus.Error => "ERROR",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
