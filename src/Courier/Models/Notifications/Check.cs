using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Notifications;

[JsonConverter(typeof(ModelConverter<Check, CheckFromRaw>))]
public sealed record class Check : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public required ApiEnum<string, Status> Status
    {
        get { return ModelBase.GetNotNullClass<ApiEnum<string, Status>>(this.RawData, "status"); }
        init { ModelBase.Set(this._rawData, "status", value); }
    }

    public required ApiEnum<string, global::Courier.Models.Notifications.Type> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::Courier.Models.Notifications.Type>
            >(this.RawData, "type");
        }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    public required long Updated
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "updated"); }
        init { ModelBase.Set(this._rawData, "updated", value); }
    }

    public static implicit operator BaseCheck(Check check) =>
        new()
        {
            ID = check.ID,
            Status = check.Status,
            Type = check.Type,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Status.Validate();
        this.Type.Validate();
        _ = this.Updated;
    }

    public Check() { }

    public Check(Check check)
        : base(check) { }

    public Check(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Check(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CheckFromRaw.FromRawUnchecked"/>
    public static Check FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckFromRaw : IFromRaw<Check>
{
    /// <inheritdoc/>
    public Check FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Check.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        global::Courier.Models.Notifications.IntersectionMember1,
        global::Courier.Models.Notifications.IntersectionMember1FromRaw
    >)
)]
public sealed record class IntersectionMember1 : ModelBase
{
    public required long Updated
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "updated"); }
        init { ModelBase.Set(this._rawData, "updated", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Updated;
    }

    public IntersectionMember1() { }

    public IntersectionMember1(
        global::Courier.Models.Notifications.IntersectionMember1 intersectionMember1
    )
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

    /// <inheritdoc cref="global::Courier.Models.Notifications.IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static global::Courier.Models.Notifications.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntersectionMember1(long updated)
        : this()
    {
        this.Updated = updated;
    }
}

class IntersectionMember1FromRaw
    : IFromRaw<global::Courier.Models.Notifications.IntersectionMember1>
{
    /// <inheritdoc/>
    public global::Courier.Models.Notifications.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Courier.Models.Notifications.IntersectionMember1.FromRawUnchecked(rawData);
}
