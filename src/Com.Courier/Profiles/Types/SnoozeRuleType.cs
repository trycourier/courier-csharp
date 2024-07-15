using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<SnoozeRuleType>))]
public enum SnoozeRuleType
{
    [EnumMember(Value = "snooze")]
    Snooze
}
