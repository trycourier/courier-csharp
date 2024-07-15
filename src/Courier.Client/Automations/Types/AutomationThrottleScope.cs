using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

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
