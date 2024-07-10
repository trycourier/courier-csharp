using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

[JsonConverter(typeof(StringEnumSerializer<SnoozeRuleType>))]
public enum SnoozeRuleType
{
    [EnumMember(Value = "snooze")]
    Snooze
}
