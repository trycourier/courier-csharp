using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

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
