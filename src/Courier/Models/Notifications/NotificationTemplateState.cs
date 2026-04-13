using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Notifications;

/// <summary>
/// Template state. Defaults to `DRAFT`.
/// </summary>
[JsonConverter(typeof(NotificationTemplateStateConverter))]
public enum NotificationTemplateState
{
    Draft,
    Published,
}

sealed class NotificationTemplateStateConverter : JsonConverter<NotificationTemplateState>
{
    public override NotificationTemplateState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => NotificationTemplateState.Draft,
            "PUBLISHED" => NotificationTemplateState.Published,
            _ => (NotificationTemplateState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NotificationTemplateState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NotificationTemplateState.Draft => "DRAFT",
                NotificationTemplateState.Published => "PUBLISHED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
