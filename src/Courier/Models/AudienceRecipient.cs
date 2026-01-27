using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

/// <summary>
/// Send to all users in an audience
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AudienceRecipient, AudienceRecipientFromRaw>))]
public sealed record class AudienceRecipient : JsonModel
{
    /// <summary>
    /// A unique identifier associated with an Audience. A message will be sent to
    /// each user in the audience.
    /// </summary>
    public required string AudienceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("audience_id");
        }
        init { this._rawData.Set("audience_id", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("data");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyList<AudienceFilter>? Filters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AudienceFilter>>("filters");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AudienceFilter>?>(
                "filters",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AudienceID;
        _ = this.Data;
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
    }

    public AudienceRecipient() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AudienceRecipient(AudienceRecipient audienceRecipient)
        : base(audienceRecipient) { }
#pragma warning restore CS8618

    public AudienceRecipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudienceRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudienceRecipientFromRaw.FromRawUnchecked"/>
    public static AudienceRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AudienceRecipient(string audienceID)
        : this()
    {
        this.AudienceID = audienceID;
    }
}

class AudienceRecipientFromRaw : IFromRawJson<AudienceRecipient>
{
    /// <inheritdoc/>
    public AudienceRecipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AudienceRecipient.FromRawUnchecked(rawData);
}
