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
/// Request body for creating a notification template.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        NotificationTemplateCreateRequest,
        NotificationTemplateCreateRequestFromRaw
    >)
)]
public sealed record class NotificationTemplateCreateRequest : JsonModel
{
    /// <summary>
    /// Core template fields used in POST and PUT request bodies (nested under a `notification`
    /// key) and returned at the top level in responses.
    /// </summary>
    public required NotificationTemplatePayload Notification
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<NotificationTemplatePayload>("notification");
        }
        init { this._rawData.Set("notification", value); }
    }

    /// <summary>
    /// Template state after creation. Case-insensitive input, normalized to uppercase
    /// in the response. Defaults to "DRAFT".
    /// </summary>
    public ApiEnum<string, NotificationTemplateCreateRequestState>? State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, NotificationTemplateCreateRequestState>
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

    public NotificationTemplateCreateRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationTemplateCreateRequest(
        NotificationTemplateCreateRequest notificationTemplateCreateRequest
    )
        : base(notificationTemplateCreateRequest) { }
#pragma warning restore CS8618

    public NotificationTemplateCreateRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotificationTemplateCreateRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotificationTemplateCreateRequestFromRaw.FromRawUnchecked"/>
    public static NotificationTemplateCreateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotificationTemplateCreateRequest(NotificationTemplatePayload notification)
        : this()
    {
        this.Notification = notification;
    }
}

class NotificationTemplateCreateRequestFromRaw : IFromRawJson<NotificationTemplateCreateRequest>
{
    /// <inheritdoc/>
    public NotificationTemplateCreateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NotificationTemplateCreateRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Template state after creation. Case-insensitive input, normalized to uppercase
/// in the response. Defaults to "DRAFT".
/// </summary>
[JsonConverter(typeof(NotificationTemplateCreateRequestStateConverter))]
public enum NotificationTemplateCreateRequestState
{
    Draft,
    Published,
}

sealed class NotificationTemplateCreateRequestStateConverter
    : JsonConverter<NotificationTemplateCreateRequestState>
{
    public override NotificationTemplateCreateRequestState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => NotificationTemplateCreateRequestState.Draft,
            "PUBLISHED" => NotificationTemplateCreateRequestState.Published,
            _ => (NotificationTemplateCreateRequestState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NotificationTemplateCreateRequestState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NotificationTemplateCreateRequestState.Draft => "DRAFT",
                NotificationTemplateCreateRequestState.Published => "PUBLISHED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
