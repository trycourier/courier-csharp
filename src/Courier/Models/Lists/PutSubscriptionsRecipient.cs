using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Lists;

[JsonConverter(
    typeof(JsonModelConverter<PutSubscriptionsRecipient, PutSubscriptionsRecipientFromRaw>)
)]
public sealed record class PutSubscriptionsRecipient : JsonModel
{
    public required string RecipientID
    {
        get { return this._rawData.GetNotNullClass<string>("recipientId"); }
        init { this._rawData.Set("recipientId", value); }
    }

    public RecipientPreferences? Preferences
    {
        get { return this._rawData.GetNullableClass<RecipientPreferences>("preferences"); }
        init { this._rawData.Set("preferences", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecipientID;
        this.Preferences?.Validate();
    }

    public PutSubscriptionsRecipient() { }

    public PutSubscriptionsRecipient(PutSubscriptionsRecipient putSubscriptionsRecipient)
        : base(putSubscriptionsRecipient) { }

    public PutSubscriptionsRecipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PutSubscriptionsRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PutSubscriptionsRecipientFromRaw.FromRawUnchecked"/>
    public static PutSubscriptionsRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PutSubscriptionsRecipient(string recipientID)
        : this()
    {
        this.RecipientID = recipientID;
    }
}

class PutSubscriptionsRecipientFromRaw : IFromRawJson<PutSubscriptionsRecipient>
{
    /// <inheritdoc/>
    public PutSubscriptionsRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PutSubscriptionsRecipient.FromRawUnchecked(rawData);
}
