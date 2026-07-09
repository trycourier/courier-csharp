using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Users.Preferences;

[JsonConverter(
    typeof(JsonModelConverter<PreferenceBulkReplaceResponse, PreferenceBulkReplaceResponseFromRaw>)
)]
public sealed record class PreferenceBulkReplaceResponse : JsonModel
{
    /// <summary>
    /// The ids of the overrides that were reset to their topic default.
    /// </summary>
    public required IReadOnlyList<string> Deleted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("deleted");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "deleted",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The complete resulting set of topic overrides for the user.
    /// </summary>
    public required IReadOnlyList<BulkPreferenceTopic> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BulkPreferenceTopic>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BulkPreferenceTopic>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Deleted;
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public PreferenceBulkReplaceResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PreferenceBulkReplaceResponse(
        PreferenceBulkReplaceResponse preferenceBulkReplaceResponse
    )
        : base(preferenceBulkReplaceResponse) { }
#pragma warning restore CS8618

    public PreferenceBulkReplaceResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PreferenceBulkReplaceResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PreferenceBulkReplaceResponseFromRaw.FromRawUnchecked"/>
    public static PreferenceBulkReplaceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PreferenceBulkReplaceResponseFromRaw : IFromRawJson<PreferenceBulkReplaceResponse>
{
    /// <inheritdoc/>
    public PreferenceBulkReplaceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PreferenceBulkReplaceResponse.FromRawUnchecked(rawData);
}
