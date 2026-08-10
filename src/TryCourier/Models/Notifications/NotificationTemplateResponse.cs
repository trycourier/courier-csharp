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
    public required ApiEnum<string, NotificationTemplateResponseFieldsState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NotificationTemplateResponseFieldsState>
            >("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// A template's send-time alias as returned by a read, omitted entirely when
    /// it has none. Usually a single string; an array for a template that resolves
    /// from several aliases, which writes through this API can no longer produce
    /// — only templates predating that restriction, or aliases attached outside
    /// this API, hold more than one.
    /// </summary>
    public NotificationTemplateAlias? Alias
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NotificationTemplateAlias>("alias");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("alias", value);
        }
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
        this.Alias?.Validate();
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
        NotificationTemplateResponseFields,
        NotificationTemplateResponseFieldsFromRaw
    >)
)]
public sealed record class NotificationTemplateResponseFields : JsonModel
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
    public required ApiEnum<string, NotificationTemplateResponseFieldsState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NotificationTemplateResponseFieldsState>
            >("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// A template's send-time alias as returned by a read, omitted entirely when
    /// it has none. Usually a single string; an array for a template that resolves
    /// from several aliases, which writes through this API can no longer produce
    /// — only templates predating that restriction, or aliases attached outside
    /// this API, hold more than one.
    /// </summary>
    public NotificationTemplateAlias? Alias
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NotificationTemplateAlias>("alias");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("alias", value);
        }
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
        this.Alias?.Validate();
        _ = this.Updated;
        _ = this.Updater;
    }

    public NotificationTemplateResponseFields() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationTemplateResponseFields(
        NotificationTemplateResponseFields notificationTemplateResponseFields
    )
        : base(notificationTemplateResponseFields) { }
#pragma warning restore CS8618

    public NotificationTemplateResponseFields(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationTemplateResponseFields(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationTemplateResponseFieldsFromRaw.FromRawUnchecked"/>
    public static NotificationTemplateResponseFields FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationTemplateResponseFieldsFromRaw : IFromRawJson<NotificationTemplateResponseFields>
{
    /// <inheritdoc/>
    public NotificationTemplateResponseFields FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationTemplateResponseFields.FromRawUnchecked(rawData);
}

/// <summary>
/// The template state. Always uppercase.
/// </summary>
[JsonConverter(typeof(NotificationTemplateResponseFieldsStateConverter))]
public enum NotificationTemplateResponseFieldsState
{
    Draft,
    Published,
}

sealed class NotificationTemplateResponseFieldsStateConverter
    : JsonConverter<NotificationTemplateResponseFieldsState>
{
    public override NotificationTemplateResponseFieldsState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => NotificationTemplateResponseFieldsState.Draft,
            "PUBLISHED" => NotificationTemplateResponseFieldsState.Published,
            _ => (NotificationTemplateResponseFieldsState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NotificationTemplateResponseFieldsState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NotificationTemplateResponseFieldsState.Draft => "DRAFT",
                NotificationTemplateResponseFieldsState.Published => "PUBLISHED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
