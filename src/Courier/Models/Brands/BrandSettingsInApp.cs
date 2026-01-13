using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandSettingsInApp, BrandSettingsInAppFromRaw>))]
public sealed record class BrandSettingsInApp : JsonModel
{
    public required BrandColors Colors
    {
        get { return this._rawData.GetNotNullClass<BrandColors>("colors"); }
        init { this._rawData.Set("colors", value); }
    }

    public required Icons Icons
    {
        get { return this._rawData.GetNotNullClass<Icons>("icons"); }
        init { this._rawData.Set("icons", value); }
    }

    public required WidgetBackground WidgetBackground
    {
        get { return this._rawData.GetNotNullClass<WidgetBackground>("widgetBackground"); }
        init { this._rawData.Set("widgetBackground", value); }
    }

    public string? BorderRadius
    {
        get { return this._rawData.GetNullableClass<string>("borderRadius"); }
        init { this._rawData.Set("borderRadius", value); }
    }

    public bool? DisableMessageIcon
    {
        get { return this._rawData.GetNullableStruct<bool>("disableMessageIcon"); }
        init { this._rawData.Set("disableMessageIcon", value); }
    }

    public string? FontFamily
    {
        get { return this._rawData.GetNullableClass<string>("fontFamily"); }
        init { this._rawData.Set("fontFamily", value); }
    }

    public ApiEnum<string, Placement>? Placement
    {
        get { return this._rawData.GetNullableClass<ApiEnum<string, Placement>>("placement"); }
        init { this._rawData.Set("placement", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Colors.Validate();
        this.Icons.Validate();
        this.WidgetBackground.Validate();
        _ = this.BorderRadius;
        _ = this.DisableMessageIcon;
        _ = this.FontFamily;
        this.Placement?.Validate();
    }

    public BrandSettingsInApp() { }

    public BrandSettingsInApp(BrandSettingsInApp brandSettingsInApp)
        : base(brandSettingsInApp) { }

    public BrandSettingsInApp(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSettingsInApp(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandSettingsInAppFromRaw.FromRawUnchecked"/>
    public static BrandSettingsInApp FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandSettingsInAppFromRaw : IFromRawJson<BrandSettingsInApp>
{
    /// <inheritdoc/>
    public BrandSettingsInApp FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandSettingsInApp.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PlacementConverter))]
public enum Placement
{
    Top,
    Bottom,
    Left,
    Right,
}

sealed class PlacementConverter : JsonConverter<Placement>
{
    public override Placement Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "top" => Placement.Top,
            "bottom" => Placement.Bottom,
            "left" => Placement.Left,
            "right" => Placement.Right,
            _ => (Placement)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Placement value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Placement.Top => "top",
                Placement.Bottom => "bottom",
                Placement.Left => "left",
                Placement.Right => "right",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
