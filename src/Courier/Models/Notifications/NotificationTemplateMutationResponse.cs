using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Notifications;

/// <summary>
/// Response returned by POST and PUT operations.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        NotificationTemplateMutationResponse,
        NotificationTemplateMutationResponseFromRaw
    >)
)]
public sealed record class NotificationTemplateMutationResponse : JsonModel
{
    public required NotificationTemplateMutationResponseNotification Notification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NotificationTemplateMutationResponseNotification>(
                "notification"
            );
        }
        init { this._rawData.Set("notification", value); }
    }

    /// <summary>
    /// The template state after the operation. Always uppercase.
    /// </summary>
    public required ApiEnum<string, NotificationTemplateMutationResponseState> State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, NotificationTemplateMutationResponseState>
            >("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Notification.Validate();
        this.State.Validate();
    }

    public NotificationTemplateMutationResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationTemplateMutationResponse(
        NotificationTemplateMutationResponse notificationTemplateMutationResponse
    )
        : base(notificationTemplateMutationResponse) { }
#pragma warning restore CS8618

    public NotificationTemplateMutationResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationTemplateMutationResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationTemplateMutationResponseFromRaw.FromRawUnchecked"/>
    public static NotificationTemplateMutationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NotificationTemplateMutationResponseFromRaw
    : IFromRawJson<NotificationTemplateMutationResponse>
{
    /// <inheritdoc/>
    public NotificationTemplateMutationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationTemplateMutationResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        NotificationTemplateMutationResponseNotification,
        NotificationTemplateMutationResponseNotificationFromRaw
    >)
)]
public sealed record class NotificationTemplateMutationResponseNotification : JsonModel
{
    /// <summary>
    /// The ID of the created or updated template.
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

    public NotificationTemplateMutationResponseNotification() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationTemplateMutationResponseNotification(
        NotificationTemplateMutationResponseNotification notificationTemplateMutationResponseNotification
    )
        : base(notificationTemplateMutationResponseNotification) { }
#pragma warning restore CS8618

    public NotificationTemplateMutationResponseNotification(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationTemplateMutationResponseNotification(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationTemplateMutationResponseNotificationFromRaw.FromRawUnchecked"/>
    public static NotificationTemplateMutationResponseNotification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotificationTemplateMutationResponseNotification(string id)
        : this()
    {
        this.ID = id;
    }
}

class NotificationTemplateMutationResponseNotificationFromRaw
    : IFromRawJson<NotificationTemplateMutationResponseNotification>
{
    /// <inheritdoc/>
    public NotificationTemplateMutationResponseNotification FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationTemplateMutationResponseNotification.FromRawUnchecked(rawData);
}

/// <summary>
/// The template state after the operation. Always uppercase.
/// </summary>
[JsonConverter(typeof(NotificationTemplateMutationResponseStateConverter))]
public enum NotificationTemplateMutationResponseState
{
    Draft,
    Published,
}

sealed class NotificationTemplateMutationResponseStateConverter
    : JsonConverter<NotificationTemplateMutationResponseState>
{
    public override NotificationTemplateMutationResponseState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => NotificationTemplateMutationResponseState.Draft,
            "PUBLISHED" => NotificationTemplateMutationResponseState.Published,
            _ => (NotificationTemplateMutationResponseState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NotificationTemplateMutationResponseState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NotificationTemplateMutationResponseState.Draft => "DRAFT",
                NotificationTemplateMutationResponseState.Published => "PUBLISHED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
