using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models;

[JsonConverter(typeof(JsonModelConverter<Timeouts, TimeoutsFromRaw>))]
public sealed record class Timeouts : JsonModel
{
    public long? Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    public long? Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("provider");
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channel;
        _ = this.Provider;
    }

    public Timeouts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Timeouts(Timeouts timeouts)
        : base(timeouts) { }
#pragma warning restore CS8618

    public Timeouts(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Timeouts(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimeoutsFromRaw.FromRawUnchecked"/>
    public static Timeouts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimeoutsFromRaw : IFromRawJson<Timeouts>
{
    /// <inheritdoc/>
    public Timeouts FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Timeouts.FromRawUnchecked(rawData);
}
