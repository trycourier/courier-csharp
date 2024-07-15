using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier.Core;
using Com.Courier.Users;

#nullable enable

namespace Com.Courier.Users;

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
