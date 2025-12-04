using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Lists;

[JsonConverter(typeof(ModelConverter<PutSubscriptionsRecipient, PutSubscriptionsRecipientFromRaw>))]
public sealed record class PutSubscriptionsRecipient : ModelBase
{
    public required string RecipientID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "recipientId"); }
        init { ModelBase.Set(this._rawData, "recipientId", value); }
    }

    public RecipientPreferences? Preferences
    {
        get
        {
            return ModelBase.GetNullableClass<RecipientPreferences>(this.RawData, "preferences");
        }
        init { ModelBase.Set(this._rawData, "preferences", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RecipientID;
        this.Preferences?.Validate();
    }

    public PutSubscriptionsRecipient() { }

    public PutSubscriptionsRecipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PutSubscriptionsRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class PutSubscriptionsRecipientFromRaw : IFromRaw<PutSubscriptionsRecipient>
{
    /// <inheritdoc/>
    public PutSubscriptionsRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PutSubscriptionsRecipient.FromRawUnchecked(rawData);
}
