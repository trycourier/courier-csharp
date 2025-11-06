using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.AuditEvents;

[JsonConverter(typeof(ModelConverter<AuditEvent>))]
public sealed record class AuditEvent : ModelBase, IFromRaw<AuditEvent>
{
    public required Actor Actor
    {
        get
        {
            if (!this.Properties.TryGetValue("actor", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'actor' cannot be null",
                    new ArgumentOutOfRangeException("actor", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Actor>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'actor' cannot be null",
                    new ArgumentNullException("actor")
                );
        }
        set
        {
            this.Properties["actor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string AuditEventID
    {
        get
        {
            if (!this.Properties.TryGetValue("auditEventId", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'auditEventId' cannot be null",
                    new ArgumentOutOfRangeException("auditEventId", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'auditEventId' cannot be null",
                    new ArgumentNullException("auditEventId")
                );
        }
        set
        {
            this.Properties["auditEventId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Source
    {
        get
        {
            if (!this.Properties.TryGetValue("source", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'source' cannot be null",
                    new ArgumentOutOfRangeException("source", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'source' cannot be null",
                    new ArgumentNullException("source")
                );
        }
        set
        {
            this.Properties["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Target
    {
        get
        {
            if (!this.Properties.TryGetValue("target", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'target' cannot be null",
                    new ArgumentOutOfRangeException("target", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'target' cannot be null",
                    new ArgumentNullException("target")
                );
        }
        set
        {
            this.Properties["target"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Timestamp
    {
        get
        {
            if (!this.Properties.TryGetValue("timestamp", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'timestamp' cannot be null",
                    new ArgumentOutOfRangeException("timestamp", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'timestamp' cannot be null",
                    new ArgumentNullException("timestamp")
                );
        }
        set
        {
            this.Properties["timestamp"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentNullException("type")
                );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Actor.Validate();
        _ = this.AuditEventID;
        _ = this.Source;
        _ = this.Target;
        _ = this.Timestamp;
        _ = this.Type;
    }

    public AuditEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuditEvent(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AuditEvent FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ModelConverter<Actor>))]
public sealed record class Actor : ModelBase, IFromRaw<Actor>
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

    public string? Email
    {
        get
        {
            if (!this.Properties.TryGetValue("email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Email;
    }

    public Actor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Actor(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Actor FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Actor(string id)
        : this()
    {
        this.ID = id;
    }
}
