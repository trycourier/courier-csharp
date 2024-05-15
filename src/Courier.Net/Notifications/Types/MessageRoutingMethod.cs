using System.Runtime.Serialization;

namespace Courier.Net;

public enum MessageRoutingMethod
{
    [EnumMember(Value = "all")]
    All,

    [EnumMember(Value = "single")]
    Single
}
