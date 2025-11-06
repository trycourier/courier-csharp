using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Notifications;

[JsonConverter(typeof(ModelConverter<Check>))]
public sealed record class Check : ModelBase, IFromRaw<Check>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Status> Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'status' cannot be null",
                    new System::ArgumentOutOfRangeException("status", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Status>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, global::Courier.Models.Notifications.Type> Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, global::Courier.Models.Notifications.Type>
            >(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Updated
    {
        get
        {
            if (!this.Properties.TryGetValue("updated", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'updated' cannot be null",
                    new System::ArgumentOutOfRangeException("updated", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["updated"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Check(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Check FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<global::Courier.Models.Notifications.IntersectionMember1>))]
public sealed record class IntersectionMember1
    : ModelBase,
        IFromRaw<global::Courier.Models.Notifications.IntersectionMember1>
{
    public required long Updated
    {
        get
        {
            if (!this.Properties.TryGetValue("updated", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'updated' cannot be null",
                    new System::ArgumentOutOfRangeException("updated", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["updated"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static global::Courier.Models.Notifications.IntersectionMember1 FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public IntersectionMember1(long updated)
        : this()
    {
        this.Updated = updated;
    }
}
