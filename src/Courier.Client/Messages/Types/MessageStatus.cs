using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<MessageStatus>))]
public enum MessageStatus
{
    [EnumMember(Value = "CANCELED")]
    Canceled,

    [EnumMember(Value = "CLICKED")]
    Clicked,

    [EnumMember(Value = "DELAYED")]
    Delayed,

    [EnumMember(Value = "DELIVERED")]
    Delivered,

    [EnumMember(Value = "DIGESTED")]
    Digested,

    [EnumMember(Value = "ENQUEUED")]
    Enqueued,

    [EnumMember(Value = "FILTERED")]
    Filtered,

    [EnumMember(Value = "OPENED")]
    Opened,

    [EnumMember(Value = "ROUTED")]
    Routed,

    [EnumMember(Value = "SENT")]
    Sent,

    [EnumMember(Value = "SIMULATED")]
    Simulated,

    [EnumMember(Value = "THROTTLED")]
    Throttled,

    [EnumMember(Value = "UNDELIVERABLE")]
    Undeliverable,

    [EnumMember(Value = "UNMAPPED")]
    Unmapped,

    [EnumMember(Value = "UNROUTABLE")]
    Unroutable,
}
