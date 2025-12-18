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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "listId"); }
        init { JsonModel.Set(this._rawData, "listId", value); }
    }

    public RecipientPreferences? Preferences
    {
        get
        {
            return JsonModel.GetNullableClass<RecipientPreferences>(this.RawData, "preferences");
        }
        init { JsonModel.Set(this._rawData, "preferences", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ListID;
        this.Preferences?.Validate();
    }

    public SubscribeToListsRequestItem() { }

    public SubscribeToListsRequestItem(SubscribeToListsRequestItem subscribeToListsRequestItem)
        : base(subscribeToListsRequestItem) { }

    public SubscribeToListsRequestItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscribeToListsRequestItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
