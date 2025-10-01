using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Bulk.BulkRetrieveJobResponseProperties.JobProperties;

namespace Courier.Models.Bulk.BulkRetrieveJobResponseProperties;

[JsonConverter(typeof(ModelConverter<Job>))]
public sealed record class Job : ModelBase, IFromRaw<Job>
{
    public required InboundBulkMessage Definition
    {
        get
        {
            if (!this.Properties.TryGetValue("definition", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'definition' cannot be null",
                    new ArgumentOutOfRangeException("definition", "Missing required argument")
                );

            return JsonSerializer.Deserialize<InboundBulkMessage>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'definition' cannot be null",
                    new ArgumentNullException("definition")
                );
        }
        set
        {
            this.Properties["definition"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Enqueued
    {
        get
        {
            if (!this.Properties.TryGetValue("enqueued", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'enqueued' cannot be null",
                    new ArgumentOutOfRangeException("enqueued", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["enqueued"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Failures
    {
        get
        {
            if (!this.Properties.TryGetValue("failures", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'failures' cannot be null",
                    new ArgumentOutOfRangeException("failures", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["failures"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Received
    {
        get
        {
            if (!this.Properties.TryGetValue("received", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'received' cannot be null",
                    new ArgumentOutOfRangeException("received", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["received"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Status> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Job(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Job FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
