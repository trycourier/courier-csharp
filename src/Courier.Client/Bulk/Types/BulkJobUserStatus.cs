using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

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
