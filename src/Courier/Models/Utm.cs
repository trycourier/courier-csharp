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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("campaign");
        }
        init { this._rawData.Set("campaign", value); }
    }

    public string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public string? Medium
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("medium");
        }
        init { this._rawData.Set("medium", value); }
    }

    public string? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public string? Term
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("term");
        }
        init { this._rawData.Set("term", value); }
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
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Utm(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
