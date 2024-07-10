using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Net;
using Courier.Net.Core;

#nullable enable

namespace Courier.Net;

[JsonConverter(typeof(StringEnumSerializer<MessageRoutingMethod>))]
public enum MessageRoutingMethod
{
    [EnumMember(Value = "all")]
    All,

    [EnumMember(Value = "single")]
    Single
}
