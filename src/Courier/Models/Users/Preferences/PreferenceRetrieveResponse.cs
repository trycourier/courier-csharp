using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopicPreference>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopicPreference>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Deprecated - Paging not implemented on this endpoint
    /// </summary>
    public required Paging Paging
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Paging>("paging");
        }
        init { this._rawData.Set("paging", value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceRetrieveResponse(PreferenceRetrieveResponse preferenceRetrieveResponse)
        : base(preferenceRetrieveResponse) { }
#pragma warning restore CS8618

    public PreferenceRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
