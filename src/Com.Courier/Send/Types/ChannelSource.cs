using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Com.Courier;
using Com.Courier.Core;

#nullable enable

namespace Com.Courier;

[JsonConverter(typeof(StringEnumSerializer<ChannelSource>))]
public enum ChannelSource
{
    [EnumMember(Value = "subscription")]
    Subscription,

    [EnumMember(Value = "list")]
    List,

    [EnumMember(Value = "recipient")]
    Recipient
}
