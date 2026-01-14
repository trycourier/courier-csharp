using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<IntercomRecipient, IntercomRecipientFromRaw>))]
public sealed record class IntercomRecipient : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public IntercomRecipient() { }

    public IntercomRecipient(IntercomRecipient intercomRecipient)
        : base(intercomRecipient) { }

    public IntercomRecipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntercomRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntercomRecipientFromRaw.FromRawUnchecked"/>
    public static IntercomRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntercomRecipient(string id)
        : this()
    {
        this.ID = id;
    }
}

class IntercomRecipientFromRaw : IFromRawJson<IntercomRecipient>
{
    /// <inheritdoc/>
    public IntercomRecipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IntercomRecipient.FromRawUnchecked(rawData);
}
