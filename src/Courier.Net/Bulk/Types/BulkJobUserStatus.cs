using System.Runtime.Serialization;

namespace Courier.Net;

public enum BulkJobUserStatus
{
    [EnumMember(Value = "PENDING")]
    Pending,

    [EnumMember(Value = "ENQUEUED")]
    Enqueued,

    [EnumMember(Value = "ERROR")]
    Error
}
