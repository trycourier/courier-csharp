using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Audiences.AudienceListMembersResponseProperties;

[JsonConverter(typeof(ModelConverter<Item>))]
public sealed record class Item : ModelBase, IFromRaw<Item>
{
    public required string AddedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("added_at", out JsonElement element))
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
        set
        {
            this.Properties["added_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string AudienceID
    {
        get
        {
            if (!this.Properties.TryGetValue("audience_id", out JsonElement element))
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
        set
        {
            this.Properties["audience_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long AudienceVersion
    {
        get
        {
            if (!this.Properties.TryGetValue("audience_version", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'audience_version' cannot be null",
                    new ArgumentOutOfRangeException("audience_version", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["audience_version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string MemberID
    {
        get
        {
            if (!this.Properties.TryGetValue("member_id", out JsonElement element))
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
        set
        {
            this.Properties["member_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Reason
    {
        get
        {
            if (!this.Properties.TryGetValue("reason", out JsonElement element))
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
        set
        {
            this.Properties["reason"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Item FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
