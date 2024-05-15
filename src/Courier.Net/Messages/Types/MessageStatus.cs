using System.Runtime.Serialization;

namespace Courier.Net;

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
