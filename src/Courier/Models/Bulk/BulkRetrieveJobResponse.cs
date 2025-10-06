using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Bulk.BulkRetrieveJobResponseProperties;

namespace Courier.Models.Bulk;

[JsonConverter(typeof(ModelConverter<BulkRetrieveJobResponse>))]
public sealed record class BulkRetrieveJobResponse : ModelBase, IFromRaw<BulkRetrieveJobResponse>
{
    public required Job Job
    {
        get
        {
            if (!this.Properties.TryGetValue("job", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'job' cannot be null",
                    new ArgumentOutOfRangeException("job", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Job>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'job' cannot be null",
                    new ArgumentNullException("job")
                );
        }
        set
        {
            this.Properties["job"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkRetrieveJobResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BulkRetrieveJobResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BulkRetrieveJobResponse(Job job)
        : this()
    {
        this.Job = job;
    }
}
