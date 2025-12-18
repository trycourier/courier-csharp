using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Users.Preferences;

[JsonConverter(
    typeof(JsonModelConverter<PreferenceRetrieveResponse, PreferenceRetrieveResponseFromRaw>)
)]
public sealed record class PreferenceRetrieveResponse : JsonModel
{
    /// <summary>
    /// The Preferences associated with the user_id.
    /// </summary>
    public required IReadOnlyList<TopicPreference> Items
    {
        get { return JsonModel.GetNotNullClass<List<TopicPreference>>(this.RawData, "items"); }
        init { JsonModel.Set(this._rawData, "items", value); }
    }

    /// <summary>
    /// Deprecated - Paging not implemented on this endpoint
    /// </summary>
    public required Paging Paging
    {
        get { return JsonModel.GetNotNullClass<Paging>(this.RawData, "paging"); }
        init { JsonModel.Set(this._rawData, "paging", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        this.Paging.Validate();
    }

    public PreferenceRetrieveResponse() { }

    public PreferenceRetrieveResponse(PreferenceRetrieveResponse preferenceRetrieveResponse)
        : base(preferenceRetrieveResponse) { }

    public PreferenceRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static PreferenceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreferenceRetrieveResponseFromRaw : IFromRawJson<PreferenceRetrieveResponse>
{
    /// <inheritdoc/>
    public PreferenceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceRetrieveResponse.FromRawUnchecked(rawData);
}
