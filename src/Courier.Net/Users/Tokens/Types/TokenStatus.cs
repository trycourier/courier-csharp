using System.Runtime.Serialization;

namespace Courier.Net.Users;

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
