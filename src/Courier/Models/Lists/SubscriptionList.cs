using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Lists;

[JsonConverter(typeof(JsonModelConverter<SubscriptionList, SubscriptionListFromRaw>))]
public sealed record class SubscriptionList : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public string? Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    public string? Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updated");
        }
        init { this._rawData.Set("updated", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        _ = this.Created;
        _ = this.Updated;
    }

    public SubscriptionList() { }

    public SubscriptionList(SubscriptionList subscriptionList)
        : base(subscriptionList) { }

    public SubscriptionList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionListFromRaw.FromRawUnchecked"/>
    public static SubscriptionList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriptionListFromRaw : IFromRawJson<SubscriptionList>
{
    /// <inheritdoc/>
    public SubscriptionList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SubscriptionList.FromRawUnchecked(rawData);
}
