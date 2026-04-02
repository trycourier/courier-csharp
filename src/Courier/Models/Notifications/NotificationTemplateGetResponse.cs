using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Notifications;

/// <summary>
/// Envelope response for GET /notifications/{id}. The notification object mirrors
/// the POST/PUT input shape. Nullable fields return null when unset.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        NotificationTemplateGetResponse,
        NotificationTemplateGetResponseFromRaw
    >)
)]
public sealed record class NotificationTemplateGetResponse : JsonModel
{
    /// <summary>
    /// Epoch milliseconds when the template was created.
    /// </summary>
    public required long Created
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("created");
        }
        init { this._rawData.Set("created", value); }
    }

    /// <summary>
    /// User ID of the creator.
    /// </summary>
    public required string Creator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("creator");
        }
        init { this._rawData.Set("creator", value); }
    }

    /// <summary>
    /// Full document shape used in POST and PUT request bodies, and returned inside
    /// the GET response envelope.
    /// </summary>
    public required Notification Notification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Notification>("notification");
        }
        init { this._rawData.Set("notification", value); }
    }

    /// <summary>
    /// The template state. Always uppercase.
    /// </summary>
    public required ApiEnum<string, NotificationTemplateGetResponseState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NotificationTemplateGetResponseState>
            >("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// Epoch milliseconds of last update.
    /// </summary>
    public long? Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("updated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updated", value);
        }
    }

    /// <summary>
    /// User ID of the last updater.
    /// </summary>
    public string? Updater
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updater");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updater", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Created;
        _ = this.Creator;
        this.Notification.Validate();
        this.State.Validate();
        _ = this.Updated;
        _ = this.Updater;
    }

    public NotificationTemplateGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationTemplateGetResponse(
        NotificationTemplateGetResponse notificationTemplateGetResponse
    )
        : base(notificationTemplateGetResponse) { }
#pragma warning restore CS8618

    public NotificationTemplateGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationTemplateGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationTemplateGetResponseFromRaw.FromRawUnchecked"/>
    public static NotificationTemplateGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationTemplateGetResponseFromRaw : IFromRawJson<NotificationTemplateGetResponse>
{
    /// <inheritdoc/>
    public NotificationTemplateGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationTemplateGetResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Full document shape used in POST and PUT request bodies, and returned inside the
/// GET response envelope.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Notification, NotificationFromRaw>))]
public sealed record class Notification : JsonModel
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
    /// The template ID.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public static implicit operator NotificationTemplatePayload(Notification notification) =>
        new()
        {
            Brand = notification.Brand,
            Content = notification.Content,
            Name = notification.Name,
            Routing = notification.Routing,
            Subscription = notification.Subscription,
            Tags = notification.Tags,
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
        _ = this.ID;
    }

    public Notification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Notification(Notification notification)
        : base(notification) { }
#pragma warning restore CS8618

    public Notification(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Notification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationFromRaw.FromRawUnchecked"/>
    public static Notification FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationFromRaw : IFromRawJson<Notification>
{
    /// <inheritdoc/>
    public Notification FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Notification.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        NotificationIntersectionMember1,
        NotificationIntersectionMember1FromRaw
    >)
)]
public sealed record class NotificationIntersectionMember1 : JsonModel
{
    /// <summary>
    /// The template ID.
    /// </summary>
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

    public NotificationIntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationIntersectionMember1(
        NotificationIntersectionMember1 notificationIntersectionMember1
    )
        : base(notificationIntersectionMember1) { }
#pragma warning restore CS8618

    public NotificationIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static NotificationIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotificationIntersectionMember1(string id)
        : this()
    {
        this.ID = id;
    }
}

class NotificationIntersectionMember1FromRaw : IFromRawJson<NotificationIntersectionMember1>
{
    /// <inheritdoc/>
    public NotificationIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationIntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The template state. Always uppercase.
/// </summary>
[JsonConverter(typeof(NotificationTemplateGetResponseStateConverter))]
public enum NotificationTemplateGetResponseState
{
    Draft,
    Published,
}

sealed class NotificationTemplateGetResponseStateConverter
    : JsonConverter<NotificationTemplateGetResponseState>
{
    public override NotificationTemplateGetResponseState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => NotificationTemplateGetResponseState.Draft,
            "PUBLISHED" => NotificationTemplateGetResponseState.Published,
            _ => (NotificationTemplateGetResponseState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NotificationTemplateGetResponseState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NotificationTemplateGetResponseState.Draft => "DRAFT",
                NotificationTemplateGetResponseState.Published => "PUBLISHED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
