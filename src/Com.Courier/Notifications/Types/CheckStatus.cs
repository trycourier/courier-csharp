using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<CheckStatus>))]
public enum CheckStatus
{
    [EnumMember(Value = "RESOLVED")]
    Resolved,

    [EnumMember(Value = "FAILED")]
    Failed,

    [EnumMember(Value = "PENDING")]
    Pending
}
