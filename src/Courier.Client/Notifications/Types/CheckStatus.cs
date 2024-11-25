using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<CheckStatus>))]
public enum CheckStatus
{
    [EnumMember(Value = "RESOLVED")]
    Resolved,

    [EnumMember(Value = "FAILED")]
    Failed,

    [EnumMember(Value = "PENDING")]
    Pending,
}
