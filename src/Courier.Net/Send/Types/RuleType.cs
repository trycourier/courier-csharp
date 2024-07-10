using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

[JsonConverter(typeof(StringEnumSerializer<RuleType>))]
public enum RuleType
{
    [EnumMember(Value = "snooze")]
    Snooze,

    [EnumMember(Value = "channel_preferences")]
    ChannelPreferences,

    [EnumMember(Value = "status")]
    Status
}
