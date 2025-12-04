using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Lists;

[JsonConverter(typeof(ModelConverter<SubscriptionList, SubscriptionListFromRaw>))]
public sealed record class SubscriptionList : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public string? Created
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "created"); }
        init { ModelBase.Set(this._rawData, "created", value); }
    }

    public string? Updated
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "updated"); }
        init { ModelBase.Set(this._rawData, "updated", value); }
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

    public SubscriptionList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubscriptionList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class SubscriptionListFromRaw : IFromRaw<SubscriptionList>
{
    /// <inheritdoc/>
    public SubscriptionList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SubscriptionList.FromRawUnchecked(rawData);
}
