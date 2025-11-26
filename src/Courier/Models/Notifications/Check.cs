using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Notifications;

[JsonConverter(typeof(ModelConverter<Check, CheckFromRaw>))]
public sealed record class Check : ModelBase
{
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Status> Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Courier.Models.Notifications.Type> Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Courier.Models.Notifications.Type>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Updated
    {
        get
        {
            if (!this._rawData.TryGetValue("updated", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'updated' cannot be null",
                    new ArgumentOutOfRangeException("updated", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["updated"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator BaseCheck(Check check) =>
        new()
        {
            ID = check.ID,
            Status = check.Status,
            Type = check.Type,
        };

    public override void Validate()
    {
        _ = this.ID;
        this.Status.Validate();
        this.Type.Validate();
        _ = this.Updated;
    }

    public Check() { }

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

    public static Check FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CheckFromRaw : IFromRaw<Check>
{
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
        get
        {
            if (!this._rawData.TryGetValue("updated", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'updated' cannot be null",
                    new ArgumentOutOfRangeException("updated", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["updated"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Updated;
    }

    public IntersectionMember1() { }

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
    public global::Courier.Models.Notifications.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Courier.Models.Notifications.IntersectionMember1.FromRawUnchecked(rawData);
}
