using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Bulk;

[JsonConverter(typeof(ModelConverter<BulkCreateJobResponse>))]
public sealed record class BulkCreateJobResponse : ModelBase, IFromRaw<BulkCreateJobResponse>
{
    public required string JobID
    {
        get
        {
            if (!this._rawData.TryGetValue("jobId", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'jobId' cannot be null",
                    new ArgumentOutOfRangeException("jobId", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'jobId' cannot be null",
                    new ArgumentNullException("jobId")
                );
        }
        init
        {
            this._rawData["jobId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.JobID;
    }

    public BulkCreateJobResponse() { }

    public BulkCreateJobResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkCreateJobResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BulkCreateJobResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BulkCreateJobResponse(string jobID)
        : this()
    {
        this.JobID = jobID;
    }
}
