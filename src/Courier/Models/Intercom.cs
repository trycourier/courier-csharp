using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<Intercom, IntercomFromRaw>))]
public sealed record class Intercom : JsonModel
{
    public required string From
    {
        get { return this._rawData.GetNotNullClass<string>("from"); }
        init { this._rawData.Set("from", value); }
    }

    public required IntercomRecipient To
    {
        get { return this._rawData.GetNotNullClass<IntercomRecipient>("to"); }
        init { this._rawData.Set("to", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.From;
        this.To.Validate();
    }

    public Intercom() { }

    public Intercom(Intercom intercom)
        : base(intercom) { }

    public Intercom(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Intercom(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntercomFromRaw.FromRawUnchecked"/>
    public static Intercom FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntercomFromRaw : IFromRawJson<Intercom>
{
    /// <inheritdoc/>
    public Intercom FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Intercom.FromRawUnchecked(rawData);
}
