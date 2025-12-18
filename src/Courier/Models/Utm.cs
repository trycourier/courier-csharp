using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<Utm, UtmFromRaw>))]
public sealed record class Utm : JsonModel
{
    public string? Campaign
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "campaign"); }
        init { JsonModel.Set(this._rawData, "campaign", value); }
    }

    public string? Content
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "content"); }
        init { JsonModel.Set(this._rawData, "content", value); }
    }

    public string? Medium
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "medium"); }
        init { JsonModel.Set(this._rawData, "medium", value); }
    }

    public string? Source
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "source"); }
        init { JsonModel.Set(this._rawData, "source", value); }
    }

    public string? Term
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "term"); }
        init { JsonModel.Set(this._rawData, "term", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Campaign;
        _ = this.Content;
        _ = this.Medium;
        _ = this.Source;
        _ = this.Term;
    }

    public Utm() { }

    public Utm(Utm utm)
        : base(utm) { }

    public Utm(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Utm(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UtmFromRaw.FromRawUnchecked"/>
    public static Utm FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UtmFromRaw : IFromRawJson<Utm>
{
    /// <inheritdoc/>
    public Utm FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Utm.FromRawUnchecked(rawData);
}
