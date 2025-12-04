using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<WidgetBackground, WidgetBackgroundFromRaw>))]
public sealed record class WidgetBackground : ModelBase
{
    public string? BottomColor
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "bottomColor"); }
        init { ModelBase.Set(this._rawData, "bottomColor", value); }
    }

    public string? TopColor
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "topColor"); }
        init { ModelBase.Set(this._rawData, "topColor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BottomColor;
        _ = this.TopColor;
    }

    public WidgetBackground() { }

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

class WidgetBackgroundFromRaw : IFromRaw<WidgetBackground>
{
    /// <inheritdoc/>
    public WidgetBackground FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WidgetBackground.FromRawUnchecked(rawData);
}
