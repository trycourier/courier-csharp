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
        get
        {
            if (!this._rawData.TryGetValue("job", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'job' cannot be null",
                    new System::ArgumentOutOfRangeException("job", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Job>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'job' cannot be null",
                    new System::ArgumentNullException("job")
                );
        }
        init
        {
            this._rawData["job"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Job.Validate();
    }

    public BulkRetrieveJobResponse() { }

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
    public BulkRetrieveJobResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BulkRetrieveJobResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Job, JobFromRaw>))]
public sealed record class Job : ModelBase
{
    public required InboundBulkMessage Definition
    {
        get
        {
            if (!this._rawData.TryGetValue("definition", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'definition' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "definition",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<InboundBulkMessage>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'definition' cannot be null",
                    new System::ArgumentNullException("definition")
                );
        }
        init
        {
            this._rawData["definition"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Enqueued
    {
        get
        {
            if (!this._rawData.TryGetValue("enqueued", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'enqueued' cannot be null",
                    new System::ArgumentOutOfRangeException("enqueued", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["enqueued"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Failures
    {
        get
        {
            if (!this._rawData.TryGetValue("failures", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'failures' cannot be null",
                    new System::ArgumentOutOfRangeException("failures", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["failures"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Received
    {
        get
        {
            if (!this._rawData.TryGetValue("received", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'received' cannot be null",
                    new System::ArgumentOutOfRangeException("received", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["received"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, JobStatus> Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, JobStatus>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentNullException("status")
                );
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Definition.Validate();
        _ = this.Enqueued;
        _ = this.Failures;
        _ = this.Received;
        this.Status.Validate();
    }

    public Job() { }

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

    public static Job FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JobFromRaw : IFromRaw<Job>
{
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
