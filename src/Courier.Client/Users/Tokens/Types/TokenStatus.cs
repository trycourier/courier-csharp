using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;
using Courier.Client.Users;

#nullable enable

namespace Courier.Client.Users;

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
