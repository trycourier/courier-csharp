using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Profiles;

[JsonConverter(typeof(ModelConverter<SubscribeToListsRequestItem>))]
public sealed record class SubscribeToListsRequestItem
    : ModelBase,
        IFromRaw<SubscribeToListsRequestItem>
{
    public required string ListID
    {
        get
        {
            if (!this._rawData.TryGetValue("listId", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'listId' cannot be null",
                    new ArgumentOutOfRangeException("listId", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'listId' cannot be null",
                    new ArgumentNullException("listId")
                );
        }
        init
        {
            this._rawData["listId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public RecipientPreferences? Preferences
    {
        get
        {
            if (!this._rawData.TryGetValue("preferences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<RecipientPreferences?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["preferences"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ListID;
        this.Preferences?.Validate();
    }

    public SubscribeToListsRequestItem() { }

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
