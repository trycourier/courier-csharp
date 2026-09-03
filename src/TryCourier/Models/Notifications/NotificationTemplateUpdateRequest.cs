using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Notifications;

/// <summary>
/// Request body for replacing a notification template. All fields are required, since
/// `PUT` is a full replacement, except `alias`, whose omission leaves the existing
/// aliases in place. Unlike `NotificationTemplateCreateRequest`, `notification.content`
/// is not required to place its elements inside a channel block: the requirement
/// applies to creation only, so templates already stored without one stay editable.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        NotificationTemplateUpdateRequest,
        NotificationTemplateUpdateRequestFromRaw
    >)
)]
public sealed record class NotificationTemplateUpdateRequest : JsonModel
{
    /// <summary>
    /// Template fields accepted in POST and PUT request bodies, nested under a `notification` key.
    /// </summary>
    public required NotificationTemplateWritePayload Notification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NotificationTemplateWritePayload>("notification");
        }
        init { this._rawData.Set("notification", value); }
    }

    /// <summary>
    /// Template state after update. Case-insensitive input, normalized to uppercase
    /// in the response. Defaults to "DRAFT".
    /// </summary>
    public ApiEnum<string, NotificationTemplateUpdateRequestState>? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, NotificationTemplateUpdateRequestState>
            >("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Notification.Validate();
        this.State?.Validate();
    }

    public NotificationTemplateUpdateRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationTemplateUpdateRequest(
        NotificationTemplateUpdateRequest notificationTemplateUpdateRequest
    )
        : base(notificationTemplateUpdateRequest) { }
#pragma warning restore CS8618

    public NotificationTemplateUpdateRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationTemplateUpdateRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationTemplateUpdateRequestFromRaw.FromRawUnchecked"/>
    public static NotificationTemplateUpdateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotificationTemplateUpdateRequest(NotificationTemplateWritePayload notification)
        : this()
    {
        this.Notification = notification;
    }
}

class NotificationTemplateUpdateRequestFromRaw : IFromRawJson<NotificationTemplateUpdateRequest>
{
    /// <inheritdoc/>
    public NotificationTemplateUpdateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationTemplateUpdateRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Template state after update. Case-insensitive input, normalized to uppercase in
/// the response. Defaults to "DRAFT".
/// </summary>
[JsonConverter(typeof(NotificationTemplateUpdateRequestStateConverter))]
public enum NotificationTemplateUpdateRequestState
{
    Draft,
    Published,
}

sealed class NotificationTemplateUpdateRequestStateConverter
    : JsonConverter<NotificationTemplateUpdateRequestState>
{
    public override NotificationTemplateUpdateRequestState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => NotificationTemplateUpdateRequestState.Draft,
            "PUBLISHED" => NotificationTemplateUpdateRequestState.Published,
            _ => (NotificationTemplateUpdateRequestState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NotificationTemplateUpdateRequestState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NotificationTemplateUpdateRequestState.Draft => "DRAFT",
                NotificationTemplateUpdateRequestState.Published => "PUBLISHED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
