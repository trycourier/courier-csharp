using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(ChannelClassificationConverter))]
public enum ChannelClassification
{
    DirectMessage,
    Email,
    Push,
    Sms,
    Webhook,
    Inbox,
}

sealed class ChannelClassificationConverter : JsonConverter<ChannelClassification>
{
    public override ChannelClassification Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct_message" => ChannelClassification.DirectMessage,
            "email" => ChannelClassification.Email,
            "push" => ChannelClassification.Push,
            "sms" => ChannelClassification.Sms,
            "webhook" => ChannelClassification.Webhook,
            "inbox" => ChannelClassification.Inbox,
            _ => (ChannelClassification)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChannelClassification value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChannelClassification.DirectMessage => "direct_message",
                ChannelClassification.Email => "email",
                ChannelClassification.Push => "push",
                ChannelClassification.Sms => "sms",
                ChannelClassification.Webhook => "webhook",
                ChannelClassification.Inbox => "inbox",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
