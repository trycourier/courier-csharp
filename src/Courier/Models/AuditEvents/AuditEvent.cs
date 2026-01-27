using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.AuditEvents;

[JsonConverter(typeof(JsonModelConverter<AuditEvent, AuditEventFromRaw>))]
public sealed record class AuditEvent : JsonModel
{
    public required Actor Actor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Actor>("actor");
        }
        init { this._rawData.Set("actor", value); }
    }

    public required string AuditEventID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("auditEventId");
        }
        init { this._rawData.Set("auditEventId", value); }
    }

    public required string Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    public required string Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    public required string Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("timestamp");
        }
        init { this._rawData.Set("timestamp", value); }
    }

    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
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
    public AuditEvent(AuditEvent auditEvent)
        : base(auditEvent) { }
#pragma warning restore CS8618

    public AuditEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuditEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AuditEventFromRaw.FromRawUnchecked"/>
    public static AuditEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AuditEventFromRaw : IFromRawJson<AuditEvent>
{
    /// <inheritdoc/>
    public AuditEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AuditEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Actor, ActorFromRaw>))]
public sealed record class Actor : JsonModel
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

    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Email;
    }

    public Actor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Actor(Actor actor)
        : base(actor) { }
#pragma warning restore CS8618

    public Actor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Actor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ActorFromRaw.FromRawUnchecked"/>
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

class ActorFromRaw : IFromRawJson<Actor>
{
    /// <inheritdoc/>
    public Actor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Actor.FromRawUnchecked(rawData);
}
