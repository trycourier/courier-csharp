using System.Runtime.Serialization;

namespace Courier.Net;

public enum SubscriptionTopicStatus
{
    [EnumMember(Value = "OPTED_OUT")]
    OptedOut,

    [EnumMember(Value = "OPTED_IN")]
    OptedIn,

    [EnumMember(Value = "REQUIRED")]
    Required
}
