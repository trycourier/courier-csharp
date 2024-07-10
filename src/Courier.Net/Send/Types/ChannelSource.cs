using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

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
