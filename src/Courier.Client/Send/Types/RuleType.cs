using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<RuleType>))]
public enum RuleType
{
    [EnumMember(Value = "snooze")]
    Snooze,

    [EnumMember(Value = "channel_preferences")]
    ChannelPreferences,

    [EnumMember(Value = "status")]
    Status,
}
