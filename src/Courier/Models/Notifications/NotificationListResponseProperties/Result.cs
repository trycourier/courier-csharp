using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Notifications.NotificationListResponseProperties.ResultProperties;

namespace Courier.Models.Notifications.NotificationListResponseProperties;

[JsonConverter(typeof(ModelConverter<Result>))]
public sealed record class Result : ModelBase, IFromRaw<Result>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
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
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Note
    {
        get
        {
            if (!this.Properties.TryGetValue("note", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'note' cannot be null",
                    new ArgumentOutOfRangeException("note", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'note' cannot be null",
                    new ArgumentNullException("note")
                );
        }
        set
        {
            this.Properties["note"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required MessageRouting Routing
    {
        get
        {
            if (!this.Properties.TryGetValue("routing", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'routing' cannot be null",
                    new ArgumentOutOfRangeException("routing", "Missing required argument")
                );

            return JsonSerializer.Deserialize<MessageRouting>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'routing' cannot be null",
                    new ArgumentNullException("routing")
                );
        }
        set
        {
            this.Properties["routing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string TopicID
    {
        get
        {
            if (!this.Properties.TryGetValue("topic_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'topic_id' cannot be null",
                    new ArgumentOutOfRangeException("topic_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'topic_id' cannot be null",
                    new ArgumentNullException("topic_id")
                );
        }
        set
        {
            this.Properties["topic_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long UpdatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("updated_at", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'updated_at' cannot be null",
                    new ArgumentOutOfRangeException("updated_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["updated_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Tags? Tags
    {
        get
        {
            if (!this.Properties.TryGetValue("tags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Tags?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tags"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Title
    {
        get
        {
            if (!this.Properties.TryGetValue("title", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["title"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Note;
        this.Routing.Validate();
        _ = this.TopicID;
        _ = this.UpdatedAt;
        this.Tags?.Validate();
        _ = this.Title;
    }

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Result FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
