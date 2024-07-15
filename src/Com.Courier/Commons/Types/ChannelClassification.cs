using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<ChannelClassification>))]
public enum ChannelClassification
{
    [EnumMember(Value = "direct_message")]
    DirectMessage,

    [EnumMember(Value = "email")]
    Email,

    [EnumMember(Value = "push")]
    Push,

    [EnumMember(Value = "sms")]
    Sms,

    [EnumMember(Value = "webhook")]
    Webhook,

    [EnumMember(Value = "inbox")]
    Inbox
}
