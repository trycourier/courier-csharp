using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Audiences;

[JsonConverter(
    typeof(ModelConverter<AudienceListMembersResponse, AudienceListMembersResponseFromRaw>)
)]
public sealed record class AudienceListMembersResponse : ModelBase
{
    public required List<Item> Items
    {
        get
        {
            if (!this._rawData.TryGetValue("items", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentOutOfRangeException("items", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Item>>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'items' cannot be null",
                    new ArgumentNullException("items")
                );
        }
        init
        {
            this._rawData["items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Paging Paging
    {
        get
        {
            if (!this._rawData.TryGetValue("paging", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'paging' cannot be null",
                    new ArgumentOutOfRangeException("paging", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Paging>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'paging' cannot be null",
                    new ArgumentNullException("paging")
                );
        }
        init
        {
            this._rawData["paging"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        this.Paging.Validate();
    }

    public AudienceListMembersResponse() { }

    public AudienceListMembersResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudienceListMembersResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AudienceListMembersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudienceListMembersResponseFromRaw : IFromRaw<AudienceListMembersResponse>
{
    public AudienceListMembersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AudienceListMembersResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : ModelBase
{
    public required string AddedAt
    {
        get
        {
            if (!this._rawData.TryGetValue("added_at", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'added_at' cannot be null",
                    new ArgumentOutOfRangeException("added_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'added_at' cannot be null",
                    new ArgumentNullException("added_at")
                );
        }
        init
        {
            this._rawData["added_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string AudienceID
    {
        get
        {
            if (!this._rawData.TryGetValue("audience_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'audience_id' cannot be null",
                    new ArgumentOutOfRangeException("audience_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'audience_id' cannot be null",
                    new ArgumentNullException("audience_id")
                );
        }
        init
        {
            this._rawData["audience_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long AudienceVersion
    {
        get
        {
            if (!this._rawData.TryGetValue("audience_version", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'audience_version' cannot be null",
                    new ArgumentOutOfRangeException("audience_version", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["audience_version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string MemberID
    {
        get
        {
            if (!this._rawData.TryGetValue("member_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'member_id' cannot be null",
                    new ArgumentOutOfRangeException("member_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'member_id' cannot be null",
                    new ArgumentNullException("member_id")
                );
        }
        init
        {
            this._rawData["member_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Reason
    {
        get
        {
            if (!this._rawData.TryGetValue("reason", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'reason' cannot be null",
                    new ArgumentOutOfRangeException("reason", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'reason' cannot be null",
                    new ArgumentNullException("reason")
                );
        }
        init
        {
            this._rawData["reason"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AddedAt;
        _ = this.AudienceID;
        _ = this.AudienceVersion;
        _ = this.MemberID;
        _ = this.Reason;
    }

    public Item() { }

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRaw<Item>
{
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}
