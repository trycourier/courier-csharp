using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Notifications;

/// <summary>
/// Response for GET /notifications/{id}, POST /notifications, and PUT /notifications/{id}.
/// Returns all template fields at the top level.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<NotificationTemplateResponse, NotificationTemplateResponseFromRaw>)
)]
public sealed record class NotificationTemplateResponse : JsonModel
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
    /// The template state. Always uppercase.
    /// </summary>
    public required ApiEnum<string, NotificationTemplateResponseIntersectionMember1State> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NotificationTemplateResponseIntersectionMember1State>
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

    public static implicit operator NotificationTemplatePayload(
        NotificationTemplateResponse notificationTemplateResponse
    ) =>
        new()
        {
            Brand = notificationTemplateResponse.Brand,
            Content = notificationTemplateResponse.Content,
            Name = notificationTemplateResponse.Name,
            Routing = notificationTemplateResponse.Routing,
            Subscription = notificationTemplateResponse.Subscription,
            Tags = notificationTemplateResponse.Tags,
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
        _ = this.Created;
        _ = this.Creator;
        this.State.Validate();
        _ = this.Updated;
        _ = this.Updater;
    }

    public NotificationTemplateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationTemplateResponse(NotificationTemplateResponse notificationTemplateResponse)
        : base(notificationTemplateResponse) { }
#pragma warning restore CS8618

    public NotificationTemplateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationTemplateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationTemplateResponseFromRaw.FromRawUnchecked"/>
    public static NotificationTemplateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationTemplateResponseFromRaw : IFromRawJson<NotificationTemplateResponse>
{
    /// <inheritdoc/>
    public NotificationTemplateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationTemplateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        NotificationTemplateResponseIntersectionMember1,
        NotificationTemplateResponseIntersectionMember1FromRaw
    >)
)]
public sealed record class NotificationTemplateResponseIntersectionMember1 : JsonModel
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
    /// The template state. Always uppercase.
    /// </summary>
    public required ApiEnum<string, NotificationTemplateResponseIntersectionMember1State> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NotificationTemplateResponseIntersectionMember1State>
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
        _ = this.ID;
        _ = this.Created;
        _ = this.Creator;
        this.State.Validate();
        _ = this.Updated;
        _ = this.Updater;
    }

    public NotificationTemplateResponseIntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationTemplateResponseIntersectionMember1(
        NotificationTemplateResponseIntersectionMember1 notificationTemplateResponseIntersectionMember1
    )
        : base(notificationTemplateResponseIntersectionMember1) { }
#pragma warning restore CS8618

    public NotificationTemplateResponseIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationTemplateResponseIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationTemplateResponseIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static NotificationTemplateResponseIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationTemplateResponseIntersectionMember1FromRaw
    : IFromRawJson<NotificationTemplateResponseIntersectionMember1>
{
    /// <inheritdoc/>
    public NotificationTemplateResponseIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationTemplateResponseIntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The template state. Always uppercase.
/// </summary>
[JsonConverter(typeof(NotificationTemplateResponseIntersectionMember1StateConverter))]
public enum NotificationTemplateResponseIntersectionMember1State
{
    Draft,
    Published,
}

sealed class NotificationTemplateResponseIntersectionMember1StateConverter
    : JsonConverter<NotificationTemplateResponseIntersectionMember1State>
{
    public override NotificationTemplateResponseIntersectionMember1State Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => NotificationTemplateResponseIntersectionMember1State.Draft,
            "PUBLISHED" => NotificationTemplateResponseIntersectionMember1State.Published,
            _ => (NotificationTemplateResponseIntersectionMember1State)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NotificationTemplateResponseIntersectionMember1State value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NotificationTemplateResponseIntersectionMember1State.Draft => "DRAFT",
                NotificationTemplateResponseIntersectionMember1State.Published => "PUBLISHED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
