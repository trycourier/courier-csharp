using System.Runtime.Serialization;

namespace Courier.Net;

public enum RuleType
{
    [EnumMember(Value = "snooze")]
    Snooze,

    [EnumMember(Value = "channel_preferences")]
    ChannelPreferences,

    [EnumMember(Value = "status")]
    Status
}
