using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Notifications;

/// <summary>
/// Core template fields used in POST and PUT request bodies (nested under a `notification`
/// key) and returned at the top level in responses.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<NotificationTemplatePayload, NotificationTemplatePayloadFromRaw>)
)]
public sealed record class NotificationTemplatePayload : JsonModel
{
    /// <summary>
    /// Brand reference, or null for no brand.
    /// </summary>
    public required Brand? Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Brand>("brand");
        }
        init { this._rawData.Set("brand", value); }
    }

    /// <summary>
    /// Elemental content definition.
    /// </summary>
    public required ElementalContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ElementalContent>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// Display name for the template.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Routing strategy reference, or null for none.
    /// </summary>
    public required Routing? Routing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Routing>("routing");
        }
        init { this._rawData.Set("routing", value); }
    }

    /// <summary>
    /// Subscription topic reference, or null for none.
    /// </summary>
    public required Subscription? Subscription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Subscription>("subscription");
        }
        init { this._rawData.Set("subscription", value); }
    }

    /// <summary>
    /// Tags for categorization. Send empty array for none.
    /// </summary>
    public required IReadOnlyList<string> Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "tags",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Brand?.Validate();
        this.Content.Validate();
        _ = this.Name;
        this.Routing?.Validate();
        this.Subscription?.Validate();
        _ = this.Tags;
    }

    public NotificationTemplatePayload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationTemplatePayload(NotificationTemplatePayload notificationTemplatePayload)
        : base(notificationTemplatePayload) { }
#pragma warning restore CS8618

    public NotificationTemplatePayload(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationTemplatePayload(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationTemplatePayloadFromRaw.FromRawUnchecked"/>
    public static NotificationTemplatePayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationTemplatePayloadFromRaw : IFromRawJson<NotificationTemplatePayload>
{
    /// <inheritdoc/>
    public NotificationTemplatePayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationTemplatePayload.FromRawUnchecked(rawData);
}

/// <summary>
/// Brand reference, or null for no brand.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Brand, BrandFromRaw>))]
public sealed record class Brand : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public Brand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Brand(Brand brand)
        : base(brand) { }
#pragma warning restore CS8618

    public Brand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Brand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandFromRaw.FromRawUnchecked"/>
    public static Brand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Brand(string id)
        : this()
    {
        this.ID = id;
    }
}

class BrandFromRaw : IFromRawJson<Brand>
{
    /// <inheritdoc/>
    public Brand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Brand.FromRawUnchecked(rawData);
}

/// <summary>
/// Routing strategy reference, or null for none.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Routing, RoutingFromRaw>))]
public sealed record class Routing : JsonModel
{
    public required string StrategyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("strategy_id");
        }
        init { this._rawData.Set("strategy_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.StrategyID;
    }

    public Routing() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Routing(Routing routing)
        : base(routing) { }
#pragma warning restore CS8618

    public Routing(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Routing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RoutingFromRaw.FromRawUnchecked"/>
    public static Routing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Routing(string strategyID)
        : this()
    {
        this.StrategyID = strategyID;
    }
}

class RoutingFromRaw : IFromRawJson<Routing>
{
    /// <inheritdoc/>
    public Routing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Routing.FromRawUnchecked(rawData);
}

/// <summary>
/// Subscription topic reference, or null for none.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Subscription, SubscriptionFromRaw>))]
public sealed record class Subscription : JsonModel
{
    public required string TopicID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("topic_id");
        }
        init { this._rawData.Set("topic_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TopicID;
    }

    public Subscription() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Subscription(Subscription subscription)
        : base(subscription) { }
#pragma warning restore CS8618

    public Subscription(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Subscription(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriptionFromRaw.FromRawUnchecked"/>
    public static Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Subscription(string topicID)
        : this()
    {
        this.TopicID = topicID;
    }
}

class SubscriptionFromRaw : IFromRawJson<Subscription>
{
    /// <inheritdoc/>
    public Subscription FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Subscription.FromRawUnchecked(rawData);
}
