using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

/// <summary>
/// Send via PagerDuty
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PagerdutyRecipient, PagerdutyRecipientFromRaw>))]
public sealed record class PagerdutyRecipient : JsonModel
{
    public required Pagerduty Pagerduty
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Pagerduty>("pagerduty");
        }
        init { this._rawData.Set("pagerduty", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Pagerduty.Validate();
    }

    public PagerdutyRecipient() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PagerdutyRecipient(PagerdutyRecipient pagerdutyRecipient)
        : base(pagerdutyRecipient) { }
#pragma warning restore CS8618

    public PagerdutyRecipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PagerdutyRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PagerdutyRecipientFromRaw.FromRawUnchecked"/>
    public static PagerdutyRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PagerdutyRecipient(Pagerduty pagerduty)
        : this()
    {
        this.Pagerduty = pagerduty;
    }
}

class PagerdutyRecipientFromRaw : IFromRawJson<PagerdutyRecipient>
{
    /// <inheritdoc/>
    public PagerdutyRecipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PagerdutyRecipient.FromRawUnchecked(rawData);
}
