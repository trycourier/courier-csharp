using System.Collections.Frozen;
using System.Collections.Generic;
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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "audience_id"); }
        init { JsonModel.Set(this._rawData, "audience_id", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            return JsonModel.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawData,
                "data"
            );
        }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    public IReadOnlyList<AudienceFilter>? Filters
    {
        get { return JsonModel.GetNullableClass<List<AudienceFilter>>(this.RawData, "filters"); }
        init { JsonModel.Set(this._rawData, "filters", value); }
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

    public AudienceRecipient(AudienceRecipient audienceRecipient)
        : base(audienceRecipient) { }

    public AudienceRecipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudienceRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
