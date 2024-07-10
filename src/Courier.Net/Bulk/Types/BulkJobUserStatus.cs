using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

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
