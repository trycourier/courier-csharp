using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties.PreferencesProperties.NotificationsProperties.NotificationsItemProperties;

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    OptedIn,
    OptedOut,
    Required,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPTED_IN" => Status.OptedIn,
            "OPTED_OUT" => Status.OptedOut,
            "REQUIRED" => Status.Required,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.OptedIn => "OPTED_IN",
                Status.OptedOut => "OPTED_OUT",
                Status.Required => "REQUIRED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
