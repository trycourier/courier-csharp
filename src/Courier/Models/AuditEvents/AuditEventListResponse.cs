using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        get { return this._rawData.GetNotNullClass<Paging>("paging"); }
        init { this._rawData.Set("paging", value); }
    }

    public required IReadOnlyList<AuditEvent> Results
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<AuditEvent>>("results"); }
        init
        {
            this._rawData.Set<ImmutableArray<AuditEvent>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuditEventListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
