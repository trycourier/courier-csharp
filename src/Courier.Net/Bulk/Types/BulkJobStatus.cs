using System.Runtime.Serialization;

namespace Courier.Net;

public enum BulkJobStatus
{
    [EnumMember(Value = "CREATED")]
    Created,

    [EnumMember(Value = "PROCESSING")]
    Processing,

    [EnumMember(Value = "COMPLETED")]
    Completed,

    [EnumMember(Value = "ERROR")]
    Error
}
