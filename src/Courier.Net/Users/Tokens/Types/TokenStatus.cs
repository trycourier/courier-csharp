using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net.Core;
using Courier.Net.Users;

#nullable enable

namespace Courier.Net.Users;

[JsonConverter(typeof(StringEnumSerializer<TokenStatus>))]
public enum TokenStatus
{
    [EnumMember(Value = "active")]
    Active,

    [EnumMember(Value = "unknown")]
    Unknown,

    [EnumMember(Value = "failed")]
    Failed,

    [EnumMember(Value = "revoked")]
    Revoked
}
