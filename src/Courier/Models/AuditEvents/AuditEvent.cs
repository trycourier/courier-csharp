using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.AuditEvents;

[JsonConverter(typeof(ModelConverter<AuditEvent, AuditEventFromRaw>))]
public sealed record class AuditEvent : ModelBase
{
    public required Actor Actor
    {
        get { return ModelBase.GetNotNullClass<Actor>(this.RawData, "actor"); }
        init { ModelBase.Set(this._rawData, "actor", value); }
    }

    public required string AuditEventID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "auditEventId"); }
        init { ModelBase.Set(this._rawData, "auditEventId", value); }
    }

    public required string Source
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "source"); }
        init { ModelBase.Set(this._rawData, "source", value); }
    }

    public required string Target
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "target"); }
        init { ModelBase.Set(this._rawData, "target", value); }
    }

    public required string Timestamp
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "timestamp"); }
        init { ModelBase.Set(this._rawData, "timestamp", value); }
    }

    public required string Type
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
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

    /// <inheritdoc cref="AuditEventFromRaw.FromRawUnchecked"/>
    public static AuditEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AuditEventFromRaw : IFromRaw<AuditEvent>
{
    /// <inheritdoc/>
    public AuditEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AuditEvent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Actor, ActorFromRaw>))]
public sealed record class Actor : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public string? Email
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "email"); }
        init { ModelBase.Set(this._rawData, "email", value); }
    }

    /// <inheritdoc/>
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

class ActorFromRaw : IFromRaw<Actor>
{
    /// <inheritdoc/>
    public Actor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Actor.FromRawUnchecked(rawData);
}
