using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<BulkJobStatus>))]
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
