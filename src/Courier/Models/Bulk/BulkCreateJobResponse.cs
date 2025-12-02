using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Bulk;

[JsonConverter(typeof(ModelConverter<BulkCreateJobResponse, BulkCreateJobResponseFromRaw>))]
public sealed record class BulkCreateJobResponse : ModelBase
{
    public required string JobID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "jobId"); }
        init { ModelBase.Set(this._rawData, "jobId", value); }
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

class BulkCreateJobResponseFromRaw : IFromRaw<BulkCreateJobResponse>
{
    public BulkCreateJobResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BulkCreateJobResponse.FromRawUnchecked(rawData);
}
