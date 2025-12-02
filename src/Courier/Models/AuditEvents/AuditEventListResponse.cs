using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.AuditEvents;

[JsonConverter(typeof(ModelConverter<AuditEventListResponse, AuditEventListResponseFromRaw>))]
public sealed record class AuditEventListResponse : ModelBase
{
    public required Paging Paging
    {
        get { return ModelBase.GetNotNullClass<Paging>(this.RawData, "paging"); }
        init { ModelBase.Set(this._rawData, "paging", value); }
    }

    public required IReadOnlyList<AuditEvent> Results
    {
        get { return ModelBase.GetNotNullClass<List<AuditEvent>>(this.RawData, "results"); }
        init { ModelBase.Set(this._rawData, "results", value); }
    }

    public override void Validate()
    {
        this.Paging.Validate();
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public AuditEventListResponse() { }

    public AuditEventListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuditEventListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AuditEventListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AuditEventListResponseFromRaw : IFromRaw<AuditEventListResponse>
{
    public AuditEventListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AuditEventListResponse.FromRawUnchecked(rawData);
}
