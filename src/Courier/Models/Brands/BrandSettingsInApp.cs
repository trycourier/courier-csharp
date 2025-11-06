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
            if (!this._properties.TryGetValue("colors", out JsonElement element))
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
            this._properties["colors"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Icons Icons
    {
        get
        {
            if (!this._properties.TryGetValue("icons", out JsonElement element))
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
            this._properties["icons"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required WidgetBackground WidgetBackground
    {
        get
        {
            if (!this._properties.TryGetValue("widgetBackground", out JsonElement element))
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
            this._properties["widgetBackground"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? BorderRadius
    {
        get
        {
            if (!this._properties.TryGetValue("borderRadius", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["borderRadius"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? DisableMessageIcon
    {
        get
        {
            if (!this._properties.TryGetValue("disableMessageIcon", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["disableMessageIcon"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? FontFamily
    {
        get
        {
            if (!this._properties.TryGetValue("fontFamily", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["fontFamily"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, Placement>? Placement
    {
        get
        {
            if (!this._properties.TryGetValue("placement", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Placement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["placement"] = JsonSerializer.SerializeToElement(
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

    public BrandSettingsInApp(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSettingsInApp(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BrandSettingsInApp FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
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
