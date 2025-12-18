using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.AuditEvents;

[JsonConverter(typeof(JsonModelConverter<AuditEventListResponse, AuditEventListResponseFromRaw>))]
public sealed record class AuditEventListResponse : JsonModel
{
    public required Paging Paging
    {
        get { return JsonModel.GetNotNullClass<Paging>(this.RawData, "paging"); }
        init { JsonModel.Set(this._rawData, "paging", value); }
    }

    public required IReadOnlyList<AuditEvent> Results
    {
        get { return JsonModel.GetNotNullClass<List<AuditEvent>>(this.RawData, "results"); }
        init { JsonModel.Set(this._rawData, "results", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Paging.Validate();
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public AuditEventListResponse() { }

    public AuditEventListResponse(AuditEventListResponse auditEventListResponse)
        : base(auditEventListResponse) { }

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

    /// <inheritdoc cref="AuditEventListResponseFromRaw.FromRawUnchecked"/>
    public static AuditEventListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AuditEventListResponseFromRaw : IFromRawJson<AuditEventListResponse>
{
    /// <inheritdoc/>
    public AuditEventListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AuditEventListResponse.FromRawUnchecked(rawData);
}
