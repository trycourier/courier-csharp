using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Providers;

/// <summary>
/// A provider type from the catalog. Contains the key, display name, description,
/// and a `settings` object describing configuration schema fields.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ProvidersCatalogEntry, ProvidersCatalogEntryFromRaw>))]
public sealed record class ProvidersCatalogEntry : JsonModel
{
    /// <summary>
    /// Courier taxonomy channel (e.g. email, push, sms, direct_message, inbox, webhook).
    /// </summary>
    public required string Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <summary>
    /// Short description of the provider.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Human-readable display name.
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
    /// The provider key (e.g. "sendgrid", "twilio").
    /// </summary>
    public required string Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("provider");
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// Map of setting field names (snake_case) to their schema descriptors. Each
    /// descriptor has `type` and `required`. Empty when the provider has no configurable schema.
    /// </summary>
    public required IReadOnlyDictionary<string, SettingsItem> Settings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, SettingsItem>>(
                "settings"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, SettingsItem>>(
                "settings",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channel;
        _ = this.Description;
        _ = this.Name;
        _ = this.Provider;
        foreach (var item in this.Settings.Values)
        {
            item.Validate();
        }
    }

    public ProvidersCatalogEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProvidersCatalogEntry(ProvidersCatalogEntry providersCatalogEntry)
        : base(providersCatalogEntry) { }
#pragma warning restore CS8618

    public ProvidersCatalogEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProvidersCatalogEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProvidersCatalogEntryFromRaw.FromRawUnchecked"/>
    public static ProvidersCatalogEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProvidersCatalogEntryFromRaw : IFromRawJson<ProvidersCatalogEntry>
{
    /// <inheritdoc/>
    public ProvidersCatalogEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ProvidersCatalogEntry.FromRawUnchecked(rawData);
}

/// <summary>
/// Describes a single configuration field in the provider catalog.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SettingsItem, SettingsItemFromRaw>))]
public sealed record class SettingsItem : JsonModel
{
    /// <summary>
    /// Whether this field is required when configuring the provider.
    /// </summary>
    public required bool Required
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("required");
        }
        init { this._rawData.Set("required", value); }
    }

    /// <summary>
    /// The field's data type (e.g. "string", "boolean", "enum").
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Allowed values when `type` is "enum".
    /// </summary>
    public IReadOnlyList<string>? Values
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("values");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "values",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Required;
        _ = this.Type;
        _ = this.Values;
    }

    public SettingsItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SettingsItem(SettingsItem settingsItem)
        : base(settingsItem) { }
#pragma warning restore CS8618

    public SettingsItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SettingsItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SettingsItemFromRaw.FromRawUnchecked"/>
    public static SettingsItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SettingsItemFromRaw : IFromRawJson<SettingsItem>
{
    /// <inheritdoc/>
    public SettingsItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SettingsItem.FromRawUnchecked(rawData);
}
