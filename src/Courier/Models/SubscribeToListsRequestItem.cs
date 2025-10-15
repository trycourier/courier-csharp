using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<SubscribeToListsRequestItem>))]
public sealed record class SubscribeToListsRequestItem
    : ModelBase,
        IFromRaw<SubscribeToListsRequestItem>
{
    public required string ListID
    {
        get
        {
            if (!this.Properties.TryGetValue("listId", out JsonElement element))
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
        set
        {
            this.Properties["listId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public RecipientPreferences? Preferences
    {
        get
        {
            if (!this.Properties.TryGetValue("preferences", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<RecipientPreferences?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["preferences"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscribeToListsRequestItem(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubscribeToListsRequestItem FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public SubscribeToListsRequestItem(string listID)
        : this()
    {
        this.ListID = listID;
    }
}
