using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Previews;

/// <summary>
/// One mail app on one platform, operating system and theme that a preview can be
/// rendered on. Reference data, identical for every workspace. Every field is always
/// present; `platform` and `platform_version` are null where they do not apply.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PreviewDevice, PreviewDeviceFromRaw>))]
public sealed record class PreviewDevice : JsonModel
{
    /// <summary>
    /// The device's identifier, used in `device_ids` when creating a device set or
    /// a run.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The mail app. For webmail it is the service (`outlook_com`, `gmail_com`);
    /// for mobile the app (`apple_mail`, `gmail`); for desktop the app together
    /// with the version it is sold under (`outlook_2019`, `outlook_microsoft_365`,
    /// `apple_mail_16`), because that version is what separates one desktop Outlook
    /// from another.
    /// </summary>
    public required string App
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("app");
        }
        init { this._rawData.Set("app", value); }
    }

    /// <summary>
    /// Where the app runs.
    /// </summary>
    public required ApiEnum<string, Category> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Category>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// Display name. Render it as-is rather than parsing it. It is also what separates
    /// the two 120-dpi Outlook renders from their 100% siblings, which are otherwise
    /// identical field for field.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The operating system.
    /// </summary>
    public required string Os
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("os");
        }
        init { this._rawData.Set("os", value); }
    }

    /// <summary>
    /// The operating system's version. Always set.
    /// </summary>
    public required string OsVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("os_version");
        }
        init { this._rawData.Set("os_version", value); }
    }

    /// <summary>
    /// What the app runs on — the browser for webmail (`chrome`, `edge`, `firefox`),
    /// the phone for mobile (`iphone`, `pixel`). Null for desktop, where the app
    /// runs on nothing but the OS.
    /// </summary>
    public required string? Platform
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("platform");
        }
        init { this._rawData.Set("platform", value); }
    }

    /// <summary>
    /// Which one of the platform — the phone model for mobile (`15_pro_max`, `10`).
    /// Null for webmail, which always renders in the current browser, and for desktop.
    /// </summary>
    public required string? PlatformVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("platform_version");
        }
        init { this._rawData.Set("platform_version", value); }
    }

    /// <summary>
    /// Whether the email is rendered in light or dark mode.
    /// </summary>
    public required ApiEnum<string, Theme> Theme
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Theme>>("theme");
        }
        init { this._rawData.Set("theme", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.App;
        this.Category.Validate();
        _ = this.Name;
        _ = this.Os;
        _ = this.OsVersion;
        _ = this.Platform;
        _ = this.PlatformVersion;
        this.Theme.Validate();
    }

    public PreviewDevice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreviewDevice(PreviewDevice previewDevice)
        : base(previewDevice) { }
#pragma warning restore CS8618

    public PreviewDevice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreviewDevice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreviewDeviceFromRaw.FromRawUnchecked"/>
    public static PreviewDevice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreviewDeviceFromRaw : IFromRawJson<PreviewDevice>
{
    /// <inheritdoc/>
    public PreviewDevice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PreviewDevice.FromRawUnchecked(rawData);
}

/// <summary>
/// Where the app runs.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    Webmail,
    Mobile,
    Desktop,
}

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "webmail" => Category.Webmail,
            "mobile" => Category.Mobile,
            "desktop" => Category.Desktop,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.Webmail => "webmail",
                Category.Mobile => "mobile",
                Category.Desktop => "desktop",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Whether the email is rendered in light or dark mode.
/// </summary>
[JsonConverter(typeof(ThemeConverter))]
public enum Theme
{
    Light,
    Dark,
}

sealed class ThemeConverter : JsonConverter<Theme>
{
    public override Theme Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "light" => Theme.Light,
            "dark" => Theme.Dark,
            _ => (Theme)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Theme value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Theme.Light => "light",
                Theme.Dark => "dark",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
