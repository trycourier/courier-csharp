using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties.PreferencesProperties.CategoriesProperties.CategoriesItemProperties.ChannelPreferenceProperties;

[JsonConverter(typeof(ChannelConverter))]
public enum Channel
{
    DirectMessage,
    Email,
    Push,
    SMS,
    Webhook,
    Inbox,
}

sealed class ChannelConverter : JsonConverter<Channel>
{
    public override Channel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct_message" => Channel.DirectMessage,
            "email" => Channel.Email,
            "push" => Channel.Push,
            "sms" => Channel.SMS,
            "webhook" => Channel.Webhook,
            "inbox" => Channel.Inbox,
            _ => (Channel)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Channel value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Channel.DirectMessage => "direct_message",
                Channel.Email => "email",
                Channel.Push => "push",
                Channel.SMS => "sms",
                Channel.Webhook => "webhook",
                Channel.Inbox => "inbox",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
