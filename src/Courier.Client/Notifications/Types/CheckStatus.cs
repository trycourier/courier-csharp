using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

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
