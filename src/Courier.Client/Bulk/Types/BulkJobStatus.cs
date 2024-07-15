using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

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
