using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

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
