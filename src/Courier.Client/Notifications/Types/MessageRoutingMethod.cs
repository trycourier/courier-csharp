using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

[JsonConverter(typeof(EnumSerializer<MessageRoutingMethod>))]
public enum MessageRoutingMethod
{
    [EnumMember(Value = "all")]
    All,

    [EnumMember(Value = "single")]
    Single,
}
