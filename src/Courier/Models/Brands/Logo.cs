using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<Logo, LogoFromRaw>))]
public sealed record class Logo : JsonModel
{
    public string? Href
    {
        get { return this._rawData.GetNullableClass<string>("href"); }
        init { this._rawData.Set("href", value); }
    }

    public string? Image
    {
        get { return this._rawData.GetNullableClass<string>("image"); }
        init { this._rawData.Set("image", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Href;
        _ = this.Image;
    }

    public Logo() { }

    public Logo(Logo logo)
        : base(logo) { }

    public Logo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Logo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LogoFromRaw.FromRawUnchecked"/>
    public static Logo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LogoFromRaw : IFromRawJson<Logo>
{
    /// <inheritdoc/>
    public Logo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Logo.FromRawUnchecked(rawData);
}
