using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

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
