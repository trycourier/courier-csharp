using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<BulkJobUserStatus>))]
public enum BulkJobUserStatus
{
    [EnumMember(Value = "PENDING")]
    Pending,

    [EnumMember(Value = "ENQUEUED")]
    Enqueued,

    [EnumMember(Value = "ERROR")]
    Error
}
