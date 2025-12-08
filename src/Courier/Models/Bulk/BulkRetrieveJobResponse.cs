using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Bulk;

[JsonConverter(typeof(ModelConverter<BulkRetrieveJobResponse, BulkRetrieveJobResponseFromRaw>))]
public sealed record class BulkRetrieveJobResponse : ModelBase
{
    public required Job Job
    {
        get { return ModelBase.GetNotNullClass<Job>(this.RawData, "job"); }
        init { ModelBase.Set(this._rawData, "job", value); }
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

class BulkRetrieveJobResponseFromRaw : IFromRaw<BulkRetrieveJobResponse>
{
    /// <inheritdoc/>
    public BulkRetrieveJobResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BulkRetrieveJobResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Job, JobFromRaw>))]
public sealed record class Job : ModelBase
{
    public required InboundBulkMessage Definition
    {
        get { return ModelBase.GetNotNullClass<InboundBulkMessage>(this.RawData, "definition"); }
        init { ModelBase.Set(this._rawData, "definition", value); }
    }

    public required long Enqueued
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "enqueued"); }
        init { ModelBase.Set(this._rawData, "enqueued", value); }
    }

    public required long Failures
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "failures"); }
        init { ModelBase.Set(this._rawData, "failures", value); }
    }

    public required long Received
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "received"); }
        init { ModelBase.Set(this._rawData, "received", value); }
    }

    public required ApiEnum<string, JobStatus> Status
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, JobStatus>>(this.RawData, "status");
        }
        init { ModelBase.Set(this._rawData, "status", value); }
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

class JobFromRaw : IFromRaw<Job>
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
