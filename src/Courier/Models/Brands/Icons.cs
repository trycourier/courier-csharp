using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<Icons, IconsFromRaw>))]
public sealed record class Icons : JsonModel
{
    public string? Bell
    {
        get { return this._rawData.GetNullableClass<string>("bell"); }
        init { this._rawData.Set("bell", value); }
    }

    public string? Message
    {
        get { return this._rawData.GetNullableClass<string>("message"); }
        init { this._rawData.Set("message", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bell;
        _ = this.Message;
    }

    public Icons() { }

    public Icons(Icons icons)
        : base(icons) { }

    public Icons(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Icons(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IconsFromRaw.FromRawUnchecked"/>
    public static Icons FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IconsFromRaw : IFromRawJson<Icons>
{
    /// <inheritdoc/>
    public Icons FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Icons.FromRawUnchecked(rawData);
}
