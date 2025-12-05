using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Bulk;

[JsonConverter(typeof(ModelConverter<BulkListUsersResponse, BulkListUsersResponseFromRaw>))]
public sealed record class BulkListUsersResponse : ModelBase
{
    public required IReadOnlyList<Item> Items
    {
        get { return ModelBase.GetNotNullClass<List<Item>>(this.RawData, "items"); }
        init { ModelBase.Set(this._rawData, "items", value); }
    }

    public required Paging Paging
    {
        get { return ModelBase.GetNotNullClass<Paging>(this.RawData, "paging"); }
        init { ModelBase.Set(this._rawData, "paging", value); }
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

    public BulkListUsersResponse() { }

    public BulkListUsersResponse(BulkListUsersResponse bulkListUsersResponse)
        : base(bulkListUsersResponse) { }

    public BulkListUsersResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkListUsersResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BulkListUsersResponseFromRaw.FromRawUnchecked"/>
    public static BulkListUsersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BulkListUsersResponseFromRaw : IFromRaw<BulkListUsersResponse>
{
    /// <inheritdoc/>
    public BulkListUsersResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BulkListUsersResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : ModelBase
{
    public JsonElement? Data
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "data"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "data", value);
        }
    }

    public RecipientPreferences? Preferences
    {
        get
        {
            return ModelBase.GetNullableClass<RecipientPreferences>(this.RawData, "preferences");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "preferences", value);
        }
    }

    public JsonElement? Profile
    {
        get { return ModelBase.GetNullableStruct<JsonElement>(this.RawData, "profile"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "profile", value);
        }
    }

    public string? Recipient
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "recipient"); }
        init { ModelBase.Set(this._rawData, "recipient", value); }
    }

    public UserRecipient? To
    {
        get { return ModelBase.GetNullableClass<UserRecipient>(this.RawData, "to"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "to", value);
        }
    }

    public required ApiEnum<string, Status> Status
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<string, Status>>(this.RawData, "status"); }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    public string? MessageID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "messageId"); }
        init { ModelBase.Set(this._rawData, "messageId", value); }
    }

    public static implicit operator InboundBulkMessageUser(Item item) =>
        new()
        {
            Data = item.Data,
            Preferences = item.Preferences,
            Profile = item.Profile,
            Recipient = item.Recipient,
            To = item.To,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        this.Preferences?.Validate();
        _ = this.Profile;
        _ = this.Recipient;
        this.To?.Validate();
        this.Status.Validate();
        _ = this.MessageID;
    }

    public Item() { }

    public Item(Item item)
        : base(item) { }

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

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Item(ApiEnum<string, Status> status)
        : this()
    {
        this.Status = status;
    }
}

class ItemFromRaw : IFromRaw<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        global::Courier.Models.Bulk.IntersectionMember1,
        global::Courier.Models.Bulk.IntersectionMember1FromRaw
    >)
)]
public sealed record class IntersectionMember1 : ModelBase
{
    public required ApiEnum<string, Status> Status
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<string, Status>>(this.RawData, "status"); }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    public string? MessageID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "messageId"); }
        init { ModelBase.Set(this._rawData, "messageId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        _ = this.MessageID;
    }

    public IntersectionMember1() { }

    public IntersectionMember1(global::Courier.Models.Bulk.IntersectionMember1 intersectionMember1)
        : base(intersectionMember1) { }

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Courier.Models.Bulk.IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static global::Courier.Models.Bulk.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntersectionMember1(ApiEnum<string, Status> status)
        : this()
    {
        this.Status = status;
    }
}

class IntersectionMember1FromRaw : IFromRaw<global::Courier.Models.Bulk.IntersectionMember1>
{
    /// <inheritdoc/>
    public global::Courier.Models.Bulk.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Courier.Models.Bulk.IntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending,
    Enqueued,
    Error,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PENDING" => Status.Pending,
            "ENQUEUED" => Status.Enqueued,
            "ERROR" => Status.Error,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "PENDING",
                Status.Enqueued => "ENQUEUED",
                Status.Error => "ERROR",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
