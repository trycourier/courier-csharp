using System;
using System.Collections.Frozen;
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
            if (!this._rawData.TryGetValue("actor", out JsonElement element))
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
        init
        {
            this._rawData["actor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string AuditEventID
    {
        get
        {
            if (!this._rawData.TryGetValue("auditEventId", out JsonElement element))
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
        init
        {
            this._rawData["auditEventId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Source
    {
        get
        {
            if (!this._rawData.TryGetValue("source", out JsonElement element))
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
        init
        {
            this._rawData["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Target
    {
        get
        {
            if (!this._rawData.TryGetValue("target", out JsonElement element))
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
        init
        {
            this._rawData["target"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Timestamp
    {
        get
        {
            if (!this._rawData.TryGetValue("timestamp", out JsonElement element))
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
        init
        {
            this._rawData["timestamp"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
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
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
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

    public AuditEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuditEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static AuditEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

[JsonConverter(typeof(ModelConverter<Actor>))]
public sealed record class Actor : ModelBase, IFromRaw<Actor>
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

    public string? Email
    {
        get
        {
            if (!this._rawData.TryGetValue("email", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["email"] = JsonSerializer.SerializeToElement(
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

    public Actor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Actor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Actor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Actor(string id)
        : this()
    {
        this.ID = id;
    }
}
