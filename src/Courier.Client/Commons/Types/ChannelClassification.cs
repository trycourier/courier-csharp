using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

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
