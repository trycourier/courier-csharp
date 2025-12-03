using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<Icons, IconsFromRaw>))]
public sealed record class Icons : ModelBase
{
    public string? Bell
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "bell"); }
        init { ModelBase.Set(this._rawData, "bell", value); }
    }

    public string? Message
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "message"); }
        init { ModelBase.Set(this._rawData, "message", value); }
    }

    public override void Validate()
    {
        _ = this.Bell;
        _ = this.Message;
    }

    public Icons() { }

    public Icons(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Icons(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Icons FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IconsFromRaw : IFromRaw<Icons>
{
    public Icons FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Icons.FromRawUnchecked(rawData);
}
