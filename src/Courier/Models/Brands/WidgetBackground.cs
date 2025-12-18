using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<WidgetBackground, WidgetBackgroundFromRaw>))]
public sealed record class WidgetBackground : JsonModel
{
    public string? BottomColor
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "bottomColor"); }
        init { JsonModel.Set(this._rawData, "bottomColor", value); }
    }

    public string? TopColor
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "topColor"); }
        init { JsonModel.Set(this._rawData, "topColor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BottomColor;
        _ = this.TopColor;
    }

    public WidgetBackground() { }

    public WidgetBackground(WidgetBackground widgetBackground)
        : base(widgetBackground) { }

    public WidgetBackground(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WidgetBackground(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WidgetBackgroundFromRaw.FromRawUnchecked"/>
    public static WidgetBackground FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WidgetBackgroundFromRaw : IFromRawJson<WidgetBackground>
{
    /// <inheritdoc/>
    public WidgetBackground FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WidgetBackground.FromRawUnchecked(rawData);
}
