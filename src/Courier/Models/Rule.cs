using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<Rule, RuleFromRaw>))]
public sealed record class Rule : ModelBase
{
    public required string Until
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "until"); }
        init { ModelBase.Set(this._rawData, "until", value); }
    }

    public string? Start
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "start"); }
        init { ModelBase.Set(this._rawData, "start", value); }
    }

    public override void Validate()
    {
        _ = this.Until;
        _ = this.Start;
    }

    public Rule() { }

    public Rule(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Rule(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

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

class RuleFromRaw : IFromRaw<Rule>
{
    public Rule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Rule.FromRawUnchecked(rawData);
}
