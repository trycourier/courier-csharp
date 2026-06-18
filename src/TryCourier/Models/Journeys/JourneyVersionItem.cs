using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

/// <summary>
/// A published version of a journey.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneyVersionItem, JourneyVersionItemFromRaw>))]
public sealed record class JourneyVersionItem : JsonModel
{
    public required long? Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    public required string? Creator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("creator");
        }
        init { this._rawData.Set("creator", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required long? Published
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("published");
        }
        init { this._rawData.Set("published", value); }
    }

    public required string Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Created;
        _ = this.Creator;
        _ = this.Name;
        _ = this.Published;
        _ = this.Version;
    }

    public JourneyVersionItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneyVersionItem(JourneyVersionItem journeyVersionItem)
        : base(journeyVersionItem) { }
#pragma warning restore CS8618

    public JourneyVersionItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneyVersionItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneyVersionItemFromRaw.FromRawUnchecked"/>
    public static JourneyVersionItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneyVersionItemFromRaw : IFromRawJson<JourneyVersionItem>
{
    /// <inheritdoc/>
    public JourneyVersionItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JourneyVersionItem.FromRawUnchecked(rawData);
}
