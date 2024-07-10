using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

[JsonConverter(typeof(StringEnumSerializer<Override>))]
public enum Override
{
    [EnumMember(Value = "MessageChannelEmailOverride")]
    MessageChannelEmailOverride,

    [EnumMember(Value = "MessageChannelPushOverride")]
    MessageChannelPushOverride
}
