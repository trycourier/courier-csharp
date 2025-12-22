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
        get { return JsonModel.GetNullableClass<string>(this.RawData, "event_action"); }
        init { JsonModel.Set(this._rawData, "event_action", value); }
    }

    public string? RoutingKey
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "routing_key"); }
        init { JsonModel.Set(this._rawData, "routing_key", value); }
    }

    public string? Severity
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "severity"); }
        init { JsonModel.Set(this._rawData, "severity", value); }
    }

    public string? Source
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "source"); }
        init { JsonModel.Set(this._rawData, "source", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pagerduty(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
