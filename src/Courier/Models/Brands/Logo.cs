using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<Logo, LogoFromRaw>))]
public sealed record class Logo : ModelBase
{
    public string? Href
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "href"); }
        init { ModelBase.Set(this._rawData, "href", value); }
    }

    public string? Image
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "image"); }
        init { ModelBase.Set(this._rawData, "image", value); }
    }

    public override void Validate()
    {
        _ = this.Href;
        _ = this.Image;
    }

    public Logo() { }

    public Logo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Logo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Logo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LogoFromRaw : IFromRaw<Logo>
{
    public Logo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Logo.FromRawUnchecked(rawData);
}
