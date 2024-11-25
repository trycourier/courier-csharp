using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<ChannelSource>))]
public enum ChannelSource
{
    [EnumMember(Value = "subscription")]
    Subscription,

    [EnumMember(Value = "list")]
    List,

    [EnumMember(Value = "recipient")]
    Recipient,
}
