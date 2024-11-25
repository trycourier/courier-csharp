using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<SnoozeRuleType>))]
public enum SnoozeRuleType
{
    [EnumMember(Value = "snooze")]
    Snooze,
}
