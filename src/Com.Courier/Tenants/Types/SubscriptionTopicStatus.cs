using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<SubscriptionTopicStatus>))]
public enum SubscriptionTopicStatus
{
    [EnumMember(Value = "OPTED_OUT")]
    OptedOut,

    [EnumMember(Value = "OPTED_IN")]
    OptedIn,

    [EnumMember(Value = "REQUIRED")]
    Required
}
