using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Profiles;

[JsonConverter(
    typeof(JsonModelConverter<SubscribeToListsRequestItem, SubscribeToListsRequestItemFromRaw>)
)]
public sealed record class SubscribeToListsRequestItem : JsonModel
{
    public required string ListID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("listId");
        }
        init { this._rawData.Set("listId", value); }
    }

    public RecipientPreferences? Preferences
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RecipientPreferences>("preferences");
        }
        init { this._rawData.Set("preferences", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ListID;
        this.Preferences?.Validate();
    }

    public SubscribeToListsRequestItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubscribeToListsRequestItem(SubscribeToListsRequestItem subscribeToListsRequestItem)
        : base(subscribeToListsRequestItem) { }
#pragma warning restore CS8618

    public SubscribeToListsRequestItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscribeToListsRequestItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscribeToListsRequestItemFromRaw.FromRawUnchecked"/>
    public static SubscribeToListsRequestItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubscribeToListsRequestItem(string listID)
        : this()
    {
        this.ListID = listID;
    }
}

class SubscribeToListsRequestItemFromRaw : IFromRawJson<SubscribeToListsRequestItem>
{
    /// <inheritdoc/>
    public SubscribeToListsRequestItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubscribeToListsRequestItem.FromRawUnchecked(rawData);
}
