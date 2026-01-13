using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Bulk;

[JsonConverter(typeof(JsonModelConverter<BulkCreateJobResponse, BulkCreateJobResponseFromRaw>))]
public sealed record class BulkCreateJobResponse : JsonModel
{
    public required string JobID
    {
        get { return this._rawData.GetNotNullClass<string>("jobId"); }
        init { this._rawData.Set("jobId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.JobID;
    }

    public BulkCreateJobResponse() { }

    public BulkCreateJobResponse(BulkCreateJobResponse bulkCreateJobResponse)
        : base(bulkCreateJobResponse) { }

    public BulkCreateJobResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkCreateJobResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BulkCreateJobResponseFromRaw.FromRawUnchecked"/>
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

class BulkCreateJobResponseFromRaw : IFromRawJson<BulkCreateJobResponse>
{
    /// <inheritdoc/>
    public BulkCreateJobResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BulkCreateJobResponse.FromRawUnchecked(rawData);
}
