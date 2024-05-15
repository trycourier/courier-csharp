using System.Runtime.Serialization;

namespace Courier.Net;

public enum AutomationAddToBatchRetainType
{
    [EnumMember(Value = "first")]
    First,

    [EnumMember(Value = "last")]
    Last,

    [EnumMember(Value = "highest")]
    Highest,

    [EnumMember(Value = "lowest")]
    Lowest
}
