using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<Pagerduty, PagerdutyFromRaw>))]
public sealed record class Pagerduty : JsonModel
{
    public string? EventAction
    {
        get { return this._rawData.GetNullableClass<string>("event_action"); }
        init { this._rawData.Set("event_action", value); }
    }

    public string? RoutingKey
    {
        get { return this._rawData.GetNullableClass<string>("routing_key"); }
        init { this._rawData.Set("routing_key", value); }
    }

    public string? Severity
    {
        get { return this._rawData.GetNullableClass<string>("severity"); }
        init { this._rawData.Set("severity", value); }
    }

    public string? Source
    {
        get { return this._rawData.GetNullableClass<string>("source"); }
        init { this._rawData.Set("source", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EventAction;
        _ = this.RoutingKey;
        _ = this.Severity;
        _ = this.Source;
    }

    public Pagerduty() { }

    public Pagerduty(Pagerduty pagerduty)
        : base(pagerduty) { }

    public Pagerduty(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pagerduty(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PagerdutyFromRaw.FromRawUnchecked"/>
    public static Pagerduty FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PagerdutyFromRaw : IFromRawJson<Pagerduty>
{
    /// <inheritdoc/>
    public Pagerduty FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Pagerduty.FromRawUnchecked(rawData);
}
