using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Notifications;

/// <summary>
/// Template fields accepted in POST and PUT request bodies, nested under a `notification` key.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        NotificationTemplateWritePayload,
        NotificationTemplateWritePayloadFromRaw
    >)
)]
public sealed record class NotificationTemplateWritePayload : JsonModel
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

    /// <summary>
    /// Send-time alias for this template — the value you pass as `event` to POST
    /// /send. Writes accept a single alias only. Optional, with three distinct meanings.
    /// Omit it to leave any existing aliases untouched. Send a string to make this
    /// the template's only alias — a template that already resolved from several
    /// aliases keeps just this one and the rest are detached. Send null to remove
    /// every alias from the template. An alias may not be claimed by another template
    /// — doing so returns 409 — and may not begin with "tenant/".
    /// </summary>
    public string? Alias
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("alias");
        }
        init { this._rawData.Set("alias", value); }
    }

    public static implicit operator NotificationTemplatePayload(
        NotificationTemplateWritePayload notificationTemplateWritePayload
    ) =>
        new()
        {
            Brand = notificationTemplateWritePayload.Brand,
            Content = notificationTemplateWritePayload.Content,
            Name = notificationTemplateWritePayload.Name,
            Routing = notificationTemplateWritePayload.Routing,
            Subscription = notificationTemplateWritePayload.Subscription,
            Tags = notificationTemplateWritePayload.Tags,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Brand?.Validate();
        this.Content.Validate();
        _ = this.Name;
        this.Routing?.Validate();
        this.Subscription?.Validate();
        _ = this.Tags;
        _ = this.Alias;
    }

    public NotificationTemplateWritePayload() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationTemplateWritePayload(
        NotificationTemplateWritePayload notificationTemplateWritePayload
    )
        : base(notificationTemplateWritePayload) { }
#pragma warning restore CS8618

    public NotificationTemplateWritePayload(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationTemplateWritePayload(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationTemplateWritePayloadFromRaw.FromRawUnchecked"/>
    public static NotificationTemplateWritePayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationTemplateWritePayloadFromRaw : IFromRawJson<NotificationTemplateWritePayload>
{
    /// <inheritdoc/>
    public NotificationTemplateWritePayload FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationTemplateWritePayload.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        NotificationTemplateAliasWriteFields,
        NotificationTemplateAliasWriteFieldsFromRaw
    >)
)]
public sealed record class NotificationTemplateAliasWriteFields : JsonModel
{
    /// <summary>
    /// Send-time alias for this template — the value you pass as `event` to POST
    /// /send. Writes accept a single alias only. Optional, with three distinct meanings.
    /// Omit it to leave any existing aliases untouched. Send a string to make this
    /// the template's only alias — a template that already resolved from several
    /// aliases keeps just this one and the rest are detached. Send null to remove
    /// every alias from the template. An alias may not be claimed by another template
    /// — doing so returns 409 — and may not begin with "tenant/".
    /// </summary>
    public string? Alias
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("alias");
        }
        init { this._rawData.Set("alias", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Alias;
    }

    public NotificationTemplateAliasWriteFields() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationTemplateAliasWriteFields(
        NotificationTemplateAliasWriteFields notificationTemplateAliasWriteFields
    )
        : base(notificationTemplateAliasWriteFields) { }
#pragma warning restore CS8618

    public NotificationTemplateAliasWriteFields(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationTemplateAliasWriteFields(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationTemplateAliasWriteFieldsFromRaw.FromRawUnchecked"/>
    public static NotificationTemplateAliasWriteFields FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationTemplateAliasWriteFieldsFromRaw
    : IFromRawJson<NotificationTemplateAliasWriteFields>
{
    /// <inheritdoc/>
    public NotificationTemplateAliasWriteFields FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationTemplateAliasWriteFields.FromRawUnchecked(rawData);
}
