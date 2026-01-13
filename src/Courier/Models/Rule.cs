using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<Rule, RuleFromRaw>))]
public sealed record class Rule : JsonModel
{
    public required string Until
    {
        get { return this._rawData.GetNotNullClass<string>("until"); }
        init { this._rawData.Set("until", value); }
    }

    public string? Start
    {
        get { return this._rawData.GetNullableClass<string>("start"); }
        init { this._rawData.Set("start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Until;
        _ = this.Start;
    }

    public Rule() { }

    public Rule(Rule rule)
        : base(rule) { }

    public Rule(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Rule(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RuleFromRaw.FromRawUnchecked"/>
    public static Rule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Rule(string until)
        : this()
    {
        this.Until = until;
    }
}

class RuleFromRaw : IFromRawJson<Rule>
{
    /// <inheritdoc/>
    public Rule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Rule.FromRawUnchecked(rawData);
}
