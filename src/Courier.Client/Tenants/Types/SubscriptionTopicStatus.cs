using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<SubscriptionTopicStatus>))]
public enum SubscriptionTopicStatus
{
    [EnumMember(Value = "OPTED_OUT")]
    OptedOut,

    [EnumMember(Value = "OPTED_IN")]
    OptedIn,

    [EnumMember(Value = "REQUIRED")]
    Required,
}
