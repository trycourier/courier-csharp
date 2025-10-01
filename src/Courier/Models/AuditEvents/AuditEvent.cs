using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.AuditEvents.AuditEventProperties;

namespace Courier.Models.AuditEvents;

[JsonConverter(typeof(ModelConverter<AuditEvent>))]
public sealed record class AuditEvent : ModelBase, IFromRaw<AuditEvent>
{
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

    public Actor? Actor
    {
        get
        {
            if (!this.Properties.TryGetValue("actor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Actor?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["actor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Target? Target
    {
        get
        {
            if (!this.Properties.TryGetValue("target", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Target?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["target"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AuditEventID;
        _ = this.Source;
        _ = this.Timestamp;
        _ = this.Type;
        this.Actor?.Validate();
        this.Target?.Validate();
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
