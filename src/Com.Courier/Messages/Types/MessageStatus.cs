using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<MessageStatus>))]
public enum MessageStatus
{
    [EnumMember(Value = "CLICKED")]
    Clicked,

    [EnumMember(Value = "DELIVERED")]
    Delivered,

    [EnumMember(Value = "ENQUEUED")]
    Enqueued,

    [EnumMember(Value = "OPENED")]
    Opened,

    [EnumMember(Value = "CANCELED")]
    Canceled,

    [EnumMember(Value = "SENT")]
    Sent,

    [EnumMember(Value = "THROTTLED")]
    Throttled,

    [EnumMember(Value = "UNDELIVERABLE")]
    Undeliverable,

    [EnumMember(Value = "UNMAPPED")]
    Unmapped,

    [EnumMember(Value = "UNROUTABLE")]
    Unroutable
}
