using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Tenants.DefaultPreferences.Items.SubscriptionTopicNewProperties;

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    OptedOut,
    OptedIn,
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
            "OPTED_OUT" => Status.OptedOut,
            "OPTED_IN" => Status.OptedIn,
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
                Status.OptedOut => "OPTED_OUT",
                Status.OptedIn => "OPTED_IN",
                Status.Required => "REQUIRED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
