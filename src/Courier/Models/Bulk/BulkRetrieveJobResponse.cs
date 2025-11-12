using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Bulk;

[JsonConverter(typeof(ModelConverter<BulkRetrieveJobResponse>))]
public sealed record class BulkRetrieveJobResponse : ModelBase, IFromRaw<BulkRetrieveJobResponse>
{
    public required Job Job
    {
        get
        {
            if (!this._properties.TryGetValue("job", out JsonElement element))
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
            this._properties["job"] = JsonSerializer.SerializeToElement(
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

    public BulkRetrieveJobResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkRetrieveJobResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BulkRetrieveJobResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BulkRetrieveJobResponse(Job job)
        : this()
    {
        this.Job = job;
    }
}

[JsonConverter(typeof(ModelConverter<Job>))]
public sealed record class Job : ModelBase, IFromRaw<Job>
{
    public required InboundBulkMessage Definition
    {
        get
        {
            if (!this._properties.TryGetValue("definition", out JsonElement element))
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
            this._properties["definition"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Enqueued
    {
        get
        {
            if (!this._properties.TryGetValue("enqueued", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'enqueued' cannot be null",
                    new System::ArgumentOutOfRangeException("enqueued", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["enqueued"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Failures
    {
        get
        {
            if (!this._properties.TryGetValue("failures", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'failures' cannot be null",
                    new System::ArgumentOutOfRangeException("failures", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["failures"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Received
    {
        get
        {
            if (!this._properties.TryGetValue("received", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'received' cannot be null",
                    new System::ArgumentOutOfRangeException("received", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["received"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, StatusModel> Status
    {
        get
        {
            if (!this._properties.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, StatusModel>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["status"] = JsonSerializer.SerializeToElement(
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

    public Job(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Job(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Job FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(StatusModelConverter))]
public enum StatusModel
{
    Created,
    Processing,
    Completed,
    Error,
}

sealed class StatusModelConverter : JsonConverter<StatusModel>
{
    public override StatusModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CREATED" => StatusModel.Created,
            "PROCESSING" => StatusModel.Processing,
            "COMPLETED" => StatusModel.Completed,
            "ERROR" => StatusModel.Error,
            _ => (StatusModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StatusModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StatusModel.Created => "CREATED",
                StatusModel.Processing => "PROCESSING",
                StatusModel.Completed => "COMPLETED",
                StatusModel.Error => "ERROR",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
