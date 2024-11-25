using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<BulkJobUserStatus>))]
public enum BulkJobUserStatus
{
    [EnumMember(Value = "PENDING")]
    Pending,

    [EnumMember(Value = "ENQUEUED")]
    Enqueued,

    [EnumMember(Value = "ERROR")]
    Error,
}
