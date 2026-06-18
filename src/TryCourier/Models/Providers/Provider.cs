using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Providers;

/// <summary>
/// A configured provider in the workspace.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Provider, ProviderFromRaw>))]
public sealed record class Provider : JsonModel
{
    /// <summary>
    /// A unique identifier for the provider configuration.
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
    /// Unix timestamp (ms) of when the provider was created.
    /// </summary>
    public required long Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    /// <summary>
    /// The provider key (e.g. "sendgrid", "twilio", "slack").
    /// </summary>
    public required string ProviderValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("provider");
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <summary>
    /// Provider-specific settings (snake_case keys on the wire).
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> Settings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("settings");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "settings",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Display title. Defaults to "Default Configuration" when not explicitly set.
    /// </summary>
    public required string Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <summary>
    /// Optional alias for this configuration.
    /// </summary>
    public string? Alias
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("alias");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("alias", value);
        }
    }

    /// <summary>
    /// Unix timestamp (ms) of when the provider was last updated.
    /// </summary>
    public long? Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("updated");
        }
        init { this._rawData.Set("updated", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Created;
        _ = this.ProviderValue;
        _ = this.Settings;
        _ = this.Title;
        _ = this.Alias;
        _ = this.Updated;
    }

    public Provider() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Provider(Provider provider)
        : base(provider) { }
#pragma warning restore CS8618

    public Provider(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Provider(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProviderFromRaw.FromRawUnchecked"/>
    public static Provider FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProviderFromRaw : IFromRawJson<Provider>
{
    /// <inheritdoc/>
    public Provider FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Provider.FromRawUnchecked(rawData);
}
