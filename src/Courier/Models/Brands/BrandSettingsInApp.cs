using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandSettingsInApp>))]
public sealed record class BrandSettingsInApp : ModelBase, IFromRaw<BrandSettingsInApp>
{
    public required BrandColors Colors
    {
        get
        {
            if (!this._rawData.TryGetValue("colors", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'colors' cannot be null",
                    new System::ArgumentOutOfRangeException("colors", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BrandColors>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'colors' cannot be null",
                    new System::ArgumentNullException("colors")
                );
        }
        init
        {
            this._rawData["colors"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Icons Icons
    {
        get
        {
            if (!this._rawData.TryGetValue("icons", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'icons' cannot be null",
                    new System::ArgumentOutOfRangeException("icons", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Icons>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'icons' cannot be null",
                    new System::ArgumentNullException("icons")
                );
        }
        init
        {
            this._rawData["icons"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required WidgetBackground WidgetBackground
    {
        get
        {
            if (!this._rawData.TryGetValue("widgetBackground", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'widgetBackground' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "widgetBackground",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<WidgetBackground>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new CourierInvalidDataException(
                    "'widgetBackground' cannot be null",
                    new System::ArgumentNullException("widgetBackground")
                );
        }
        init
        {
            this._rawData["widgetBackground"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? BorderRadius
    {
        get
        {
            if (!this._rawData.TryGetValue("borderRadius", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["borderRadius"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? DisableMessageIcon
    {
        get
        {
            if (!this._rawData.TryGetValue("disableMessageIcon", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["disableMessageIcon"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? FontFamily
    {
        get
        {
            if (!this._rawData.TryGetValue("fontFamily", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["fontFamily"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, Placement>? Placement
    {
        get
        {
            if (!this._rawData.TryGetValue("placement", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Placement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["placement"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public BrandSettingsInApp(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSettingsInApp(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BrandSettingsInApp FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
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
