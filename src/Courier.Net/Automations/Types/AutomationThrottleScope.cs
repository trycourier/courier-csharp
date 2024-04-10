using System.Runtime.Serialization;

namespace Courier.Net;

public enum AutomationThrottleScope
{
    [EnumMember(Value = "user")]
    User,

    [EnumMember(Value = "global")]
    Global,

    [EnumMember(Value = "dynamic")]
    Dynamic
}
