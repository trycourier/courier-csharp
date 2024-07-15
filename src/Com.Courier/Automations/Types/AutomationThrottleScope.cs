using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<AutomationThrottleScope>))]
public enum AutomationThrottleScope
{
    [EnumMember(Value = "user")]
    User,

    [EnumMember(Value = "global")]
    Global,

    [EnumMember(Value = "dynamic")]
    Dynamic
}
