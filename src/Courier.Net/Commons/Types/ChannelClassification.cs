using System.Runtime.Serialization;

namespace Courier.Net;

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
