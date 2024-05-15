using System.Runtime.Serialization;

namespace Courier.Net;

public enum ChannelSource
{
    [EnumMember(Value = "subscription")]
    Subscription,

    [EnumMember(Value = "list")]
    List,

    [EnumMember(Value = "recipient")]
    Recipient
}
